using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.EditAll.Presentation.Editor
{
    public class AllOccurrencesDetailsEditorPresenter : Presenter
    {
        public ActionResult Editor(ShiftOccurrenceIdentity request)
        {
            var details = get_edit_request.execute(request).result;

            var view_model = editor_builder.build(details);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public AllOccurrencesDetailsEditorPresenter(IGetEditAllShiftOccurrencesRequest the_get_edit_request,
                                                    EditorBuilder<EditAllShiftOccurrencesRequest> the_editor_builder)
        {
            get_edit_request = Guard.IsNotNull(the_get_edit_request, "the_get_edit_request");
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
        }

        private readonly IGetEditAllShiftOccurrencesRequest get_edit_request;
        private readonly EditorBuilder<EditAllShiftOccurrencesRequest> editor_builder;
    }
}