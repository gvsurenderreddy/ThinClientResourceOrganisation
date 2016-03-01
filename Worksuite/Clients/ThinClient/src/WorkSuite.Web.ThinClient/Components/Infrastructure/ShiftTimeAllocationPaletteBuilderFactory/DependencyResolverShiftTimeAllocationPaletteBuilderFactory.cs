using System.Web.Mvc;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetShiftDetailsByStartDate;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic;

namespace WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.ShiftTimeAllocationPaletteBuilderFactory
{
    public class DependencyResolverShiftTimeAllocationPaletteBuilderFactory<S> where S : ShiftOccurrenceDetails
    {
        public BuildDynamicShiftTimeAllocationPaletteFromStaticDefinition<S> create_builder()
        {
            return DependencyResolver.Current.GetService<BuildDynamicShiftTimeAllocationPaletteFromStaticDefinition<S>>();
        }
    }
}