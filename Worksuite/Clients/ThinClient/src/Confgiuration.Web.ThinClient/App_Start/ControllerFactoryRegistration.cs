using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WorkSuite.Confgiuration.Web.ThinClient {

    public class ControllerFactoryRegistration {

         public static void RegisterControllerFactory() {
             ControllerBuilder.Current.SetControllerFactory( new PresenterAndControllerFactory()); 
         }
    }
}