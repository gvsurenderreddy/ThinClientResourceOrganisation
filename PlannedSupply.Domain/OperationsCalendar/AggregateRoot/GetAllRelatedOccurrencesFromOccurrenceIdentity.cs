using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class GetAllRelatedOccurrencesFromOccurrenceIdentity
    {
        public IEnumerable<GetAllRelatedOccurrencesItem> execute(ShiftOccurrenceIdentity request)
        {

            Guard.IsNotNull(request, "request");


            var operational_calendar = operational_calendar_repository
                                        .Entities
                                        .Single(oc => oc.id == request.operations_calendar_id)
                                        ;


            var occurrence = get_shift_occurrence.execute(request);


            var time_allocation = occurrence.time_allocation;

            return operational_calendar
                    .ShiftCalendars
                    .SelectMany(sc => sc.ShiftCalendarPatterns
                                        .SelectMany(p => p.TimeAllocationOccurrences
                                                            .Where(oc => oc.time_allocation.id == time_allocation.id).Select(occ => new GetAllRelatedOccurrencesItem()
                                                            {
                                                                occurrence = occ,
                                                                pattern = p
                                                            })));
        }


        public GetAllRelatedOccurrencesFromOccurrenceIdentity(IEntityRepository<OperationalCalendar> the_operational_calendar_repository,
                                                                GetOccurrence the_get_shift_occurrence)
        {
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "request");
        }

        private readonly GetOccurrence get_shift_occurrence;
        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;
    }


    public class GetAllRelatedOccurrencesItem
    {
        public TimeAllocationOccurrences.TimeAllocationOccurrence occurrence { get; set; }

        public ShiftCalendarPatterns.ShiftCalendarPattern pattern { get; set; }
    }

}
