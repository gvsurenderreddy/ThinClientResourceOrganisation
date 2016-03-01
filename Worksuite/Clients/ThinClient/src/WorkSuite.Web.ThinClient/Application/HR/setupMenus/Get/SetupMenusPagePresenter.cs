using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.setupMenus.Get {

    public class SetupMenusPagePresenter 
                    : Presenter {


        public ActionResult Page() {

            return View(
                @"~\Application\HR\setupMenus\Get\SetupMenusPage.cshtml", 
                view_model_builder.build()
            );
        }


        public SetupMenusPagePresenter
                ( SetupMenusPageViewModelBuilder view_model_builder ) {

            this.view_model_builder = Guard.IsNotNull( view_model_builder, "view_model_builder" );
        }

        private readonly SetupMenusPageViewModelBuilder view_model_builder;
    }
}