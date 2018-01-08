using Autofac;

namespace Demo.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterType<Launch>()
               .As<IStartable>()
               .SingleInstance();
        }
    }
}
