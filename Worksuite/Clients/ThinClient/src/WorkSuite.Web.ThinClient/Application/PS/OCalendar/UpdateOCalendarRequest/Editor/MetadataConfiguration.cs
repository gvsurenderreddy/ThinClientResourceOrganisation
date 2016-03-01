using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Edit.Presentation.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Presentation.Editor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<UpdateOperationsCalendarRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateOperationsCalendarRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title("Edit " + Resources.title.ToLower())
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateOperationsCalendarRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(oc => oc.calendar_name)
                .id("calendar_name")
                .is_required(true)
                .label("Calendar name")
                ;

            fields_metadata_builder
                .for_field(oc => oc.operations_calendar_id)
                .id("operations_calendar_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateOperationsCalendarRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<SubmitEdit>()
                .call_to_action<PrimaryCallToAction>()
                .id(Edit.Commands.Update.Resources.id)
                .route_parameter_factory(oc => new { oc.operations_calendar_id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}