using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetShiftDetailsByStartDate;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;
using WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.ShiftTimeAllocationPaletteBuilderFactory;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftTimeAllocationPalette
{
    public class ShiftTimeAllocationPalettePresenter : Presenter
    {
        public ActionResult page(TimeBlockIdentity request)
        {
            var shift_occurrence_id = get_shift_query.execute(request).result;

            var view_model = builder.build(shift_occurrence_id);

            return View(@"~\Views\Shared\Views\ShiftTimeAllocationPalette.cshtml", view_model);
        }

        public ShiftTimeAllocationPalettePresenter(IGetShiftOccurrenceByStartDate the_get_shift_query,
                                                DependencyResolverShiftTimeAllocationPaletteBuilderFactory<ShiftOccurrenceDetails> the_builder_factory)
        {
            get_shift_query = Guard.IsNotNull(the_get_shift_query, "the_get_shift_query");

            builder = Guard.IsNotNull(the_builder_factory, "the_builder_factory")
                .create_builder();
        }

        private readonly BuildDynamicShiftTimeAllocationPaletteFromStaticDefinition<ShiftOccurrenceDetails> builder;
        private readonly IGetShiftOccurrenceByStartDate get_shift_query;

    }

}