using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Filters;

namespace WorkSuite.Confgiuration.Web.ThinClient {

    public class FilterConfig {

        // Improve: this is a copy and paste from the the worksuite client. Need to look into whether there is a sensible way to remove this duplication

        /// <summary>
        ///     Collection of global filters that should be set up for the 
        /// worksuite application
        /// </summary>
        public static IEnumerable<object> global_filters {

            get {
                yield return new HandleErrorAttribute( );

                // Globally turn off request validation here
                // since set requestValidationMode="2.0" in web.config 
                // does not work for .net 4.5 - need reviewing later on
                yield return new ValidateInputAttribute(false);

                // We are doing this so that if you come back to a form you are never presented information 
                // from a Cache.  We specifically set the information that should be displayed on a from
                // from the service layer, this means that you have to make a request to the server
                // for each new form so we want to be sure that a browser or Http proxy does not
                // decide to serve up the resouce from a cache
                yield return new DisableCachingFilter();
            }            
        }
    }

}