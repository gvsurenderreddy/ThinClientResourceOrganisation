using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetAllDetails;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.GetAll;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.EditAll.Presentation.Page
{
    public class EditAllShiftOccurrencesPresenter : Presenter
    {
        public ActionResult Page(ShiftOccurrenceIdentity request)
        {
            var report_details = get_all_occurrences_details.execute(request).result;
            var details_list_data = get_all_shift_breaks.execute(request).result.ToShiftBreakDetailsForAllOccurrences();

            view_model_builder.add_report(report_details)
                                .add_details_list(details_list_data);


            var view_model = new ShiftOccurrenceIdentityViewModel()
            {
                identity = request,
                view_elements = view_model_builder.build()
            };

            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\ShiftOccurrence\EditAll\Page.cshtml", view_model);
        }

        public EditAllShiftOccurrencesPresenter(IGetAllOccurrencesDetails the_get_all_occurrences_details,
                                                IGetAllShiftBreaks the_get_all_shift_breaks,
                                                AViewModelBuilder the_view_model_builder)
        {
            get_all_occurrences_details = Guard.IsNotNull(the_get_all_occurrences_details, "the_get_all_occurrences_details");
            view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
            get_all_shift_breaks = Guard.IsNotNull(the_get_all_shift_breaks, "the_get_all_shift_breaks");
        }

        private readonly IGetAllOccurrencesDetails get_all_occurrences_details;
        private readonly AViewModelBuilder view_model_builder;

        private readonly IGetAllShiftBreaks get_all_shift_breaks;
    }
}