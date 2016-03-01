using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Edit.Presentation.Editor
{
    public class SingleOccurrenceDetailsEditorPresenter : PartialPageIdentityPresenter
    {
        public ActionResult Editor(ShiftOccurrenceIdentity shift_occurrence_identity)
        {
            var update_request = get_update_request.execute(shift_occurrence_identity).result;

            var view_model = editor_builder
                                    .build(update_request)
                                    ; 

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public SingleOccurrenceDetailsEditorPresenter(IGetEditSingleShiftOccurrenceRequest the_get_update_request, 
                                                        EditorBuilder<EditSingleShiftOccurrenceRequest> the_editor_builder,
                                                        PartialPageIdentity the_partial_page_identity,
                                                        ICurrentPageIdentityRepository the_page_model_repository)
            : base(the_partial_page_identity, the_page_model_repository)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_update_request = Guard.IsNotNull(the_get_update_request, "the_get_update_request");
        }

        private readonly IGetEditSingleShiftOccurrenceRequest get_update_request;
        private readonly EditorBuilder<EditSingleShiftOccurrenceRequest> editor_builder;
    }
}