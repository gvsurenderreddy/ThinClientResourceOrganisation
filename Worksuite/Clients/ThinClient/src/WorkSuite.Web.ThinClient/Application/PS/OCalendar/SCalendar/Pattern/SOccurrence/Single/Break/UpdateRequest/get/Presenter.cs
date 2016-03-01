using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.Edit
{
    public class EditShiftBreakEditorPresenter : Presenter
    {
        public ActionResult Editor(ShiftBreakIdentity shift_break_identity)
        {
            var new_request = get_edit_request.execute(shift_break_identity).result;

            var view_model = editor_builder
                                    .build(new_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public EditShiftBreakEditorPresenter(IGetEditShiftBreakRequest the_get_edit_request
                                            , EditorBuilder<EditShiftBreakRequest> the_editor_builder)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_edit_request = Guard.IsNotNull(the_get_edit_request, "the_get_edit_request");
        }

        private readonly IGetEditShiftBreakRequest get_edit_request;
        private readonly EditorBuilder<EditShiftBreakRequest> editor_builder;

    }
}