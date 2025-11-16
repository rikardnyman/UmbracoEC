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

    public class QuestionController : SurfaceController
    {
        private readonly FormSubmissionsService _formSubmissions;

        public QuestionController(
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
        public IActionResult HandleQuestionForm(QuestionFormViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var result = _formSubmissions.SaveQuestionRequest(model);

            if (!result)
            {
                TempData["FormError"] = "Could not save your question.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Your question has been submitted!";
            return RedirectToCurrentUmbracoPage();
        }
    }
}
