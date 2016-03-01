using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.listReport
{
    public class MetadataConfiguration
                        : ReportMetadataBuilder<ShiftCalendarPatternListReportDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<ShiftCalendarPatternListReportDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.shift_calendar_pattern_id.ToString())
                .title(m => m.priority.Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<ShiftCalendarPatternListReportDetails> fields_metadata_builder)
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

        protected override void build_action_metadata(IReportActionsMetadataBuilder<ShiftCalendarPatternListReportDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.View>()
                 .title("edit")
                 .id(get.Resources.page_id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id })
                 ;

            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(removePattern.get.Resources.id)
                 .title("remove")
                .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id })
                ;

            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Reorder>()
                 .id(reorderPattern.get.Resources.id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id })
                 ;
        }
    }
}