using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration.Application;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataConfiguration<NewEmployeeImageRequest> 
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewEmployeeImageRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-image-request")
                .title(Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewEmployeeImageRequest> fields_metadata_builder)
        {

            fields_metadata_builder
                .for_field(m => m.data)
                .id("image_data")
               .lable("Upload a file")
               .is_composed()
               .help("Please  choose a picture with a minimum size of 600 by 400 pixels. In a  JPEG PNG GIF or Bitmap file format.")
                ;

            fields_metadata_builder
             .for_field(m => m.employee_id)
             .id("employee_id")
             .is_hidden()
             ;

            fields_metadata_builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewEmployeeImageRequest> actions_metadata_builder)
        {
            actions_metadata_builder
              .add_action<Save>()
              .id(Commands.Update.Resources.id)
              .route_parameter_factory(m => new { m.employee_id })
              ;

            actions_metadata_builder
                .add_action<Cancel>()
                .is_not_a_routed_action()
                ;
        }
    }
}