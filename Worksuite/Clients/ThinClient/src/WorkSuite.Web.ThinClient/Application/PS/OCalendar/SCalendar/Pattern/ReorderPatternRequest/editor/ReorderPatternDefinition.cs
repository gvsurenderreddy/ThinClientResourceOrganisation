using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.reorderPattern.get
{
    public class ReorderPatternDefinition
                        : EditorMetadataBuilder<ReorderShiftCalendarPatternDetailsDisplay>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<ReorderShiftCalendarPatternDetailsDisplay> model_metadata_builder)
        {
            model_metadata_builder
                .id("reorder-shift-calendar-pattern-request")
                .title(m => m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<ReorderShiftCalendarPatternDetailsDisplay> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.shift_calendar_pattern_name)
                .id("pattern_name")
                .label("Name")
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sc => sc.actual_resource_allocated_against_requested)
                .id("number_of_resources")
                .label("Resources")
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

            fields_metadata_builder
              .for_field(m => m.priority)
              .id("priority")
              .is_hidden()
              .is_readonly()
              ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<ReorderShiftCalendarPatternDetailsDisplay> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(reorderPattern.post.Resources.id)
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