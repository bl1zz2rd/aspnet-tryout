using Microsoft.AspNetCore.Mvc;

namespace MultitenantProj.Web.Controllers
{
    public class AboutController : MultitenantProjControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}