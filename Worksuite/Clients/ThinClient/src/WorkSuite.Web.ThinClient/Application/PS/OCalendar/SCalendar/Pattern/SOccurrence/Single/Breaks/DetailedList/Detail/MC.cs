using System.Globalization;
using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<ShiftBreakDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<ShiftBreakDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.shift_break_id.ToString(CultureInfo.InvariantCulture))
                .title(m => m.position.Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<ShiftBreakDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sb => sb.offset_from_start_time)
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

        protected override void build_action_metadata(IReportActionsMetadataBuilder<ShiftBreakDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(Edit.Resources.id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id, m.shift_break_id })
                     
                 ;

            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(Remove.Resources.id)
                 .title("remove")
                .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id, m.shift_break_id })
                ;

        }
    }
}