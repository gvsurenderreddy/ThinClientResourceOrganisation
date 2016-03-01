using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.Remove.Editor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<RemoveShiftCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveShiftCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title("Remove " + Resources.title.ToLower())
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveShiftCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.calendar_name)
                .id("calendar_name")
                .label("Shift calendar name")
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sc => sc.shift_calendar_id)
                .id("shift_calendar_id")
                .is_hidden()
                ;

            fields_metadata_builder
                .for_field(sc => sc.operations_calendar_id)
                .id("operations_calendar_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveShiftCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                    .add_action<SubmitRemove>()
                    .call_to_action<PrimaryCallToAction>()
                    .id(Commands.Remove.Resources.id)
                    .route_parameter_factory(sc => new { sc.shift_calendar_id })
                    ;

            actions_metadata_builder
                    .add_action<Cancel>()
                    .call_to_action<SecondaryCallToAction>()
                    .is_not_a_routed_action()
                    ;
        }
    }
}