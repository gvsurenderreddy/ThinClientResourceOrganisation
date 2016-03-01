using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.New.Editor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<NewShiftCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewShiftCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewShiftCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.calendar_name)
                .id("calendar_name")
                .is_required(true)
                .label("Shift calendar name")
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewShiftCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<SubmitNew>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.New.Create.Resources.id)
                .route_parameter_factory(r => new { })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}