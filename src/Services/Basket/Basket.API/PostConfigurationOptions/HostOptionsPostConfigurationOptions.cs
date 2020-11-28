using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Basket.API.PostConfigurationOptions
{
    public class HostOptionsPostConfigurationOptions : IPostConfigureOptions<HostOptions>
    {
        public void PostConfigure(string name, HostOptions options)
        {
            options.ShutdownTimeout = TimeSpan.FromSeconds(60);// TODO exceptions
        }
    }
}