using System.Web;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.RequestCookies {

    /// <summary>
    ///     Interface the hides where the response cookies come from
    /// </summary>
    public interface IRequestCookies {

         HttpCookie get ( string name );

    }
}