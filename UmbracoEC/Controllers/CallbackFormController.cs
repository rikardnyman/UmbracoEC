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
    public class CallbackController : SurfaceController
    {
        private readonly FormSubmissionsService _formSubmissions;

        public CallbackController(
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

        public IActionResult HandleCallbackForm(CallbackFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissions.SaveCallbackRequest(model);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong while submitting your request. Please try again later.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you! Your request has been received and we will get back to you soon";
            return RedirectToCurrentUmbracoPage();
        }


    }


}
