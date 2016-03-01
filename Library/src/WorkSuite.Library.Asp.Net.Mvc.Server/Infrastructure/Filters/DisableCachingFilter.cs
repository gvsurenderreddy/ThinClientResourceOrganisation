using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Filters {

    public class DisableCachingFilter: IResultFilter  {

        public void OnResultExecuting ( ResultExecutingContext filterContext ) {
            // do nothing;
        }

        public void OnResultExecuted ( ResultExecutedContext filterContext ) {
            
            // source = http://stackoverflow.com/questions/49547/making-sure-a-web-page-is-not-cached-across-all-browsers/2068407#2068407

            var response = filterContext
                            .HttpContext
                            .Response
                            ;
            
            response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            response.AppendHeader("Expires", "0"); // Proxies.

        }
    }
}