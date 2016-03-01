using System.Web.Mvc;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.ForceOnline.Editor {

    public class EditForceOnlinePresenter 
                    : Presenter {


        public ActionResult Editor () {
            var model = get_end_all_maintenance_sessions_request.execute(  );
            var view_model = editor_builder.build( model );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }


        public EditForceOnlinePresenter
                ( IGetEndAllMaintenanceSessionsRequest get_end_all_maintenance_sessions_request_command
                , EditorBuilder<EndAllMaintenanceSessionsRequest> the_editor_builder ) {

            get_end_all_maintenance_sessions_request = Guard.IsNotNull( get_end_all_maintenance_sessions_request_command, "get_end_all_maintenance_sessions_request_command" );
            editor_builder = Guard.IsNotNull( the_editor_builder, "the_editor_builder " );
        }

        private readonly IGetEndAllMaintenanceSessionsRequest get_end_all_maintenance_sessions_request;
        private readonly EditorBuilder<EndAllMaintenanceSessionsRequest> editor_builder;
    }
}