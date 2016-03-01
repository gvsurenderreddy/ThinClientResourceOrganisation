using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.removePattern.get
{
    public class RemovePatternPresenter : Presenter
    {
        public RemovePatternPresenter(IGetRemoveShiftCalendarPatternRequest the_get_request, 
                                                            EditorBuilder<RemoveShiftCalendarPatternRequest> the_editor_builder)
        {
            get_remove_request = Guard.IsNotNull(the_get_request, "the_get_request");
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
        }

        public ActionResult Editor( ShiftCalendarPatternIdentity the_request )
        {
            var remove_request = get_remove_request.execute( the_request );
            var view_model = editor_builder.build( remove_request.result );

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        private readonly IGetRemoveShiftCalendarPatternRequest get_remove_request;
        private readonly EditorBuilder<RemoveShiftCalendarPatternRequest> editor_builder;
    }
}