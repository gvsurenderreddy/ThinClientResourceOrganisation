using System.Web;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.ResponseCookies;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers {
    internal class FakeResponseCookies : IResponseCookies {

        public void add ( HttpCookie cookie ) {
            cookies.Add( cookie );
        }

        public HttpCookieCollection cookies { get; private set; }

        public FakeResponseCookies () {
            cookies = new HttpCookieCollection();
        }
    }
}