using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.Remove
{
    public class MetadataConfiguration : EditorMetadataBuilder<RemoveShiftBreakRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveShiftBreakRequest> builder)
        {
            builder
                .title(Resources.title)
                .id("remove-shift-break-request")
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveShiftBreakRequest> builder)
        {
            builder
                .for_field(sb => sb.off_set)
                .id("off-set-in-seconds")
                .is_required(true)
                .is_readonly()
                .help(HelperMessage.help_22_0027)
                .label("Starts after")
                ;

            builder
                .for_field(sb => sb.duration)
                .id("duration-in-seconds")
                .is_required(true)
                .is_readonly()
                .help(HelperMessage.help_22_0028)
                .label("Duration")
                ;

            builder
                .for_field(m => m.is_paid)
                .id("is_paid")
                .readonly_display_string(m => m.is_paid ? "Yes" : "No" )
                .is_readonly()
                .label("Paid")
                ;

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

            builder
                .for_field(m => m.shift_break_id)
                .is_hidden();
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveShiftBreakRequest> builder)
        {
            builder
                .add_action<Save>()
                .title("Remove")
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Remove.Resources.id)
                .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id, m.shift_break_id })
                ;

            builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}