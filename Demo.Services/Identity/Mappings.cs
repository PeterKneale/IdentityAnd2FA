using AutoMapper;
using Demo.Data.Sources;

namespace Demo.Services.Identity
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<UserData, ApplicationUser>();
            CreateMap<ApplicationUser, UserData>();
        }
    }
}
