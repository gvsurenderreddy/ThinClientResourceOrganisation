using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.New
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<NewEmployeeQualificationRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewEmployeeQualificationRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-employee-qualification-request")
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewEmployeeQualificationRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(fm => fm.qualification_id)
                .id("qualification_id")
                .label("Qualification")
                .is_required(true)
                .is_lookup()
                .help(HelpMessages.help_02_0014)
                ;

            fields_metadata_builder
                .for_field(fm => fm.employee_id)
                .id("employee_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewEmployeeQualificationRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Create.Resources.id)
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