using CMS.Models.CMS;
using CMS.Utilities.ViewRendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Find page with no parent page, this is the root... and should be the homepage
            var homepage = new UnitOfWork().PageRepository.Get(x => x.ParentPageId == null).Single();

            var rootBlockModels = new List<BlockModel>();
            rootBlockModels = TreeBuilder.BuildBlockTree(homepage.Blocks);

            var model = new PageModel() { Name = homepage.Name, RootBlocks = rootBlockModels };

            return View("TextPage", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}