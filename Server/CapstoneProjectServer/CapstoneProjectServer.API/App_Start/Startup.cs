using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Cors;
using System.Linq;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(CapstoneProjectServer.API.App_Start.Startup))]

namespace CapstoneProjectServer.API.App_Start
{
    public class Startup
    {
        private String _allowedOrigins = "*";
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureCORS(app);
        }
        private void ConfigureCORS(IAppBuilder app)
        {
            //CORS
            app.UseCors(new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = CreateCorsPolicy
                }
            });
        }
        private async Task<CorsPolicy> CreateCorsPolicy(IOwinRequest request)
        {
            if (string.IsNullOrEmpty(_allowedOrigins))
                return new CorsPolicy
                {
                    AllowAnyHeader = false,
                    AllowAnyMethod = false,
                    SupportsCredentials = true
                };
            var allowedOrigins = _allowedOrigins.Split(',').ToList();
            var policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true
            };
            foreach (var origin in allowedOrigins)
            {
                if (_allowedOrigins == "*")
                    return await CorsOptions.AllowAll.PolicyProvider.GetCorsPolicyAsync(request);
                var requestHeader = request.Headers["Origin"];
                if ((requestHeader == null) || ((origin != requestHeader) && !requestHeader.EndsWith($".{origin}")))
                    continue;
                policy.Origins.Add(requestHeader);
                break;
            }
            return policy;
        }

    }
}
