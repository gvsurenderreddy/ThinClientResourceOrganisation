using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Formating;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.reorderPattern.get
{
    public class ReorderPatternPresenter : Presenter
    {
        public ReorderPatternPresenter(IGetReorderShiftCalendarPatternRequest the_get_request,
                                                            EditorBuilder<ReorderShiftCalendarPatternDetailsDisplay> the_editor_builder)
        {
            get_reorder_request = Guard.IsNotNull(the_get_request, "the_get_request");
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
        }

        public ActionResult Editor(ReorderShiftCalendarPatternRequest the_reorder_shift_pattern_request)
        {
            var update_request = get_reorder_request.execute(the_reorder_shift_pattern_request).result;

            var update_request_editor = new ReorderShiftCalendarPatternDetailsDisplay()
            {
                operations_calendar_id = update_request.operations_calendar_id,
                shift_calendar_id = update_request.shift_calendar_id,
                shift_calendar_pattern_id = update_request.shift_calendar_pattern_id,
                shift_calendar_pattern_name = update_request.shift_calendar_pattern_name,
                current_priority = update_request.current_priority,
                priority = update_request.priority,
                actual_resource_allocated_against_requested = ReportFormatStringExtension.actual_against_requested_string_for_resource_allocation(update_request.resource_allocation_summary, update_request.number_of_resources)
            };

            var view_model = editor_builder.build(update_request_editor);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        private readonly IGetReorderShiftCalendarPatternRequest get_reorder_request;
        private readonly EditorBuilder<ReorderShiftCalendarPatternDetailsDisplay> editor_builder;
    }
}