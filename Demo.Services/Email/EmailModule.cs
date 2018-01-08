using Autofac;

namespace Demo.Services.Email
{
    public class EmailModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSender>().As<IEmailSender>();
        }
    }
}
