using Demo.Services.Identity;
using Autofac;
using Demo.Database;
using AutoMapper;
using Demo.Infrastructure;

namespace Demo.Web
{
    public class Launch : IStartable
    {
        private readonly IConfig _config;

        public Launch(IConfig config)
        {
            _config = config;
        }
        public void Start()
        {
            // Create Database
            DatabaseCreator.Create(_config.MasterConnectionString, _config.AppConnectionString);

            // Apply Migrations
            DatabaseMigrator.Migrate(_config.AppConnectionString);

            // Setup Automapper
            Mapper.Initialize(x =>
            {
                x.AddProfile<Mappings>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
