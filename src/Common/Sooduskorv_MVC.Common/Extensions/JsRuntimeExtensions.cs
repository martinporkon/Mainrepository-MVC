using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Sooduskorv_MVC.Common.Extensions
{
    public class JsRuntimeExtensions : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public JsRuntimeExtensions(Lazy<Task<IJSObjectReference>> moduleTask)
        {
            this._moduleTask = moduleTask;
        }

        public ValueTask<bool> Confirm(IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);// javascript required.
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}