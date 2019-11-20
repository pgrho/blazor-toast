using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shipwreck.BlazorJqueryToast.Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }

        public void Configure(IComponentsApplicationBuilder componentsApplicationBuilder)
            => componentsApplicationBuilder.AddComponent<App>("app");
    }
}
