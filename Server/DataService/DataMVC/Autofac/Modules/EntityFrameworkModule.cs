using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataMVC.Autofac.Modules
{
    public sealed class EntityFrameworkModule
    {
        private Assembly assembly;

        private Type dbContextType;

        public EntityFrameworkModule(Assembly assembly, Type dbContextType)
        {
            this.assembly = assembly;
            this.dbContextType = dbContextType;
        }

        protected void Load(ContainerBuilder builder)
        {
            //IL_0000: Unknown result type (might be due to invalid IL or missing references)
            //IL_000c: Unknown result type (might be due to invalid IL or missing references)
            //IL_0012: Unknown result type (might be due to invalid IL or missing references)
            //IL_0019: Unknown result type (might be due to invalid IL or missing references)
            //IL_0031: Unknown result type (might be due to invalid IL or missing references)
            //IL_003c: Unknown result type (might be due to invalid IL or missing references)
            //IL_0042: Unknown result type (might be due to invalid IL or missing references)
            //IL_004d: Unknown result type (might be due to invalid IL or missing references)
            //IL_0065: Unknown result type (might be due to invalid IL or missing references)
            //IL_0070: Unknown result type (might be due to invalid IL or missing references)
            ModuleRegistrationExtensions.RegisterModule(builder, new RepositoryModule(this.assembly));
            RegistrationExtensions.InstancePerRequest<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(RegistrationExtensions.RegisterType(builder, this.dbContextType).As(new Type[1]
            {
            typeof(DbContext)
            }), new object[0]);
            RegistrationExtensions.InstancePerRequest<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(RegistrationExtensions.RegisterType(builder, typeof(UnitOfWork)).As(new Type[1]
            {
            typeof(IUnitOfWork)
            }), new object[0]);
        }
    }
}
