using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Repositories;
namespace TeduShop.Data.Infrastructure
{
    public partial interface IRepositoryHelper
    {
 
        IUnitOfWork GetUnitOfWork();
        TRepository GetRepository<TRepository>(IUnitOfWork unitOfWork)
            where TRepository : class;
    }
    public partial class RepositoryHelper : IRepositoryHelper
    {
       

        public IUnitOfWork GetUnitOfWork()
        {
            var unitOfWork = new UnitOfWork();
            return unitOfWork;
        }

        public TRepository GetRepository<TRepository>(IUnitOfWork unitOfWork)
            where TRepository : class

        {
            if (typeof(TRepository) == typeof(IAnnouncementRepository))
            {
                dynamic repo = new AnnouncementRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IAnnouncementUserRepository))
            {
                dynamic repo = new AnnouncementUserRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IColorRepository))
            {
                dynamic repo = new ColorRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IContactDetailRepository))
            {
                dynamic repo = new ContactDetailRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IErrorRepository))
            {
                dynamic repo = new ErrorRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IFeedbackRepository))
            {
                dynamic repo = new FeedbackRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IFooterRepository))
            {
                dynamic repo = new FooterRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IFunctionRepository))
            {
                dynamic repo = new FunctionRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IMenuRepository))
            {
                dynamic repo = new MenuRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IOrderDetailRepository))
            {
                dynamic repo = new OrderDetailRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IOrderRepository))
            {
                dynamic repo = new OrderRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IPageRepository))
            {
                dynamic repo = new PageRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IPermissionRepository))
            {
                dynamic repo = new PermissionRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IPostCategoryRepository))
            {
                dynamic repo = new PostCategoryRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IPostTagRepository))
            {
                dynamic repo = new PostCategoryRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IProductCategoryRepository))
            {
                dynamic repo = new ProductCategoryRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IProductImageRepository))
            {
                dynamic repo = new ProductImageRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IProductQuantityRepository))
            {
                dynamic repo = new ProductQuantityRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IProductRepository))
            {
                dynamic repo = new ProductRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(IProductTagRepository))
            {
                dynamic repo = new ProductTagRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(ISizeRepository))
            {
                dynamic repo = new SizeRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(ISlideRepository))
            {
                dynamic repo = new SlideRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(ISupportOnlineRepository))
            {
                dynamic repo = new SupportOnlineRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(ISystemConfigRepository))
            {
                dynamic repo = new SystemConfigRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }

            if (typeof(TRepository) == typeof(ITagRepository))
            {
                dynamic repo = new TagRepository();
                repo.UnitOfWork = unitOfWork;
                return (TRepository)repo;
            }
            if (typeof(TRepository) == typeof(IVisitorStatisticRepository))
            {
                dynamic repo = new VisitorStatisticRepository();
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
