using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.Report
{
    public class MetadataConfiguration
                    : ReportMetadataBuilder<BreakDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<BreakDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.break_id.ToString())
                .title(m => m.order.Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<BreakDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sb => sb.off_set)
                .id("off_set")
                .label("Starts after")
                ;

            fields_metadata_builder
                .for_field(sb => sb.duration)
                .id("duration")
                .label("Duration")
                ;

            fields_metadata_builder
                .for_field(sb => sb.is_paid)
                .id("is_paid")
                .label("Paid")
                ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<BreakDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(Edit.Resources.id)
                 .route_parameter_factory(m => new { m.template_id, m.break_id })
                 ;

            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove>()
                 .id(Commands.Remove.Resources.id)
                .route_parameter_factory(m => new { m.template_id, m.break_id })
                ;
        }
    }
}