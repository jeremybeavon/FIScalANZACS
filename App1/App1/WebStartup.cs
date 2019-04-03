using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProxyKit;
using System.Collections.Generic;

namespace App1
{
    public sealed class WebStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddProxy();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.RunProxy(async context =>
            {
                var response = await context
                    .ForwardTo("https://integrity-betasite.fnfis.com")
                    .Send();
                response.Headers.Remove("Content-Security-Policy");
                return response;
            });
        }
    }
}

