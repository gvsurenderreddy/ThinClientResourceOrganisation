using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Edit.Presentation.Editor
{
    public class OperationsCalendarDetailsEditorPresenter
                            : Presenter
    {
        public ActionResult Editor( OperationsCalendarIdentity operations_calendar_identity )
        {
            UpdateOperationsCalendarRequest update_operations_calendar_request = _get_update_operations_calendar_request.execute( operations_calendar_identity ).result;

            var view_model = _update_operations_calendar_request_editor_builder
                                    .build(update_operations_calendar_request)
                                    ;

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public OperationsCalendarDetailsEditorPresenter(    IGetUpdateOperationsCalendarRequest the_get_update_operations_calendar_request,
                                                            EditorBuilder< UpdateOperationsCalendarRequest > the_update_operations_calendar_request_editor_builder
                                                       )
        {
            _get_update_operations_calendar_request             = Guard.IsNotNull(  the_get_update_operations_calendar_request,
                                                                                    "the_get_update_operations_calendar_request"
                                                                                 );
            _update_operations_calendar_request_editor_builder  = Guard.IsNotNull(  the_update_operations_calendar_request_editor_builder,
                                                                                    "the_update_operations_calendar_request_editor_builder"
                                                                                 );
        }

        private readonly IGetUpdateOperationsCalendarRequest _get_update_operations_calendar_request;
        private EditorBuilder<UpdateOperationsCalendarRequest> _update_operations_calendar_request_editor_builder;
    }
}