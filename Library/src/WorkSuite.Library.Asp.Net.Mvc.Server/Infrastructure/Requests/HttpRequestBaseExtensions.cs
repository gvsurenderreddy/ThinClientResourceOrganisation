using System;
using System.Web;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Request {

    /// <summary>
    /// Extension methods for <see href='HttpRequestBase'/>
    /// </summary>
    public static class HttpRequestBaseExtensions {

        /// <summary>
        ///     Returns the site url for the request.
        /// </summary>
        /// <returns>
        ///     The site url is a combination of the url authority and the application virtual path (an IIS thing I think)
        /// </returns>
        public static string site_url (
                                this HttpRequestBase request ) {

            Guard.IsNotNull( request, "request" );

            return request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath;
        }
    }
}
