using System.Linq;
using System.Web;
using System.Web.Routing;

public class PageRouteConstraint : IRouteConstraint
{
    public PageRouteConstraint() { }

    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values["pageName"] == null) return false;

        string pageName = "" + values["pageName"];
        var pages = new UnitOfWork().AliasRepository.Get(x => x.Url == pageName);

        if(pages.Count() == 1)
        {
            values.Add("pageId", pages.First().PageId);
            return true;
        }
        else
        {
            return false;
        }        
    }
}