using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace MultitenantProj.EntityFramework
{
    [DependsOn(
        typeof(MultitenantProjCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class MultitenantProjEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MultitenantProjDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}