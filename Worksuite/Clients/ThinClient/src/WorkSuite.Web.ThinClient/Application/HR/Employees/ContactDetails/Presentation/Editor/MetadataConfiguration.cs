using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetails.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<UpdateRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateRequest> builder)
        {
            builder
                .title(Resources.title)
                .id(Resources.id)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateRequest> builder)
        {
            builder
                .for_field(m => m.phone)
                .id("phone")
                .label("Phone number")
                ;

            builder
                .for_field(m => m.mobile)
                .id("mobile")
                .label("Mobile")
                ;

            builder
                .for_field(m => m.email)
                .id("email")
                .label("Email")
                ;

            builder
                .for_field(m => m.other)
                .id("other")
                .label("Other")
                ;

            builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateRequest> builder)
        {
            builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
                .route_parameter_factory(m => new { m.employee_id })
                ;

            builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}