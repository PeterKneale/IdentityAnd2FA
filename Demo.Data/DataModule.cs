using Autofac;
using Demo.Data;
using Demo.Data.Sources;

namespace Demo.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.Register(x => x.Resolve<IUnitOfWorkFactory>().Create()).As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<UserDataSource>().As<IUserDataSource>().InstancePerLifetimeScope();
        }
    }
}