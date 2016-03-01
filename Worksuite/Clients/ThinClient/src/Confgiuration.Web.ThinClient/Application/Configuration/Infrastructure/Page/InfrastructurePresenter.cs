using System.Web.Mvc;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Presentation.Report;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Presentation.Report;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Presentation.Report;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Infrastructure.Page {

    public class InfrastructurePresenter 
                    : Presenter {

        public ActionResult Page( ) {

            return this
                    .identify_maintenance_session_status ()
                    .include_maintenance_session_status_in_view_model ()
                    .include_force_online_in_view_model ()
                    .include_database_settings_in_view_model()
                    .include_static_content_in_view_model()
                    .include_Help_in_view_model()
                    .build_response( )
                    ;
        }

        public InfrastructurePresenter 
                ( AViewModelBuilder the_view_model_builder
                , GetMaintenanceSessionStatus get_maintenance_session_status_query 
                , IGetServiceStatus get_service_status_query
                , GetConnectioStringPresentationMetadata _get_current_database_setting_query
                , GetLocationUrlPresentationMetadata _get_current_static_content_query
                , GetHelpUrlPresentationMetadata _get_current_help_url_query)
        {

            view_model_builder = Guard.IsNotNull( the_view_model_builder, "the_view_model_builder" );
            get_maintenance_session_status = Guard.IsNotNull( get_maintenance_session_status_query, "get_maintenance_session_status_query" );
            get_service_status = Guard.IsNotNull( get_service_status_query, "get_service_status_query" );
            get_Connection_String_Presentation_Metadata = Guard.IsNotNull(_get_current_database_setting_query, "_get_current_database_setting_query");
            get_Location_Url_Presentation_Metadata = Guard.IsNotNull(_get_current_static_content_query, "_get_current_static_content_query");
            get_Help_Url_Presentation_Metadata = Guard.IsNotNull(_get_current_help_url_query, "_get_current_help_url_query");
        }


        private InfrastructurePresenter identify_maintenance_session_status () {

            maintenance_session_status = get_maintenance_session_status.execute().result;
            return this;            
        }

        private InfrastructurePresenter include_maintenance_session_status_in_view_model () {
            
            Guard.IsNotNull( maintenance_session_status, "maintenance_session_status" );

            view_model_builder.add_report( maintenance_session_status );
            return this;
        }


        private InfrastructurePresenter include_force_online_in_view_model ()
        {

            Guard.IsNotNull( maintenance_session_status, "maintenance_session_status" );

            var service_status = get_service_status.execute().result;

            if (  maintenance_session_status is NotInMaintenanceSession 
               && service_status is ServiceIsInMaintenanceMode ) {
                
                view_model_builder.add_report( service_status );
            }
            return this;
        }

        private InfrastructurePresenter include_database_settings_in_view_model()
        {
            view_model_builder.add_report(get_Connection_String_Presentation_Metadata.execute().result);
            return this;
        }

        private InfrastructurePresenter include_static_content_in_view_model()
        {
            view_model_builder.add_report( get_Location_Url_Presentation_Metadata.execute().result );         
            return this;
        }

        private InfrastructurePresenter include_Help_in_view_model()
        {
            view_model_builder.add_report(get_Help_Url_Presentation_Metadata.execute().result);
            return this;
        }

        public ActionResult build_response () {
            
            return View( @"~\Views\Configuration\Infrastructure\Page.cshtml", view_model_builder.build() );
        }

        // allows us to build a view model from multiple query results.
        private readonly AViewModelBuilder view_model_builder;

        // query that gets the current status of the worksuite service.
        private readonly GetMaintenanceSessionStatus get_maintenance_session_status;

        // query used to get the current status of the worksuite service
        private readonly IGetServiceStatus get_service_status;

        private AMaintenanceSesssionStatus maintenance_session_status;

        private readonly GetLocationUrlPresentationMetadata get_Location_Url_Presentation_Metadata;

        private readonly GetConnectioStringPresentationMetadata get_Connection_String_Presentation_Metadata;

        private readonly GetHelpUrlPresentationMetadata get_Help_Url_Presentation_Metadata;

                    }
}
