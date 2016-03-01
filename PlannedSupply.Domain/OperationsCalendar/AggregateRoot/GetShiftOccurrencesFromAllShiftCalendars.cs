using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class GetShiftOccurrencesFromAllShiftCalendars
    {
        public List<ShiftCalendarOccurencesCountDetails> execute(ShiftOccurrenceIdentity the_shift)
        {
            var shift_occurrence = _get_shift_occurrence.execute(the_shift);
            time_allocation = shift_occurrence.time_allocation;

            operational_calendar = _operational_calander_repository.Entities.Single(oc => oc.id == the_shift.operations_calendar_id);
            var all_shift_calendars = operational_calendar.ShiftCalendars.Select(x => x).OrderByDescending(x => x.id).ToList();

            foreach (var calendar in all_shift_calendars)
            {
                occurrences_from_a_shift_calendar(calendar);
            }

            return all_shift_calendar_occurrences;
        }

        private void occurrences_from_a_shift_calendar(ShiftCalendars.ShiftCalendar the_shift_calendar)
        {
            var number_of_occurrences_for_each_calendar = operational_calendar.ShiftCalendars
                .Where(sc => sc.id == the_shift_calendar.id)
                .SelectMany(scp => scp.ShiftCalendarPatterns)
                .SelectMany(oc => oc.TimeAllocationOccurrences
                .Where(o => o.time_allocation.id == time_allocation.id)).Count();

            if (number_of_occurrences_for_each_calendar != 0)
            {
                all_shift_calendar_occurrences.Add(new ShiftCalendarOccurencesCountDetails() { name = the_shift_calendar.calendar_name, count = number_of_occurrences_for_each_calendar });
            }            
        }

        public GetShiftOccurrencesFromAllShiftCalendars(IEntityRepository<OperationalCalendar> the_operational_calander_repository,
                        GetOccurrence the_get_shift_occurrence
                       )
        {
            _operational_calander_repository = Guard.IsNotNull(the_operational_calander_repository,
                                                               "the_operational_calander_repository"
                                                              );
            _get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
        }

        private readonly IEntityRepository<OperationalCalendar> _operational_calander_repository;
        private readonly GetOccurrence _get_shift_occurrence;

        private OperationalCalendar operational_calendar;
        private TimeAllocations.TimeAllocation time_allocation;
        private List<ShiftCalendarOccurencesCountDetails> all_shift_calendar_occurrences = new List<ShiftCalendarOccurencesCountDetails>();
    }
}