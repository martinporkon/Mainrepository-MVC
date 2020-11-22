using Autofac;
using MediatR;
using WebMVC.HttpAggregator.Gateway.Infrastructure;

namespace WebMVC.HttpAggregator.Gateway.Modules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.RegisterAssemblyTypes(typeof(GetUserBasketsQuery).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));*/
            builder.RegisterGeneric(typeof(UserIdPipe<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}