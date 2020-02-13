using AdvancedWf.DTO;
using AdvancedWf.Service;
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IGadgetService gadgetService;

        public HomeController(ICategoryService categoryService, IGadgetService gadgetService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
 
            var viewModelGadgets = categoryService.GetCategories(category).ToList();

             return View(viewModelGadgets);
        }

        public ActionResult Filter(string category, string gadgetName)
        {
  
          var viewModelGadgets = gadgetService.GetCategoryGadgets(category, gadgetName);

 
            return View(viewModelGadgets);
        }

        [HttpPost]
        public ActionResult Create(GadgetFormViewModel newGadget)
        {
            if (newGadget != null && newGadget.File != null)
            {
                 gadgetService.CreateGadget(newGadget);

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

                gadgetService.SaveGadget();
            }

            var category = categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }
    }
}