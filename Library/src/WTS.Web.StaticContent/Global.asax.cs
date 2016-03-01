using System;
using System.Web.Routing;

namespace WTS.Web.StaticContent {

    // This application acts as a cdn for common static content, css, javascript, etc. We have asp.net 
    // mvc controllers for testing the components, we need to have the htlm to test the javascript and
    // the html is generated from razor controls.  So we use mvc controllers to build the razor views

    public class Global 
                    : System.Web.HttpApplication {

        protected void Application_Start 
                        ( object sender
                        , EventArgs e ) {

            RouteConfig.RegisterRoutes( RouteTable.Routes );
        }
    }
}