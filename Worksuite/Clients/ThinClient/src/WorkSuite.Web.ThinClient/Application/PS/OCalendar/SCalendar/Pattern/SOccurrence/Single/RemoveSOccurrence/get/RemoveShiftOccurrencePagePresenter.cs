using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Remove.Presentation.Page
{
    public class RemoveShiftOccurrencePagePresenter : Presenter
    {
        public ActionResult Page(ShiftOccurrenceIdentity shift_occurrence_identity)
        {
            var remove_request = get_remove_request.execute(shift_occurrence_identity).result;

            var view_model = editor_builder.build(remove_request);

            var the_view_model = new OperationalCalendarIdentityViewModel
            {
                identity = new OperationsCalendarIdentity() { operations_calendar_id = shift_occurrence_identity.operations_calendar_id },
                view_elements = new List<IsAViewElement>() { view_model }
            };

            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\ShiftOccurrence\Remove\Page.cshtml", the_view_model);
        }


        public RemoveShiftOccurrencePagePresenter(EditorBuilder<RemoveShiftOccurrenceRequest> the_editor_builder,
                                                    IGetRemoveShiftOccurrenceRequest the_get_remove_request)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_remove_request = Guard.IsNotNull(the_get_remove_request, "the_get_remove_request");
        }

        private readonly EditorBuilder<RemoveShiftOccurrenceRequest> editor_builder;
        private readonly IGetRemoveShiftOccurrenceRequest get_remove_request;
    }
}