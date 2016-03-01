using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.addHoliday.editor
{
    public class AddHolidayEditorDefinition : EditorMetadataBuilder<AddHolidayRequest>
    {
        protected override void build_model_metadata( IEditorModelMetadataBuilder<AddHolidayRequest> model_metadata_builder )
        {
            model_metadata_builder
                .id(e => e.employee_id + Resources.page_id)
                .title(content_repository.get_resource_value("add_employee_holiday_editor_title"));
        }

        protected override void build_field_metadata( IEditorFieldsMetadataBuilder<AddHolidayRequest> fields_metadata_builder )
        {
            fields_metadata_builder
                .for_field(h => h.employee_id)
                .id("employee_id")
                .is_hidden()
                ;

            fields_metadata_builder
                .for_field(h => h.holiday_date)
                .id("holiday_date")
                .is_required(true)
                .is_composed()
                .label(content_repository.get_resource_value("add_employee_holiday_editor_holiday_date_label"))
                .help(content_repository.get_resource_value("add_employee_holiday_editor_holiday_date_help_text"))
                ;
        }

        protected override void build_action_metadata( IEditorActionsMetadataBuilder<AddHolidayRequest> actions_metadata_builder )
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(post.Resources.id)
                .route_parameter_factory(r => new { r.employee_id })
                ;  

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}