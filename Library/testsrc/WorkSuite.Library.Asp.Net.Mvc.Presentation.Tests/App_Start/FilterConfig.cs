using System.Web;
using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}