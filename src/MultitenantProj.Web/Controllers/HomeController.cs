using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultitenantProj.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MultitenantProjControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}