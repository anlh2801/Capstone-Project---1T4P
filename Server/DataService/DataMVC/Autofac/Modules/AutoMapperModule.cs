using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMVC.Autofac.Modules
{
    public class AutoMapperModule
    {
        private MapperConfiguration Config
        {
            get;
            set;
        }

        public AutoMapperModule(MapperConfiguration config)
        {
            //IL_0007: Unknown result type (might be due to invalid IL or missing references)
            this.Config = config;
        }

        protected void Load(ContainerBuilder builder)
        {
            //IL_0001: Unknown result type (might be due to invalid IL or missing references)
            //IL_0006: Unknown result type (might be due to invalid IL or missing references)
            //IL_000b: Unknown result type (might be due to invalid IL or missing references)
            //IL_000c: Unknown result type (might be due to invalid IL or missing references)
            //IL_000e: Unknown result type (might be due to invalid IL or missing references)
            //IL_0013: Unknown result type (might be due to invalid IL or missing references)
            //IL_0018: Unknown result type (might be due to invalid IL or missing references)
            //IL_001d: Unknown result type (might be due to invalid IL or missing references)
            //IL_0023: Unknown result type (might be due to invalid IL or missing references)
            //IL_0024: Unknown result type (might be due to invalid IL or missing references)
            //IL_0025: Unknown result type (might be due to invalid IL or missing references)
            //IL_002a: Unknown result type (might be due to invalid IL or missing references)
            //IL_002f: Unknown result type (might be due to invalid IL or missing references)
            IMapper val = this.Config.CreateMapper();
            RegistrationExtensions.RegisterInstance<MapperConfiguration>(builder, this.Config).As<IConfigurationProvider>().SingleInstance();
            RegistrationExtensions.RegisterInstance<IMapper>(builder, val).As<IMapper>().SingleInstance();
        }
    }
}
