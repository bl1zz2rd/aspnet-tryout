using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using MultitenantProj.Authorization;
using MultitenantProj.Users;
using Microsoft.AspNetCore.Mvc;

namespace MultitenantProj.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : MultitenantProjControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}