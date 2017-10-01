using CMS.Models;
using CMS.Utilities.Mapping;
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

            var model = new PageModel()
            {
                Name = page.Name,
                Blocks = Mapper.Map(page.Blocks)
            };

            return View("TextPage", model);
        }
    }
}