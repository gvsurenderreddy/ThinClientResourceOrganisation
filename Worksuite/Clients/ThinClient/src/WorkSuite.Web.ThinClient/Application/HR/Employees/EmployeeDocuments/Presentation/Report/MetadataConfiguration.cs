using System.Globalization;
using Humanizer;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Configuration.StaticContent;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeDocumentDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmployeeDocumentDetails> model_metadata_builder)
        {
            model_metadata_builder
              .presenter_id(Resources.id)
              .id(m => m.employee_document_id.ToString())
              .title(Resources.title.Humanize(LetterCasing.Sentence))
              ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeDocumentDetails> field_metadata_builder)
        {
            field_metadata_builder
              .for_field(m => m.name)
              .id(m => m.employee_document_id.ToString(CultureInfo.InvariantCulture) + "name")
              .icon(m=> m.content_type.ToIconString() )
              .is_included(m => !string.IsNullOrWhiteSpace(m.name))
              .label("Name")
              ;


            field_metadata_builder
              .for_field(m => m.description)
              .id(m => m.employee_document_id.ToString(CultureInfo.InvariantCulture) + "description")
              .is_rich_text(true)
              .is_included(m => !string.IsNullOrWhiteSpace(m.description))
              .label("Description")
              ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeDocumentDetails> action_metadata_builder)
        {
            action_metadata_builder
                .add_action<Download>()
                .id(DocumentStore.Documents.Presentation.Resources.id)
                .route_parameter_factory(m => new { m.document_id });


            action_metadata_builder
               .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove>()
               .id(EmployeeDocuments.Commands.Remove.Resources.route_name)
               .route_parameter_factory(m => new { m.employee_document_id, m.document_id })
               ;

        }
    }
}