using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Shipwreck.BlazorJqueryToast
{
    public static class ToastExtensions
    {
        public static ValueTask ShowToastAsync(this IJSRuntime js, ToastOptions options)
            => js.InvokeVoidAsync("Shipwreck.blazorJqueryToast", options.ToString());
    }
}
