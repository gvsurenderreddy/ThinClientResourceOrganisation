using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.RemoveAll.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<RemoveAllShiftOccurrencesRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveAllShiftOccurrencesRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveAllShiftOccurrencesRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.title)
                .label("Name")
                .is_readonly();

            fields_metadata_builder
                .for_field(m => m.colour)
                .label("Colour");
                

            fields_metadata_builder
                .for_field(m => m.start_time)
                .label("Start time")
                .is_readonly();

            fields_metadata_builder
                .for_field(m => m.duration)
                .label("Duration")
                .is_readonly();

            fields_metadata_builder
                .for_field(m => m.shift_calendar_affected);

            fields_metadata_builder
                .for_field(m => m.operations_calendar_id)
                .is_hidden();

            fields_metadata_builder
                .for_field(m => m.shift_calendar_id)
                .is_hidden();

            fields_metadata_builder
                .for_field(m => m.shift_calendar_pattern_id)
                .is_hidden();

            fields_metadata_builder
                .for_field(m => m.shift_occurrence_id)
                .is_hidden();

        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveAllShiftOccurrencesRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<SubmitRemove>()
                .title("Remove all")
                .call_to_action<PrimaryCallToAction>()
                .id(Command.RemoveAll.Resources.id)
                .route_parameter_factory ( m => new { m.operations_calendar_id,m.shift_calendar_id,m.shift_calendar_pattern_id,m.shift_occurrence_id });

            actions_metadata_builder
                 .add_action<Cancel>()
                 .call_to_action<SecondaryCallToAction>()
                 .is_not_a_routed_action()
                 ;

        }
    }
}