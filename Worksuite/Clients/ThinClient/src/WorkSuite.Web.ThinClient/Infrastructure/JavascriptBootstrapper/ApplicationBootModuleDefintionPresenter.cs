using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.NamedRouteMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Request;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Configuration.StaticContent;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.JavascriptBootstrapper {


    /// <summary>
    ///     Provides javascript that will configure requirejs with the path for the application-boot module and defines
    ///     the application_url_builder module.
    /// </summary>
    /// <remarks>
    ///     application_boot module
    ///     -----------------------
    ///     
    ///     The application-boot module is the module that bootstraps the javascript component system framework.  We are
    ///     using requirejs so you change module paths if you do not want to use the default module provided by the library
    ///     and you also configure and application specific modules in it.
    ///     
    /// 
    ///     application_url_builder
    ///     -----------------------
    ///     The application_url_builder module provide the application site root url.  This is a combination of the host and
    ///     the virtual directory path.
    ///
    /// </remarks>
    public class ApplicationBootModuleDefintionPresenter 
                    : Presenter {


        public ActionResult Index() {
            var site_root = Request.site_url();
            var library_root = StaticContentExtensions.host_url;
            var route_table = JsonConvert.SerializeObject( relative_path_route_table() ); 

            var script = string.Format(
@"
define( 'application_url_builder', [], function () {{

  return function ( path ) {{ 

    return '{0}' + path; 
  }};
}});  

define( 'route_table', {1} ); 

require.config({{
    baseUrl: '{2}',
    paths: {{
        application_boot: '{0}Infrastructure/JavascriptBootstrapper/application-boot'
    }}
}});
",
            site_root,
            route_table,
            library_root
            );

            return JavaScript( script );
        }

        public ApplicationBootModuleDefintionPresenter
                ( INamedRouteMetadataRepository route_metadata_repository ) {

            this.route_metadata_repository = Guard.IsNotNull( route_metadata_repository, "route_metadata_repository" );
        }

        private Dictionary<string,string> relative_path_route_table() {
            
            var root_folder = "/";
            var fully_qualified_routes = new Dictionary<string,string>();
            
            route_metadata_repository
                            .entries
                            .Do( route => fully_qualified_routes.Add( route.Key, root_folder + route.Value ))
                            ;

            return fully_qualified_routes;
        }

        public readonly INamedRouteMetadataRepository route_metadata_repository;
	}
}