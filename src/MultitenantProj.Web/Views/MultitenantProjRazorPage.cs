using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MultitenantProj.Web.Views
{
    public abstract class MultitenantProjRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MultitenantProjRazorPage()
        {
            LocalizationSourceName = MultitenantProjConsts.LocalizationSourceName;
        }
    }
}
