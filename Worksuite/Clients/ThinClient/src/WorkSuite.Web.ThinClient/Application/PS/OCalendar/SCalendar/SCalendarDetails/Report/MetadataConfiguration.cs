using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<ShiftCalendarDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<ShiftCalendarDetails> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => Resources.id)
                .title(m => Resources.title.Humanize(LetterCasing.Sentence))
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<ShiftCalendarDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.calendar_name)
                .id("calendar_name")
                .label("Shift calendar name")
                ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<ShiftCalendarDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                 .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit>()
                 .id(PlannedSupply.Presentation.ShiftCalendars.Presentation.Edit.Editor.Resources.id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id })
                 ;
        }
    }
}