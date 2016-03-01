using System;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.View.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.View.Page
{
    public class PlannedSupplyPresenter
                        : Presenter
    {
        public ActionResult Page(GetOperationsCalendarAggregateOverRangeRequest the_operations_calendar)
        {

            var view_model = _operations_calendar_details_view_model_builder
                                    .For(the_operations_calendar)
                                    .build()
                                    ;

            var the_view_model = new OperationalCalendarIdentityViewModel
            {
                identity = the_operations_calendar,
                view_elements = view_model
            };

            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\View\Page.cshtml", the_view_model);
        }

        public PlannedSupplyPresenter( PlannedSupplyViewModelBuilder _the_operations_calendar_details_view_model_builder )
        {
            _operations_calendar_details_view_model_builder = Guard.IsNotNull(_the_operations_calendar_details_view_model_builder,
                                                                                "_the_operations_calendar_details_view_model_builder"
                                                                             );
        }

        private readonly PlannedSupplyViewModelBuilder _operations_calendar_details_view_model_builder;
    }
}