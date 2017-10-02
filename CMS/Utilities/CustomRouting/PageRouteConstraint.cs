using System;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;

public class PageRouteConstraint : IRouteConstraint
{
    public PageRouteConstraint() { }

    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values["pageName"] == null) return false;

        string pageName = "" + values["pageName"];

        //Check if pagename is a guid, if so... get page with that guid
        Guid pageId = Guid.Empty;
        bool isGuid = Guid.TryParse(pageName, out pageId);

        if (isGuid)
        {
            //IF its a guid, we still need to check if the page exists and if it's publicly visible (isPublished = 1)
            var page = new UnitOfWork().PageRepository.GetByID(pageId);
            if(page != null && page.IsPublished)
            {
                values.Add("pageId", page.Id);
                return true;
            }
        }
        else
        {
            var aliases = new UnitOfWork().AliasRepository.Get(x => x.Url == pageName && x.Page.IsPublished);
            if (aliases.Count() == 1)
            {
                var alias = aliases.Single();
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(alias.LanguageCode);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

                values.Add("pageId", alias.PageId);
                return true;
            }
        }
       
        return false;        
    }
}