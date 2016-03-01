using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.Edit.Editor
{
    public class ShiftCalendarDetailsEditorPresenter
                        : Presenter
    {
        public ActionResult Editor(ShiftCalendarIdentity the_shift_calendar_identity)
        {
            UpdateShiftCalendarRequest update_shift_calendar_request = _get_update_shift_calendar_request
                                                                            .execute(the_shift_calendar_identity)
                                                                            .result
                                                                            ;

            var view_model = _update_shift_calendar_request_editor_builder
                                    .build(update_shift_calendar_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public ShiftCalendarDetailsEditorPresenter(IGetUpdateShiftCalendarRequest the_get_update_shift_calendar_request,
                                                    EditorBuilder<UpdateShiftCalendarRequest> the_update_shift_calendar_request_editor_builder
                                                  )
        {
            _get_update_shift_calendar_request = Guard.IsNotNull(the_get_update_shift_calendar_request,
                "the_get_update_shift_calendar_request");
            _update_shift_calendar_request_editor_builder = Guard.IsNotNull(the_update_shift_calendar_request_editor_builder,
                "the_update_shift_calendar_request_editor_builder");
        }

        private readonly IGetUpdateShiftCalendarRequest _get_update_shift_calendar_request;
        private readonly EditorBuilder<UpdateShiftCalendarRequest> _update_shift_calendar_request_editor_builder;
    }
}