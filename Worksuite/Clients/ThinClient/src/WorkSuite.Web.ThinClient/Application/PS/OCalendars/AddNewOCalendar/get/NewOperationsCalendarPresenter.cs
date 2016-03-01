using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.GetCreateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.New.Presentation.Page
{
    public class NewOperationsCalendarPresenter
                        : Presenter
    {
        public ActionResult Page()
        {
            var request     = _get_new_operations_calendar_request
                                    .execute();
            var view_model  = _new_operations_calendar_request_editor_builder
                                    .build( request );

            return View( @"~\Views\Operations\OperationalCalendars\New\Page.cshtml", view_model );
        }

        
        public NewOperationsCalendarPresenter(  IGetNewOperationsCalendarRequest the_get_new_operations_calendar_request,
                                                EditorBuilder< NewOperationsCalendarRequest > the_new_operations_calendar_request_editor_builder
                                             )
        {
            _get_new_operations_calendar_request            = Guard.IsNotNull(  the_get_new_operations_calendar_request,
                                                                                "the_get_new_operations_calendar_request" 
                                                                             );
            _new_operations_calendar_request_editor_builder = Guard.IsNotNull(  the_new_operations_calendar_request_editor_builder,
                                                                                "the_new_operations_calendar_request_editor_builder"
                                                                             );
        }

        private readonly IGetNewOperationsCalendarRequest _get_new_operations_calendar_request;
        private readonly EditorBuilder< NewOperationsCalendarRequest > _new_operations_calendar_request_editor_builder;
         
    }
}