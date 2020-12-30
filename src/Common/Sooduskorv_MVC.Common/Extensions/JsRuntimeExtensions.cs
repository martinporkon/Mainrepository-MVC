using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Sooduskorv_MVC.Common.Extensions
{
    public class JsRuntimeExtensions : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsRuntimeExtensions()
        {

        }

        public ValueTask<bool> Confirm(IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);// javascript required.
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}