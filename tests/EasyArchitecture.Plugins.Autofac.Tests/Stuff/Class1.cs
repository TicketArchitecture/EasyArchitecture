using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace EasyArchitecture.Plugins.Autofac.Tests.Stuff
//{
//    public class WebModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            base.Load(builder);

//            builder.RegisterInstance(new MyDbContext("DefaultDb")).As<MyDbContext>().SingleInstance();

//            builder.RegisterType<CategoryRepository>().AsImplementedInterfaces();
//            builder.RegisterType<ItemRepository>().AsImplementedInterfaces();
//            builder.RegisterType<UserRepository>().AsImplementedInterfaces();

//            builder.RegisterType<ItemCreatingPersistence>().AsImplementedInterfaces().SingleInstance();
//            builder.RegisterType<ItemDeletingPersistence>().AsImplementedInterfaces().SingleInstance();
//            builder.RegisterType<ItemEditingPersistence>().AsImplementedInterfaces().SingleInstance();

//            builder.RegisterType<ExConfigurationManager>().AsImplementedInterfaces().SingleInstance();
//            builder.RegisterType<MediaItemStorage>().AsImplementedInterfaces().SingleInstance();

//            AutoMapperConfiguration.Configure();
//        }
//    }
//}
