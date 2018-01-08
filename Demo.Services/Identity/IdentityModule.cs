using Autofac;
using Microsoft.AspNetCore.Identity;

namespace Demo.Services.Identity
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserStore>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<UserStore>().As<IUserPasswordStore<ApplicationUser>>();
            builder.RegisterType<UserStore>().As<IUserRoleStore<ApplicationUser>>();
            builder.RegisterType<UserStore>().As<IUserEmailStore<ApplicationUser>>();
            builder.RegisterType<UserStore>().As<IUserPhoneNumberStore<ApplicationUser>>();
            builder.RegisterType<RoleStore>().As<IRoleStore<ApplicationRole>>();
        }
    }
}
