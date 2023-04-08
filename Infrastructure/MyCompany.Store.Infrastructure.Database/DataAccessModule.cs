using Autofac;
using Microsoft.EntityFrameworkCore;
using MyCompany.Store.Application.Shared.Data;
using MyCompany.Store.Infrastructure.Database.SeedWork;

namespace MyCompany.Store.Infrastructure.Database
{
    public class DataAccessModule : Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }


        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SqlConnectionFactory>()
                    .As<ISqlConnectionFactory>()
                    .WithParameter("connectionString", _databaseConnectionString)
                    .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            builder
            .Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                return new ApplicationDbContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
