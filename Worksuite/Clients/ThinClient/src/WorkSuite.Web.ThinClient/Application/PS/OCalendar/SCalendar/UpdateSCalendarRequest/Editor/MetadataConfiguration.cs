using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.Edit.Editor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<UpdateShiftCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateShiftCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title("Edit " + Resources.title.ToLower())
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateShiftCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.calendar_name)
                .id("calendar_name")
                .is_required(true)
                .label("Shift calendar name")
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

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateShiftCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
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