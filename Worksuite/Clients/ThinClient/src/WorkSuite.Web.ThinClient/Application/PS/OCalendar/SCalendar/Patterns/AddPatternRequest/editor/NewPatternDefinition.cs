using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.newPattern.get
{
    public class NewPatternDefinition
                        : EditorMetadataBuilder<NewShiftCalendarPatternRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewShiftCalendarPatternRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-shift-calendar-pattern-request")
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewShiftCalendarPatternRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.pattern_name)
                .id("pattern_name")
                .is_required(true)
                .label("Shift calendar pattern name")
                ;

            fields_metadata_builder
                .for_field(m => m.number_of_resources)
                .id("number_of_resources")
                .is_required(true)
                .label("Number of resources")
                .add_class("input-3-characters")
                ;

            fields_metadata_builder
                .for_field(m => m.shift_calendar_pattern_id)
                .id("shift_calendar_pattern_id")
                .is_hidden()
                ;

            fields_metadata_builder
                .for_field(m => m.shift_calendar_id)
                .id("shift_calendar_id")
                .is_hidden()
                ;

            fields_metadata_builder
                .for_field(m => m.operations_calendar_id)
                .id("operations_calendar_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewShiftCalendarPatternRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(post.Resources.id)
                .route_parameter_factory(r => new { r.operations_calendar_id, r.shift_calendar_id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}