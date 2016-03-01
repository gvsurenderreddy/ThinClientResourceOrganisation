using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.Service.DocumentStore.Documents;

namespace WTS.WorkSuite.Web.ThinClient.Application.DocumentStore.Images.Presentation
{
    public class MetadataConfiguration : ReportMetadataBuilder<DocumentIdentity>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<DocumentIdentity> model_metadata_builder)
        {
            model_metadata_builder
               .presenter_id(Documents.Presentation.Resources.id)
               .title(Documents.Presentation.Resources.title)
               .presenter_route_pramameter_factory(m => new { m.document_id })
               ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<DocumentIdentity> field_metadata_builder)
        {
            field_metadata_builder
               .for_field(m => m.document_id)
               .id(a => a.document_id + "Document")
               ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<DocumentIdentity> action_metadata_builder)
        {

        }
    }
}