using Abp.AspNetCore.Mvc.Authorization;
using MultitenantProj.Authorization;
using MultitenantProj.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace MultitenantProj.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : MultitenantProjControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}