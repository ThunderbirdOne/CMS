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
            return View();
        }
    }
}