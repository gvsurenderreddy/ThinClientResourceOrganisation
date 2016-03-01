using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Remove.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Remove.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<RemoveShiftOccurrenceRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveShiftOccurrenceRequest> builder)
        {
            builder
                .title(Resources.title)
                .id(Resources.id)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveShiftOccurrenceRequest> builder)
        {
            builder
                .for_field(m => m.title)
                .label("Name")
                .is_readonly();

            builder
                .for_field(m => m.colour)
                .label("Colour");

            builder
                .for_field(m => m.start_date)
                .label("Start date")
                .is_readonly();

            builder
                .for_field(m => m.start_time)
                .label("Start time")
                .is_readonly();

            builder
                .for_field(m => m.duration)
                .label("Duration")
                .is_readonly();

            builder
                .for_field(m => m.operations_calendar_id)
                .is_hidden();

            builder
                .for_field(m => m.shift_calendar_id)
                .is_hidden();

            builder
                .for_field(m => m.shift_calendar_pattern_id)
                .is_hidden();

            builder
                .for_field(m => m.shift_occurrence_id)
                .is_hidden();
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveShiftOccurrenceRequest> builder)
        {
            builder
                .add_action<SubmitRemove>()
                .call_to_action<PrimaryCallToAction>()
                .id(Command.Remove.Resources.id)
                .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id })
                ;

            builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}