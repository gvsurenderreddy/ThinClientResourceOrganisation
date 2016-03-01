using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.GetCreateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.New.Editor
{
    public class NewShiftCalendarPresenter
                        : Presenter
    {
        public ActionResult Editor(OperationsCalendarIdentity the_operations_calendar)
        {
            var request = _get_new_shift_calendar_request
                                    .execute(new ShiftCalendarIdentity { operations_calendar_id = the_operations_calendar.operations_calendar_id });
            var view_model = _new_shift_calendar_request_editor_builder
                                    .build(request);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewShiftCalendarPresenter(IGetNewShiftCalendarRequest the_get_new_shift_calendar_request,
                                                EditorBuilder<NewShiftCalendarRequest> the_new_shift_calendar_request_editor_builder
                                             )
        {
            _get_new_shift_calendar_request = Guard.IsNotNull(the_get_new_shift_calendar_request,
                                                                                "the_get_new_shift_calendar_request"
                                                                             );
            _new_shift_calendar_request_editor_builder = Guard.IsNotNull(the_new_shift_calendar_request_editor_builder,
                                                                                "the_new_shift_calendar_request_editor_builder"
                                                                             );
        }

        private readonly IGetNewShiftCalendarRequest _get_new_shift_calendar_request;
        private readonly EditorBuilder<NewShiftCalendarRequest> _new_shift_calendar_request_editor_builder;
    }
}