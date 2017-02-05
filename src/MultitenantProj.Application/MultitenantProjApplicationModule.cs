using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using MultitenantProj.Authorization;

namespace MultitenantProj
{
    [DependsOn(
        typeof(MultitenantProjCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MultitenantProjApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MultitenantProjAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}