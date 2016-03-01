using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Remove.Presentation.Editor
{
    public class RemoveOperationsCalendarPresenter
                        : Presenter
    {
        public ActionResult Editor( OperationsCalendarIdentity the_operations_calendar_identity )
        {
            RemoveOperationsCalendarRequest remove_operations_calendar_request = _get_remove_operations_calendar_request
                                                                                    .execute( the_operations_calendar_identity )
                                                                                    .result;

            var view_model = _remove_operations_calendar_request_editor_builder
                                    .build( remove_operations_calendar_request )
                                    ;

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public RemoveOperationsCalendarPresenter(   EditorBuilder<RemoveOperationsCalendarRequest> the_remove_operations_calendar_request_editor_builder,
                                                    IGetRemoveOperationsCalendarRequest   the_get_remove_operations_calendar_request
                                                )
        {
            _remove_operations_calendar_request_editor_builder  = Guard.IsNotNull(  the_remove_operations_calendar_request_editor_builder,
                                                                                    "the_remove_operations_calendar_request_editor_builder"
                                                                                 );
            _get_remove_operations_calendar_request             = Guard.IsNotNull(  the_get_remove_operations_calendar_request,
                                                                                    "the_get_remove_operations_calendar_request"
                                                                                 );
        }

        private EditorBuilder< RemoveOperationsCalendarRequest > _remove_operations_calendar_request_editor_builder;
        private readonly IGetRemoveOperationsCalendarRequest _get_remove_operations_calendar_request;
    }
}