using MultitenantProj.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MultitenantProj.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MultitenantProjDbContext _context;

        public InitialHostDbBuilder(MultitenantProjDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
