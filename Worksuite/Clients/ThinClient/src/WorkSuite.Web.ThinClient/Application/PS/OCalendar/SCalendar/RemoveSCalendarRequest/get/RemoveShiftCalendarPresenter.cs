using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.Remove.Editor
{
    public class RemoveShiftCalendarPresenter
                        : Presenter
    {
        public ActionResult Editor(ShiftCalendarIdentity the_shift_calendar_identity)
        {
            RemoveShiftCalendarRequest remove_shift_calendar_request = _get_remove_shift_calendar_request
                                                                                .execute(the_shift_calendar_identity)
                                                                                .result
                                                                                ;

            var view_model = _remove_shift_calendar_request_editor_builder
                                        .build(remove_shift_calendar_request)
                                        ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public RemoveShiftCalendarPresenter(EditorBuilder<RemoveShiftCalendarRequest> the_remove_shift_calendar_request_editor_builder,
                                            IGetRemoveShiftCalendarRequest the_get_remove_shift_calendar_request
                                           )
        {
            _remove_shift_calendar_request_editor_builder =
                Guard.IsNotNull(the_remove_shift_calendar_request_editor_builder,
                    "the_remove_shift_calendar_request_editor_builder");

            _get_remove_shift_calendar_request = Guard.IsNotNull(the_get_remove_shift_calendar_request,
                "the_get_remove_shift_calendar_request");
        }

        private EditorBuilder<RemoveShiftCalendarRequest> _remove_shift_calendar_request_editor_builder;
        private readonly IGetRemoveShiftCalendarRequest _get_remove_shift_calendar_request;
    }
}