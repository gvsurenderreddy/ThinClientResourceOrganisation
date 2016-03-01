using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.Report
{
    public class MetadataConfiguration
                            : ReportMetadataBuilder<MaritalStatusDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<MaritalStatusDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.id.ToString())
                .title(m => m.description)
                .is_marked_as_hidden(m => m.is_hidden)
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<MaritalStatusDetails> field_metadata_builder)
        {
            field_metadata_builder
                .for_field(m => m.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<MaritalStatusDetails> action_metadata_builder)
        {
            action_metadata_builder
                .add_action< Edit >()
                .id( MaritalStatuses.Presentation.Editor.Resources.id )
                .route_parameter_factory( m => new { m.id } )
                ;

            action_metadata_builder
                .add_action< global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove >()
                .id( MaritalStatuses.Commands.Remove.Resources.id )
                .route_parameter_factory( m => new { m.id } )
                ;
        }
    }
}