using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<UpdateEmploymentDetailsRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateEmploymentDetailsRequest> model_metadata_builder)
        {
            model_metadata_builder
                .title("Edit " + EmploymentDetailsResources.title.ToLower())
                .id(Resources.id)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateEmploymentDetailsRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.employeeReference)
                .id("employee_reference")
                .is_required(true)
                .label("Employee reference")
                .help(ValidationMessages.help_02_0007)
                ;

            fields_metadata_builder
                .for_field(m => m.job_title_id)
                .id("job_title_id")
                .label("Job title")
                .is_lookup()
                .help("Job title can be added, edited or removed from the 'setup menus' options on the home page.")
                ;

            fields_metadata_builder
                .for_field(m => m.location_id)
                .id("location_id")
                .label("Location")
                .is_lookup()
                .help("Location can be added, edited or removed from the 'setup menus' options on the home page.")
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateEmploymentDetailsRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
                .route_parameter_factory(m => new { m.employee_id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}