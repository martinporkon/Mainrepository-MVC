/*using Autofac;
using MediatR;
using WebMVC.Bff.HttpAggregator.Gateway.Infrastructure;

namespace WebMVC.Bff.HttpAggregator.Gateway.Modules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.RegisterAssemblyTypes(typeof(GetUserBasketsQuery).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));#1#
            builder.RegisterGeneric(typeof(UserIdPipe<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}*/