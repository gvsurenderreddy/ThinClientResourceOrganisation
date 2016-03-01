using System.Configuration;


namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Configuration.StaticContent {

    /// <summary>
    /// Constainer for methods that provide inforation on the static content website.
    /// </summary>
    public class StaticContentExtensions {


        /// <summary>
        /// Gets the url for the static content website
        /// </summary>
        public static string host_url {

            get {  
                return ConfigurationManager.AppSettings[ "static_content_website_host" ];
            }
        }

    }
}
