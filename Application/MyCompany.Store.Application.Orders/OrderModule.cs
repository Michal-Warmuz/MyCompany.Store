using Autofac;

namespace MyCompany.Store.Application.Orders
{
    public class OrderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("CommandHandler"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
