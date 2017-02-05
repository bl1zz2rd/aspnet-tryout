using Abp.Authorization;
using MultitenantProj.Authorization.Roles;
using MultitenantProj.MultiTenancy;
using MultitenantProj.Users;

namespace MultitenantProj.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
