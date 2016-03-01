using WTS.WorkSuite.HR.HR.Employees.ContactDetails;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetails.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeContactDetails>
    {
        protected override void build_model_metadata (IReportModelMetadataBuilder<EmployeeContactDetails> builder)
        {
            builder
                .presenter_id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeContactDetails> builder)
        {
            builder
                .for_field(m => m.phone)
                .is_included(m => !string.IsNullOrWhiteSpace(m.phone))
                .id("phone")
                .label("Phone number")
                ;

            builder
                .for_field(m => m.mobile)
                .is_included(m => !string.IsNullOrWhiteSpace(m.mobile))
                .id("mobile")
                .label("Mobile")
                ;

            builder
                .for_field(m => m.email)
                .is_included(m => !string.IsNullOrWhiteSpace(m.email))
                .id("email")
                .label("Email")
                ;

            builder
                .for_field(m => m.other)
                .is_included(m => !string.IsNullOrWhiteSpace(m.other))
                .id("other")
                .label("Other")
                ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeContactDetails> builder)
        {
            // build action for link "Edit"
            builder
                .add_action<Edit>()
                .id(Editor.Resources.id)
                .route_parameter_factory(m => new { m.employee_id })
                ;
        }

    }
}