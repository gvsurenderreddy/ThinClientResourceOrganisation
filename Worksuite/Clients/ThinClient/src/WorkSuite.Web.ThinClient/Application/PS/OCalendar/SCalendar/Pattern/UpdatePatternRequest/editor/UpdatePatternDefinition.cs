using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.updatePattern.get
{
    public class UpdatePatternDefinition
                        : EditorMetadataBuilder<UpdateShiftCalendarPatternRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateShiftCalendarPatternRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("update-shift-calendar-pattern-request")
                .title("Edit " + Resources.title.ToLower())
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateShiftCalendarPatternRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.pattern_name)
                .id("pattern_name")
                .is_required(true)
                .label("Shift calendar pattern name")
                ;

            fields_metadata_builder
                .for_field(sc => sc.number_of_resources)
                .id("number_of_resources")
                .is_required(true)
                .label("Number of resources")
                .add_class("input-3-characters")
                ;

            fields_metadata_builder
                .for_field(sc => sc.shift_calendar_pattern_id)
                .id("shift_calendar_pattern_id")
                .is_hidden()
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

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateShiftCalendarPatternRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(PlannedSupply.ShiftCalendars.Patterns.updatePattern.post.Resources.id)
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