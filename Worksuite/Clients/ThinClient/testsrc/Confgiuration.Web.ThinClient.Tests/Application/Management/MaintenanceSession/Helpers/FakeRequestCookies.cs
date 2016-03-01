using System.Web;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.RequestCookies;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers {
    internal class FakeRequestCookies  
        : IRequestCookies {

        public HttpCookie get 
            ( string name ) {

            return cookies[ name ];            
        }

        public HttpCookieCollection cookies { get; private set; }

        public FakeRequestCookies ( ) {
            
            cookies = new HttpCookieCollection();
        }
    }
}