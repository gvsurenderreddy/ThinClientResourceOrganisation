using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Presentation.Edit
{
    public class EditShiftBreakForAllOccurrencesEditorPresenter : Presenter
    {
        public ActionResult Editor(ShiftBreakIdentity shift_break_identity)
        {
            var edit_request = get_edit_request.execute(shift_break_identity).result;

            var view_model = editor_builder
                                    .build(edit_request.ToEditShiftBreakForAllOccurrencesRequest())
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public EditShiftBreakForAllOccurrencesEditorPresenter(IGetEditShiftBreakRequest the_get_edit_request
                                            , EditorBuilder<EditShiftBreakForAllOccurrencesRequest> the_editor_builder)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_edit_request = Guard.IsNotNull(the_get_edit_request, "the_get_edit_request");
        }

        private readonly IGetEditShiftBreakRequest get_edit_request;
        private readonly EditorBuilder<EditShiftBreakForAllOccurrencesRequest> editor_builder;

    }
}