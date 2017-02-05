using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using MultitenantProj.Authorization.Roles;
using MultitenantProj.Configuration;
using MultitenantProj.MultiTenancy;
using MultitenantProj.Users;
using MultitenantProj.Web;

namespace MultitenantProj.EntityFramework
{
    [DbConfigurationType(typeof(MultitenantProjDbConfiguration))]
    public class MultitenantProjDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        /* Default constructor is needed for EF command line tool. */
        public MultitenantProjDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                MultitenantProjConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of MultitenantProjDbContext since ABP automatically handles it.
         */
        public MultitenantProjDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public MultitenantProjDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public MultitenantProjDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    public class MultitenantProjDbConfiguration : DbConfiguration
    {
        public MultitenantProjDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
