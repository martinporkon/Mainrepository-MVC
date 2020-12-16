using System;
using Microsoft.AspNetCore.Http;

namespace WebMVC.Bff.HttpAggregator.Gateway.Configuration
{
    public class DoSomething : IMiddlewareFactory
    {
        public DoSomething()// TODO
        {

        }

        public IMiddleware Create(Type middlewareType)
        {
            throw new NotImplementedException();
        }

        public void Release(IMiddleware middleware)
        {
            throw new NotImplementedException();
        }
    }
}