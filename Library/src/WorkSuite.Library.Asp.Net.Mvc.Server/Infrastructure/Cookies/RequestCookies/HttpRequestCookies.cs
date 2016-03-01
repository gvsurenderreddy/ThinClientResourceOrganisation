using System.Web;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.RequestCookies {

    /// <summary>
    ///     <see cref="HttpContext"/> implementation that uses the 
    /// request property of the <see cref="IRequestCookies"/>
    /// </summary>
    public class HttpRequestCookies 
                    : IRequestCookies {


        /// <inheritdoc/>
        public HttpCookie get 
                            ( string name ) {

            return HttpContext.Current.Request.Cookies[ name ];
        }

    }
}