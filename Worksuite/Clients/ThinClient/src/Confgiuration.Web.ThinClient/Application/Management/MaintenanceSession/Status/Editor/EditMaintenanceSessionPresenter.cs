using System;
using System.Web.Mvc;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Editor {

    /// <summary>
    /// Presenter that returns the edit maintenance session editor. The editor returned is dependent on
    /// whether there is already a maintenance session, if there is then the end maintenance session is 
    /// returned otherwise the start maintenance session editor is returned.
    /// </summary>
    public class EditMaintenanceSessionPresenter 
                    : Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory.Presenter {

        public ActionResult Editor() {
            var model = get_maintenance_status.execute().result;
            var view_model = create_view_model ( model );
            
            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public EditMaintenanceSessionPresenter 
                ( GetMaintenanceSessionStatus get_maintenance_status_query
                , EditorBuilder<NotInMaintenanceSession> the_start_maintenace_session_editor_builder
                , EditorBuilder<InMaintenanceSession> the_end_maintenace_session_editor_builder ) {

            get_maintenance_status = Guard.IsNotNull( get_maintenance_status_query, "get_maintenance_status_query" );
            start_maintenace_session_editor_builder = Guard.IsNotNull( the_start_maintenace_session_editor_builder, "the_start_maintenace_session_editor_builder");
            end_maintenace_session_editor_builder = Guard.IsNotNull( the_end_maintenace_session_editor_builder, "the_end_maintenace_session_editor_builder" );


            // register the view model builders
            view_model_builders = new DefaultedLookup<Type, ViewModelFactory>( model => new ANullViewElement( ) );
            view_model_builders
                    .register( typeof ( NotInMaintenanceSession ), model => start_maintenace_session_editor_builder.build( model as NotInMaintenanceSession ) )
                    .register( typeof ( InMaintenanceSession ), model => end_maintenace_session_editor_builder.build( model as InMaintenanceSession ) )
                    ;

        }

        public IsAViewElement create_view_model 
                                ( AMaintenanceSesssionStatus model ) {

            var view_model_builder = view_model_builders[ model.GetType(  ) ];

            return view_model_builder( model );
        }

        private GetMaintenanceSessionStatus get_maintenance_status;
        private EditorBuilder<NotInMaintenanceSession> start_maintenace_session_editor_builder;
        private EditorBuilder<InMaintenanceSession> end_maintenace_session_editor_builder;
        private DefaultedLookup<Type, ViewModelFactory> view_model_builders;
    }

    delegate IsAViewElement ViewModelFactory( AMaintenanceSesssionStatus model );
}