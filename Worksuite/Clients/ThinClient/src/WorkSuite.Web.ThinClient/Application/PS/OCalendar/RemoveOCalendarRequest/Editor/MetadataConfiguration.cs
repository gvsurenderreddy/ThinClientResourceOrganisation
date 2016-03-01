using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Remove.Presentation.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Presentation.RemoveEditor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<RemoveOperationsCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveOperationsCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                    .id(Resources.id)
                    .title("Remove " + Resources.title.ToLower())
                    ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveOperationsCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                    .for_field(oc => oc.calendar_name)
                    .id("calendar_name")
                    .label("Calendar name")
                    .is_readonly()
                    ;

            fields_metadata_builder
                    .for_field(oc => oc.operations_calendar_id)
                    .id("operations_calendar_id")
                    .is_hidden()
                    ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveOperationsCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                    .add_action<SubmitRemove>()
                    .call_to_action<PrimaryCallToAction>()
                    .id(Remove.Commands.Remove.Resources.id)
                    .route_parameter_factory(oc => new { oc.operations_calendar_id })
                    ;

            actions_metadata_builder
                    .add_action<Cancel>()
                    .call_to_action<SecondaryCallToAction>()
                    .is_not_a_routed_action()
                    ;
        }
    }
}