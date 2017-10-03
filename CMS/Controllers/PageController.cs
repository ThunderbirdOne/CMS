using CMS.Data.EF.Entities;
using CMS.Models.CMS;
using CMS.Utilities.Mapping;
using CMS.Utilities.ViewRendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Render(Guid pageId)
        {
            var page = new UnitOfWork().PageRepository.Get(x => x.Id == pageId).Single();

            var rootBlockModels = new List<BlockModel>();
            rootBlockModels = TreeBuilder.BuildBlockTree(page.Blocks);

            var model = new PageModel() { Name = page.Name, RootBlocks = rootBlockModels };

            return View("TextPage", model);
        }
    }
}