using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using MultitenantProj.Configuration;
using MultitenantProj.EntityFramework;

namespace MultitenantProj.Migrator
{
    [DependsOn(typeof(MultitenantProjEntityFrameworkModule))]
    public class MultitenantProjMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MultitenantProjMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(MultitenantProjMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<MultitenantProjDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MultitenantProjConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}