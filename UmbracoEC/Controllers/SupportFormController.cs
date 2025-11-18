using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoEC.Services;
using UmbracoEC.ViewModels;

namespace UmbracoEC.Controllers
{

    public class SupportController : SurfaceController
    {
        private readonly FormSubmissionsService _formSubmissions;

        public SupportController(
            IUmbracoContextAccessor ctx,
            IUmbracoDatabaseFactory db,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profiler,
            IPublishedUrlProvider urls,
            FormSubmissionsService formSubmissions)
            : base(ctx, db, services, appCaches, profiler, urls)
        {
            _formSubmissions = formSubmissions;
        }

        [HttpPost]
        public IActionResult HandleSupportForm(SupportFormViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var result = _formSubmissions.SaveSupportRequest(model);

            if (!result)
            {
                TempData["FormError"] = "Could not send your request.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you, we'll get back to you shortly!";
            return RedirectToCurrentUmbracoPage();
        }
    }
}
