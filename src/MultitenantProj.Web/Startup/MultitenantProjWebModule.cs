using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using MultitenantProj.Configuration;
using MultitenantProj.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;

namespace MultitenantProj.Web.Startup
{
    [DependsOn(
        typeof(MultitenantProjApplicationModule), 
        typeof(MultitenantProjEntityFrameworkModule), 
        typeof(AbpAspNetCoreModule))]
    public class MultitenantProjWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MultitenantProjWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MultitenantProjConsts.ConnectionStringName);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<MultitenantProjNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MultitenantProjApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}