using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeEmploymentDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmployeeEmploymentDetails> model_metadata_builder)
        {
            model_metadata_builder.presenter_id(Resources.id)
                                  .title(EmploymentDetailsResources.title)
                                  ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeEmploymentDetails> field_metadata_builder)
        {
            field_metadata_builder.for_field(m => m.employeeReference)
                                  .id("employee_reference")
                                  .label("Employee reference")
                                  ;

            field_metadata_builder.for_field(m => m.job_description)
                                  .is_included(m => !string.IsNullOrEmpty(m.job_description))
                                  .id("job_description")
                                  .label("Job title")
                                  ;

            field_metadata_builder.for_field(m => m.location_description)
                                  .is_included(m => !string.IsNullOrEmpty(m.location_description))
                                  .id("location_description")
                                  .label("Location")
                                  ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeEmploymentDetails> action_metadata_builder)
        {
            action_metadata_builder.add_action<Edit>()
                                   .id(Editor.Resources.id)
                                   .route_parameter_factory(m => new { m.employee_id })
                                   ;
        }
    }
}