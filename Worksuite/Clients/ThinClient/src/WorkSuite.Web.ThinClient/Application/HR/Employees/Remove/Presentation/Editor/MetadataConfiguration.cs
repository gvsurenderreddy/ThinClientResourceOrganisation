using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.Remove;

using Action = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Remove.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<RemoveEmployeeRequest>
    {
        protected override void build_model_metadata
            (IEditorModelMetadataBuilder<RemoveEmployeeRequest> builder)
        {
            builder
                .title(Resources.title)
                .id(Resources.id)
                ;
        }

        protected override void build_field_metadata
            (IEditorFieldsMetadataBuilder<RemoveEmployeeRequest> builder)
        {
            builder
                .for_field(m => m.othername)
                .id("othername")
                .label("Other names")
                .is_included(m => !string.IsNullOrWhiteSpace(m.othername))
                .is_readonly()
                ;

            builder
                .for_field(m => m.forename)
                .id("forename")
                .label("Forename")
                .is_readonly()
                ;

            builder
                .for_field(m => m.surname)
                .id("surname")
                .label("Surname")
                .is_readonly()
                ;

            builder
                .for_field(m => m.gender)
                .id("gender")
                .label("Gender")
                .is_included(m => !string.IsNullOrWhiteSpace(m.gender))
                .is_readonly()
                ;

            builder
                .for_field(m => m.birth_place)
                .id("birth_place")
                .label("Place of birth")
                .is_included(m => !string.IsNullOrWhiteSpace(m.birth_place))
                .is_readonly()
                ;

            builder.for_field(m => m.dateofbirth)
                .id("dateofbirth")
                .label("Date of birth")
                .is_included(m => !string.IsNullOrWhiteSpace(m.dateofbirth))
                .is_readonly()
                ;

            builder
                .for_field(m => m.employee_id)
                .id("employee_id")
                .is_hidden()
                ;

            builder
                .for_field(m => m.title)
                .id("title")
                .label("Title")
                .is_included(m => !string.IsNullOrWhiteSpace(m.title))
                .is_readonly()
                ;

            builder
                .for_field(m => m.employeeReference)
                .id("employee_reference")
                .label("Employee reference")
                .is_readonly()
                ;
        }

        protected override void build_action_metadata
            (IEditorActionsMetadataBuilder<RemoveEmployeeRequest> builder)
        {
            builder
                .add_action<Action.Remove>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Delete.Resources.id)
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