using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Presentation.TemplateEditor
{
    public class MetadataConfiguration : EditorMetadataBuilder<ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest> builder)
        {
            builder
                .title(Resources.title)
                .id(Resources.id)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest> builder)
        {

            builder.for_field(m => m.break_template_id)
                    .label("Break template")
                    .is_lookup();

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

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest> builder)
        {
            builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.ApplyFromTemplate.Resources.id)
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