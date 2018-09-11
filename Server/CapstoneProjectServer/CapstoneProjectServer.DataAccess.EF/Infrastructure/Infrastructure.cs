using CapstoneProjectServer.DataAccess.EF.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProjectServer.DataAccess.EF.Infrastructure
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; set; }
    }
    public interface IRepository<TEntity> : IRepository 
    {
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
        TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null);
        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);
        bool GetExists(Expression<Func<TEntity, bool>> filter = null);
        Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null);

        void Create(TEntity entity, string createdBy = null);
        void Delete(object id, string modifiedBy = null);
        void Delete(TEntity entity, string modifiedBy = null);
        void Delete(Expression<Func<TEntity, bool>> filter, string modifiedBy = null);
        void Update(TEntity entity, string modifiedBy = null);
        void Update(TEntity entity, string[] fieldsToUpdate, string modifiedBy = null);
    }
    [System.Serializable]
    public class ConcurrencyException : System.Exception
    {
        /// <summary>
        /// The current entity data
        /// </summary>
        public object DatabaseData { get; set; }

        public ConcurrencyException() { }
        public ConcurrencyException(string message) : base(message) { }
        public ConcurrencyException(string message, System.Exception inner) : base(message, inner) { }
        public ConcurrencyException(string message, object databaseData) : base(message)
        {
            DatabaseData = databaseData ?? throw new ArgumentNullException("databaseData");
        }
        public ConcurrencyException(string message, object databaseData, System.Exception inner) : base(message, inner)
        {
            DatabaseData = databaseData ?? throw new ArgumentNullException("databaseData");
        }
        protected ConcurrencyException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [System.Serializable]
    public class DataException : System.Exception
    {
        public DataException() { }
        public DataException(string message) : base(message) { }
        public DataException(string message, System.Exception inner) : base(message, inner) { }
        protected DataException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
        string ConnectionString { get; set; }
        ICollection<ValidationResult> SaveChanges();
        Task<ICollection<ValidationResult>> SaveChangesAsync();
        IDbContextTransactionProxy BeginTransaction();
    }

    public interface IDbContextTransactionProxy : IDisposable
    {
        void Commit();
        void Rollback();
    }

    /// <summary>
    /// This is proxy. We want accessing control of DbContextTransaction class. 
    /// Because we can't write unit test for BeginTransaction.
    /// DbContextTransaction does not have public constructors.
    /// </summary>
    public class DbContextTransactionProxy : IDbContextTransactionProxy
    {
        /// <summary>
        /// Real Class which we want to control.
        /// We can't mock it's because it does not have public constructors.
        /// </summary>
        private readonly DbContextTransaction _transaction;

        public DbContextTransactionProxy(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }

    public class DbContextUnitOfWork : IUnitOfWork
    {
        //private int _brandId = 0;

        public DbContext Context { get; set; }

        public string ConnectionString
        {
            get { return Context.Database.Connection.ConnectionString; }
            set { Context.Database.Connection.ConnectionString = value; }
        }

        public bool LazyLoadingEnabled { get; set; }

        public bool ProxyCreationEnabled { get; set; }

        public DbContextUnitOfWork()
        {         
            Context = new CasptoneProjectContext();
        }

        public ICollection<ValidationResult> SaveChanges()
        {
            var validationResults = new List<ValidationResult>();
            try
            {
                //SetBrandIdToEntries();
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbe)
            {
                foreach (DbEntityValidationResult validation in dbe.EntityValidationErrors)
                {
                    ICollection<ValidationResult> validations = validation.ValidationErrors.Select(
                        error => new ValidationResult(
                                     error.ErrorMessage,
                                     new[]
                                         {
                                             error.PropertyName
                                         })).ToList();

                    validationResults.AddRange(validations);

                    return validationResults;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("The records you attempted to edit or delete"
                                               + " were modified by another user after you got the original value. The"
                                               + " operation was canceled.", ex);
            }
            catch (DataException ex)
            {
                throw new DataException("Unable to save changes.", ex);
            }
            return validationResults;
        }

        public async Task<ICollection<ValidationResult>> SaveChangesAsync()
        {
            var validationResults = new List<ValidationResult>();
            try
            {
              //  SetBrandIdToEntries();
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbe)
            {
                foreach (DbEntityValidationResult validation in dbe.EntityValidationErrors)
                {
                    ICollection<ValidationResult> validations = validation.ValidationErrors.Select(
                        error => new ValidationResult(
                                     error.ErrorMessage,
                                     new[]
                                         {
                                             error.PropertyName
                                         })).ToList();

                    validationResults.AddRange(validations);

                    return validationResults;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var databaseValues = ex.Entries.Select(e => e.GetDatabaseValues()).ToList();
                throw new ConcurrencyException("The records you attempted to edit or delete"
                                               + " were modified by another user after you got the original value. The"
                                               + " operation was canceled.", databaseValues, ex);
            }
            catch (Exception ex)
            {
                throw new DataException("Unable to save changes.", ex);
            }
            return validationResults;
        }

        /// <summary>
        /// When we call begin transaction. Our proxy creates new Database.BeginTransaction and gives DbContextTransaction's control to proxy.
        /// We do this for unit test.
        /// </summary>
        /// <returns>Proxy which controls DbContextTransaction(Ef transaction class)</returns>
        public IDbContextTransactionProxy BeginTransaction()
        {
            return new DbContextTransactionProxy(this.Context);
        }

        public void Dispose()
        {
            if (Context.Database.Connection.State == ConnectionState.Open)
            {
                Context.Database.Connection.Close();
            }
            Context.Dispose();
            GC.WaitForPendingFinalizers();
        }

        //private void SetBrandIdToEntries()
        //{
        //    var affectedEntries = GetCreatedEntries();
        //    affectedEntries = affectedEntries.Concat(GetModifiedEntries());

        //    if (affectedEntries.Any())
        //    {
        //        foreach (var affectedEntrie in affectedEntries)
        //        {
        //           // var brandedEntry = affectedEntrie.Entity as IBrand;
        //            if (brandedEntry != null)
        //                brandedEntry.BrandId = _brandId;
        //        }
        //    }
        //}

        private IEnumerable<DbEntityEntry> GetCreatedEntries()
        {
            var createdEntries = Context.ChangeTracker.Entries().Where(V =>
                         EntityState.Added.HasFlag(V.State)
                    );
            return createdEntries;
        }

        private IEnumerable<DbEntityEntry> GetModifiedEntries()
        {
            var modifiedEntries = Context.ChangeTracker.Entries().Where(V =>
                         EntityState.Modified.HasFlag(V.State)
                    );
            return modifiedEntries;
        }
    }

    public class ParameterDefinition
    {
        public ParameterDefinition(string name, object value, DbType? dbType = null, ParameterDirection? direction = null)
        {
            Name = name;
            DatabaseType = dbType;
            Direction = direction ?? ParameterDirection.Input;
            Value = value;
        }

        public string Name { get; set; }
        public DbType? DatabaseType { get; set; }
        public ParameterDirection Direction { get; set; }
        public object Value { get; set; }
    }

    public abstract class DbContextRepository : IRepository
    {
        public IUnitOfWork UnitOfWork { get; set; }

        protected virtual async Task<Tuple<IEnumerable<TEntity>, int>> QueryStoredProcedureAsync<TEntity>(string storedProcedureName, IEnumerable<ParameterDefinition> parameterDefinitions) where TEntity : class
        {
            var returnParamName = "spReturn";
            var sqlParameters = new List<SqlParameter>();
            var sb = new StringBuilder($"EXEC @{returnParamName} = {storedProcedureName}");
            var seperator = new char[] { ' ', ',' };
            bool useComma = false;
            foreach (var paramDef in parameterDefinitions)
            {
                var sqlParam = new SqlParameter
                {
                    ParameterName = paramDef.Name,
                    Value = paramDef.Value,
                    Direction = paramDef.Direction
                };
                if (paramDef.DatabaseType.HasValue) sqlParam.DbType = paramDef.DatabaseType.Value;

                sb.Append($"{(useComma ? seperator[1] : seperator[0])}@{paramDef.Name}{(paramDef.Direction == System.Data.ParameterDirection.Output ? " OUT" : "")}");
                sqlParameters.Add(sqlParam);
                useComma = true;
            }
            var returnParam = new SqlParameter
            {
                ParameterName = returnParamName,
                DbType = DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };
            sqlParameters.Add(returnParam);

            var results = await UnitOfWork.Context.Database.SqlQuery<TEntity>(sb.ToString(), sqlParameters.ToArray()).ToListAsync();

            return new Tuple<IEnumerable<TEntity>, int>(results, (int)returnParam.Value);
        }
    }

    public abstract class DbContextRepository<TEntity> : DbContextRepository, IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbset;
        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbset == null)
                {
                    _dbset = UnitOfWork.Context.Set<TEntity>();
                }
                return _dbset;
            }
        }

        protected virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public virtual IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(null, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            return GetQueryable(filter, null, includeProperties).SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            return await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public virtual TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).Count();
        }

        public virtual Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).CountAsync();
        }

        public virtual bool GetExists(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).Any();
        }

        public virtual Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return GetQueryable(filter).AnyAsync();
        }

        public void Create(TEntity entity, string createdBy = null)
        {
            //entity.UpdatedDate = DateTime.UtcNow;
            //entity.UpdatedBy = createdBy;
            //entity.CreatedDate = DateTime.UtcNow;
            //entity.CreatedBy = createdBy;
            DbSet.Add(entity);
        }

        public virtual void Delete(object id, string modifiedBy = null)
        {
            var entity = DbSet.Find(id);
            Delete(entity, modifiedBy);
        }

        public virtual void Delete(TEntity entity, string modifiedBy = null)
        {
            if (UnitOfWork.Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            //entity.UpdatedDate = DateTime.UtcNow;
            //entity.UpdatedBy = modifiedBy;
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> filter, string modifiedBy = null)
        {
            var objects = GetQueryable(filter);
            foreach (var obj in objects)
            {
                Delete(obj, modifiedBy);
            }
        }

        public virtual void Update(TEntity entity, string modifiedBy = null)
        {
            //entity.UpdatedDate = DateTime.UtcNow;
            //entity.UpdatedBy = modifiedBy;
            if (UnitOfWork.Context.Entry(entity).State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
            UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(TEntity entity, string[] fieldsToUpdate, string modifiedBy = null)
        {
            //entity.UpdatedDate = DateTime.UtcNow;
            //entity.UpdatedBy = modifiedBy;

            this.DbSet.Attach(entity);
            var dbEntityEntry = UnitOfWork.Context.Entry(entity);
            var dbProperties = dbEntityEntry.GetDatabaseValues();
            foreach (var property in dbEntityEntry.OriginalValues.PropertyNames.Where(p => !p.Equals("RecordVersion", StringComparison.InvariantCultureIgnoreCase)))
            {
                var original = dbProperties.GetValue<object>(property);
                var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                if (fieldsToUpdate.Contains(property) && (original == null && current != null || original != null && current == null || original != null && current != null) && ((original != null && !original.Equals(current)) || (current != null && !current.Equals(original))))
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
                else
                {
                    dbEntityEntry.Property(property).OriginalValue = dbEntityEntry.Property(property).CurrentValue = original;
                    dbEntityEntry.Property(property).IsModified = false;
                }
            }
        }
    }

    public partial interface IRepositoryHelper
    {
        //IDatabaseConnectionSettings ConnectionSettings { get; set; }
        //IBrandContext BrandContext { get; set; }
        IUnitOfWork GetUnitOfWork();
        TRepository GetRepository<TRepository>(IUnitOfWork unitOfWork)
            where TRepository : class;
    }
    public partial class RepositoryHelper : IRepositoryHelper
    {
        //public IDatabaseConnectionSettings ConnectionSettings { get; set; }
       // public IBrandContext BrandContext { get; set; }

        public RepositoryHelper()
        {
        }

        public IUnitOfWork GetUnitOfWork()
        {
            var unitOfWork = new DbContextUnitOfWork();
            return unitOfWork;
        }


        public TRepository GetRepository<TRepository>(IUnitOfWork unitOfWork)
            where TRepository : class

        {
            if (typeof(TRepository) == typeof(IContactRepository))
            {
                dynamic repo = new ContactRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            
           
            TRepository repository = null;
            TryGetRepositoryPartial<TRepository>(unitOfWork, ref repository);
            return repository;
        }

        partial void TryGetRepositoryPartial<TRepository>(IUnitOfWork unitOfWork, ref TRepository repository)
            where TRepository : class;
    }
}
