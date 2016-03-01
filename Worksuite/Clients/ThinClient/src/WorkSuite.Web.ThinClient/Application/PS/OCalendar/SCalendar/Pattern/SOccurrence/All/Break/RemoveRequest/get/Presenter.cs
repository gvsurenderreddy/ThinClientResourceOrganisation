﻿using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Presentation.Remove
{
    public class RemoveShiftBreakForAllOccurrencesEditorPresenter : Presenter
    {
        public ActionResult Editor(ShiftBreakIdentity shift_break_identity)
        {
            var remove_request = get_remove_request.execute(shift_break_identity).result;

            var view_model = editor_builder
                                    .build(remove_request.ToRemoveShiftBreakForAllOccurrencesRequest())
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public RemoveShiftBreakForAllOccurrencesEditorPresenter(IGetRemoveShiftBreakRequest the_get_remove_request
                                            , EditorBuilder<RemoveShiftBreakForAllOccurrencesRequest> the_editor_builder)
        {
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            get_remove_request = Guard.IsNotNull(the_get_remove_request, "the_get_remove_request");
        }

        private readonly IGetRemoveShiftBreakRequest get_remove_request;
        private readonly EditorBuilder<RemoveShiftBreakForAllOccurrencesRequest> editor_builder;

    }
}