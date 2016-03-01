using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Details;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using Entity = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Entity;


namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeImageDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmployeeImageDetails> model_metadata_builder)
        {
            model_metadata_builder
               .presenter_id(Resources.id)
               .title(Resources.title)
               ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeImageDetails> field_metadata_builder)
        {
            field_metadata_builder
               .for_field(m => m.image_id)
               .id(a => a.image_id + "image")
               .label("Current picture")
               ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeImageDetails> action_metadata_builder)
        {
            
            action_metadata_builder
                .add_action<Edit>()
                .id(Editor.Resources.id)
                .route_parameter_factory(m => new {})
                ;


            action_metadata_builder
                .add_action<Entity.Remove>()
                .id(Commands.Remove.Resources.route_name)
                .route_parameter_factory(m => new { })
                ;
            
        }
    }
}