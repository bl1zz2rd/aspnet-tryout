using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MultitenantProj.Configuration;

namespace MultitenantProj.Web.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }
    }
}