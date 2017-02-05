using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace MultitenantProj.Web.Controllers
{
    public abstract class MultitenantProjControllerBase: AbpController
    {
        protected MultitenantProjControllerBase()
        {
            LocalizationSourceName = MultitenantProjConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}