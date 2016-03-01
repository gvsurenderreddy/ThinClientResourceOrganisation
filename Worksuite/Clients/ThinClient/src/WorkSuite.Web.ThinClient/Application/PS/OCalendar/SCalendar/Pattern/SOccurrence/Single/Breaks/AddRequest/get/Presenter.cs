using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.New
{
    public class NewShiftBreakEditorPresenter : Presenter
    {
        public ActionResult Editor(ShiftOccurrenceIdentity shift_occurrence_identity)
        {
            var new_request = get_new_request.execute(shift_occurrence_identity).result;

            var view_model = editor_builder
                                    .build(new_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewShiftBreakEditorPresenter(IGetNewShiftBreakRequest the_get_new_request
                                            , EditorBuilder<NewShiftBreakRequest> the_editor_builder)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_new_request = Guard.IsNotNull(the_get_new_request, "the_get_new_request");
        }

        private readonly IGetNewShiftBreakRequest get_new_request;
        private readonly EditorBuilder<NewShiftBreakRequest> editor_builder;

    }
}