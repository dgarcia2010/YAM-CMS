using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyCMS.Domain.Contracts.Infrastructure;
using MyCMS.Domain.Contracts;

namespace MyCMS.Web.Controllers
{
    [ActionFilters.ActivityLog]
    public class HomeController : ControllerBase
    {
        private IArticleDataService ArticleManager { get; set; }

        public HomeController(ILoggingService logger, IArticleDataService articleManager)
            : base(logger)
        {
            ArticleManager = articleManager;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            //var x = ArticleManager.Get(null, null, "");

            return View(ArticleManager.GetNewest());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
