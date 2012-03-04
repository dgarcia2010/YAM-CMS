using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyCMS.Web.Models;
using MyCMS.Domain.Contracts.Infrastructure;
using MyCMS.Domain.Contracts;

namespace MyCMS.Web.Controllers
{
    [ActionFilters.ActivityLog]
    public class HomeController : ControllerBase
    {
        private IArticleDataService ArticleManager { get; set; }

        private IMenuDataService MenuManager { get; set; }

        public HomeController(ILoggingService logger, IArticleDataService articleManager, IMenuDataService menuService)
            : base(logger)
        {
            ArticleManager = articleManager;
            MenuManager = menuService;
        }

        public ActionResult Index()
        {
            var model = new ShowArticleViewModel(
                ArticleManager.GetNewest(),
                MenuManager.GetItemsForColumn("middle"),
                MenuManager.GetItemsForColumn("right"));

            model.MiddleColumnItems.Insert(0, MenuManager.LatestArticles(10));  //TODO: oooops!! magic number!

            return View(model);
        }

    }
}
