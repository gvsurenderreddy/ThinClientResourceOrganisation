using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetSingleDetails;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.GetAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Edit.Presentation.Page
{
    public class EditSingleShiftOccurrencePresenter : Presenter
    {
        public ActionResult Page(ShiftOccurrenceIdentity request)
        {
            view_model_builder.add_report(get_single_shift_occurrence.execute(request).result)
                                .add_details_list(get_all_shift_breaks.execute(request).result);

            var view_model = new ShiftOccurrenceIdentityViewModel()
            {
                identity = request,
                view_elements = view_model_builder.build()
            };

            return View(@"~\Views\Operations\OperationalCalendars\PlannedSupply\ShiftOccurrence\Edit\Page.cshtml", view_model);
        }

        public EditSingleShiftOccurrencePresenter(AViewModelBuilder the_view_model_builder,
                                                    IGetSingleOccurrenceDetails the_get_single_shift_occurrence,
                                                    IGetAllShiftBreaks the_get_all_shift_breaks)
        {
            get_single_shift_occurrence = Guard.IsNotNull(the_get_single_shift_occurrence, "the_get_single_shift_occurrence");
            get_all_shift_breaks = Guard.IsNotNull(the_get_all_shift_breaks, "the_get_all_shift_breaks");

            view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
        }

        private readonly IGetSingleOccurrenceDetails get_single_shift_occurrence;
        private readonly IGetAllShiftBreaks get_all_shift_breaks;

        private readonly AViewModelBuilder view_model_builder;
    }
}