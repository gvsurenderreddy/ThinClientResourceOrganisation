using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.Home.Get {

    public class HomePagePresenter 
                    : Presenter {

        public ActionResult Page() {

            return View(
                @"~\Application\Home\Get\HomePage.cshtml",
                view_model_builder.build()                
            );
        }

        public HomePagePresenter(
                HomePageViewModelBuilder view_model_builder )  {

            this.view_model_builder = Guard.IsNotNull( view_model_builder, "view_model_builder" );
        }

        private HomePageViewModelBuilder view_model_builder;


    }
}