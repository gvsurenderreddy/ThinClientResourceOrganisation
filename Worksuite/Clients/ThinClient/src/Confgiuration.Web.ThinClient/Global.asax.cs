using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient {

    public class MvcApplication 
                    : HttpApplication {

        protected void Application_Start () {

            this
                .register_mvc_framework_extensions()
                .load_view_model_defintions()
                .register_mvc_areas()
                .register_global_filters()
                .load_routes()
                ;
        }

        private MvcApplication register_mvc_framework_extensions () {

            ControllerBuilder.Current.SetControllerFactory( new PresenterAndControllerFactory());
            return this;
        }

        private MvcApplication load_view_model_defintions () {

            BuildViewModelMetadata.build();
            return this;
        }

        private MvcApplication register_mvc_areas () {

            AreaRegistration.RegisterAllAreas();
            return this;
        }

        private MvcApplication register_global_filters () {

            FilterConfig
                .global_filters
                .Do( GlobalFilters.Filters.Add )
                ;
            return this;
        }

        private MvcApplication load_routes () {

            DependencyResolver.Current.GetServices<INamedRouteDefinition>()
                .deepest_nodes_first()
                .build_mvc_route()
                .Do( defintion => RouteTable.Routes.Add( defintion.name, defintion.route  ))
                ;

            return this;
        }
    }
}