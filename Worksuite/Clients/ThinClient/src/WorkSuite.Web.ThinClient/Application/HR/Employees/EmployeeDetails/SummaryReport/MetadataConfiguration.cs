using WTS.WorkSuite.HR.HR.Employees;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.SummaryReport
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeSummaryDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmployeeSummaryDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .title( m => m.employee_name)
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeSummaryDetails> field_metadata_builder)
        {

            field_metadata_builder.for_field(x => x.image_id)
                .is_simple_image();
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeSummaryDetails> action_metadata_builder)
        {
           
        }
    }
}