using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.report
{
    public class MetadataConfiguration
                        : ReportMetadataBuilder<ShiftCalendarPatternReportDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<ShiftCalendarPatternReportDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(get.Resources.page_id)
                .id(m => Resources.id)
                .title(m =>Resources.title.Humanize(LetterCasing.Sentence))
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<ShiftCalendarPatternReportDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.shift_calendar_pattern_name)
                .id("pattern_name")
                .label("Shift calendar pattern name")
                ;

            fields_metadata_builder
                .for_field(m => m.actual_resource_allocated_against_requested)
                .id("number_of_resources")
                .label("Resources")
                ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<ShiftCalendarPatternReportDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(updatePattern.get.Resources.id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id })
                 ;
        }
    }
}