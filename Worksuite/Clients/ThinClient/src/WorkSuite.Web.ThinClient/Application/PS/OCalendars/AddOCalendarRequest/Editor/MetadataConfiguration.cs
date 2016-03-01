using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.New.Presentation.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Commands.New.Presentation.Editor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<NewOperationsCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewOperationsCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewOperationsCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(oc => oc.calendar_name)
                .id("calendar_name")
                .is_required(true)
                .label("Calendar name")
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewOperationsCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id( OperationalCalendars.New.Commands.Create.Resources.id )
                .route_parameter_factory( r => new { } )
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}