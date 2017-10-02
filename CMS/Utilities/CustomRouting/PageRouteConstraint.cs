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
        try
        {
            if (values["pageName"] == null) return false;

            string pageName = "" + values["pageName"];

            //We also want an easy way to preview pages in languages (i.e. /xx-XX/GUID)
            string[] parts = pageName.Split(new char[] { '/' });
            if (parts.Length == 2)
            {
                Guid pageId = Guid.Empty;
                bool isGuid = Guid.TryParse(parts[1], out pageId);

                if (isGuid)
                {
                    //IF its a guid, we still need to check if the page exists and if it's publicly visible (isPublished = 1)
                    var page = new UnitOfWork().PageRepository.GetByID(pageId);
                    if (page != null && page.IsPublished)
                    {
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(parts[0]);
                        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

                        values.Add("pageId", page.Id);
                        return true;
                    }
                }
            }

            //Link was not in format of (xx-XX/GUID) - see if we can find an alias
            var aliases = new UnitOfWork().AliasRepository.Get(x => x.Url == pageName && x.Page.IsPublished);
            if (aliases.Count() == 1)
            {
                var alias = aliases.Single();

                if(alias.LanguageCode != null && !string.IsNullOrWhiteSpace(alias.LanguageCode))
                { 
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(alias.LanguageCode);
                    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                }

                values.Add("pageId", alias.PageId);
                return true;
            }

            //NO MATCH found, try other routes
            return false;
        }
        catch (Exception ex)
        {
            //Something went wrong somewhere... route fails 
            return false;
        }
    }
}