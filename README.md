# Shipwreck.BlazorJqueryToast

Blazor wrapper for [Jquery Toast Plugin](https://github.com/kamranahmedse/jquery-toast-plugin)

## Usage

1. Reference [Shipwreck.BlazorJqueryToast](https://www.nuget.org/packages/Shipwreck.BlazorJqueryToast/) from nuget.org
2. Add `<script>` reference for jQuery in your Blazor HTML. (Jquery Toast Plugin is embedded in the package.)

```csharp
// using Shipwreck.BlazorJqueryToast;
// IJSRuntime js;
js.ShowToastAsync(new ToastOptions
{
    Text = "text or HTML"
});
```