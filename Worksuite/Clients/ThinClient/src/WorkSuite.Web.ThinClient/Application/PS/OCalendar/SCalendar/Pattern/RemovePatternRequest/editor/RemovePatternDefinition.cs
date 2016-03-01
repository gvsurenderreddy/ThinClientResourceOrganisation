using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.removePattern.get
{
    public class RemovePatternDefinition : EditorMetadataBuilder<RemoveShiftCalendarPatternRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveShiftCalendarPatternRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("remove-shift-calendar-pattern-request")
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveShiftCalendarPatternRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.pattern_name)
                .id("pattern_name")
                .label("Shift calendar pattern name")
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sc => sc.number_of_resources)
                .id("number_of_resources")
                .label("Number of resources")
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sc => sc.shift_calendar_pattern_id)
                .id("shift_calendar_pattern_id")
                .is_hidden()
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sc => sc.shift_calendar_id)
                .id("shift_calendar_id")
                .is_hidden()
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sc => sc.operations_calendar_id)
                .id("operations_calendar_id")
                .is_hidden()
                .is_readonly()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveShiftCalendarPatternRequest> actions_metadata_builder)
        {

            actions_metadata_builder
                .add_action<Save>()
                .title("Remove")
                .call_to_action<PrimaryCallToAction>()
                .id(removePattern.post.Resources.id)
                .route_parameter_factory(sc => new { sc.operations_calendar_id, sc.shift_calendar_id, sc.shift_calendar_pattern_id })
                ;


            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}