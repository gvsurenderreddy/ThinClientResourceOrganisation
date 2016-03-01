using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish;
using Cancel = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Cancel;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Presentation.Publish.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<PublishShiftCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<PublishShiftCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                 .id(Resources.id)
                 .title(Resources.title + " from calendar ")
                 .description(PlaceholderMessages.placeholder_05_0020)
                 ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<PublishShiftCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sc => sc.calendar_name)
                .id("calendar_name")
                .label("Shift calendar name")
                .is_readonly()
                ;

            fields_metadata_builder
               .for_field(sc => sc.start_date)
               .id("start_date")
               .label("Start date")
               .is_required(true)
               .help(HelperMessage.help_030220151159)
               .is_composed()
               ;

            fields_metadata_builder
               .for_field(sc => sc.end_date)
               .id("end_date")
               .label("End date")
               .help(HelperMessage.help_030220151159)
               .is_required(true)
               .is_composed()
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

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<PublishShiftCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
               .add_action<SubmitNew>()
               .title("Publish")
               .call_to_action<PrimaryCallToAction>()
               .id(Commands.Publish.Resources.id)
               .route_parameter_factory(r => new { });

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action();
        }
    }
}