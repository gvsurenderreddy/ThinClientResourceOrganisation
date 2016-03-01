using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetSingleDetails;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Edit.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<SingleOccurrenceDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<SingleOccurrenceDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => Resources.id)
                .title(Resources.title);
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<SingleOccurrenceDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.shift_title)
                .id("shift_title")
                .is_required(true)
                .label("Name");

            fields_metadata_builder
                .for_field(m => m.colour)
                .label("Colour")
                ;

            fields_metadata_builder
                .for_field(m => m.start_date)
                .label("Start date");

            fields_metadata_builder
                   .for_field(x => x.start_time)
                   .id("start_time")
                   .label("Start time");

            fields_metadata_builder
                   .for_field(x => x.duration)
                   .id("duration_time")
                   .label("Duration");
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<SingleOccurrenceDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(Editor.Resources.id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id })
                 ;
        }
    }
}