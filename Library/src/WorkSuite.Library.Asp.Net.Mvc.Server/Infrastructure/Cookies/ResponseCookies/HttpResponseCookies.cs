using System.Web;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.ResponseCookies {

    /// <summary>
    ///     <see cref="IResponseCookies"/> implementation that uses the 
    /// response property of the <see cref="HttpContext"/>
    /// </summary>
    public class HttpResponseCookies 
                    : IResponseCookies {

        /// <inheritdoc/>
        public void add 
                        ( HttpCookie cookie ) {
            
            HttpContext.Current.Response.Cookies.Add( cookie );
        }
    }
}