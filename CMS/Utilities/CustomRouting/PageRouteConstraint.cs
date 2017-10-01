using System.Linq;
using System.Web;
using System.Web.Routing;

public class PageRouteConstraint : IRouteConstraint
{
    public PageRouteConstraint() { }

    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    {
        var pages = new UnitOfWork().AliasRepository.Get(x => x.Url == values["pageName"].ToString());

        if(pages.Count() == 1)
        {
            values.Add("pageId", pages.First().Id);
            return true;
        }
        else
        {
            return false;
        }        
    }
}