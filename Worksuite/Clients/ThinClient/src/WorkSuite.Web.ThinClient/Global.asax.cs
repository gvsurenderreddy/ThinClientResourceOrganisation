using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.App_Start;

namespace WTS.WorkSuite.Web.ThinClient {

    public class MvcApplication 
                    : HttpApplication {
    
        protected void Application_Start ( ) {

            // NOTE - It is expected that the dependency injection system has been configured before
            //        this is executed.   At the time of writting this coment we are loading the
            //        dependency injection definitions from NinjectWebCommon using the 
            //        WebActivator.PreApplicationStartMethod

            this
                .register_mvc_framework_extensions()
                .load_view_model_definitions()
                .register_mvc_areas()
                .register_global_filters()
                .load_routes()
                ;            
        }


        private MvcApplication register_mvc_framework_extensions () {
            ControllerBuilder.Current.SetControllerFactory( new PresenterAndControllerFactory()); 
            return this;
        }

        private MvcApplication load_view_model_definitions () {
            BuildViewModelMetadata.build();
            return this;
        }

        private MvcApplication register_mvc_areas () {
            AreaRegistration.RegisterAllAreas( );
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
            RouteTable.Routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            DependencyResolver.Current.GetServices<INamedRouteDefinition>()
                .deepest_nodes_first()
                .build_mvc_route()
                .Do( defintion => RouteTable.Routes.Add( defintion.name, defintion.route  ))
                ;

            return this;
        }
    }
}