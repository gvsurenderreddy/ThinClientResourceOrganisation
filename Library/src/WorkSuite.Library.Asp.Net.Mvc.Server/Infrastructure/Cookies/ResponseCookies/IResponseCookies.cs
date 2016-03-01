using System.Web;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.ResponseCookies {

    /// <summary>
    ///     Interface the hides where the response cookies come from
    /// </summary>
    public interface IResponseCookies {

        void add ( HttpCookie cookie );

    }
}