using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start {

    public class StartMaintenanceSessionPresenter 
                    : Presenter {

        public ActionResult Editor() {
           
            return View( @"~\Views\Shared\Views\Editor.cshtml", editor_builder.build( new StartMaintenanceSessionRequest() ) );
        }

        public StartMaintenanceSessionPresenter 
                ( EditorBuilder<StartMaintenanceSessionRequest> the_editor_builder ) {
            
            editor_builder = Guard.IsNotNull( the_editor_builder, "the_editor_builder " );
        }

        private EditorBuilder<StartMaintenanceSessionRequest> editor_builder;
    }
}