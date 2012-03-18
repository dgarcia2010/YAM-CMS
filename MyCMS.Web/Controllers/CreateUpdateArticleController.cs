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
    [Authorize]
    public class CreateUpdateArticleController : ControllerBase
    {

        private IArticleDataService ArticleManager { get; set; }

        private IMenuDataService MenuManager { get; set; }

        public CreateUpdateArticleController(ILoggingService logger, IArticleDataService articleManager, IMenuDataService menuService)
            : base(logger)
        {
            ArticleManager = articleManager;
            MenuManager = menuService;
        }

        //
        // GET: /CreateUpdateArticle/

        public ActionResult Index()
        {

            var model = new CreateArticleViewModel(
                MenuManager.GetItemsForColumn("middle"),
                MenuManager.GetItemsForColumn("right"));

            model.MiddleColumnItems.Insert(0, MenuManager.LatestArticles(10));  //TODO: oooops!! magic number!
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(CreateArticleViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.SubmitButton == "Guardar y publicar")
                {
                    var a = ArticleManager.SaveAndPublish(model.Title, model.Body, model.Rewrite);
                    return RedirectToAction("Index", "Home");       //TODO: debe sredirigir al artículo recien creado ¿ya lo hace?
                }
                else if (model.SubmitButton == "Guardar como borrador")
                {
                    var a = ArticleManager.Save(model.Title, model.Body, model.Rewrite);
                    return RedirectToAction("Index", "Home");       //TODO: ¿donde deberia redirigir?
                }
                else if (model.SubmitButton == "Descartar")
                {
                    return RedirectToAction("Index", "Home");   //TODO: ¿donde deberia redirigir?
                }
                else
                {
                    ModelState.AddModelError("SubmitButton", "La descripción del botón pulsado es incorrecta");
                }
            }

            model.MiddleColumnItems = MenuManager.GetItemsForColumn("middle");
            model.RightColumnItems = MenuManager.GetItemsForColumn("right");
            model.MiddleColumnItems.Insert(0, MenuManager.LatestArticles(10));  //TODO: oooops!! magic number!
            return View(model);
        }

        public ActionResult Update()
        {

            return View();
        }

    }
}
