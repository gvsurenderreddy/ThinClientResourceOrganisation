using System;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory {

    /// <summary>
    ///     Marker interface used to identify that types that implement this
    /// interface are intended to handle get requests.
    /// </summary>
    public interface IPresenter 
                        : IController { }


    /// <summary>
    ///     Extension methods for the IPresenter interface
    /// </summary>
    public static class IPresenterExtensions {

        public static string mvc_controller_name
                                ( this Type controller ) {

            Guard.IsNotNull( controller, "controller" );
            
            return controller.IsAssignableFrom(typeof(IPresenter)) 
                    ? controller.Name 
                    : controller.Name.Replace( "Controller","" );
        }

    }

}