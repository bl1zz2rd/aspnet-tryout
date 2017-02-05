using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MultitenantProj.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MultitenantProj.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MultitenantProj.EntityFramework.MultitenantProjDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MultitenantProj";
        }

        protected override void Seed(MultitenantProj.EntityFramework.MultitenantProjDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
