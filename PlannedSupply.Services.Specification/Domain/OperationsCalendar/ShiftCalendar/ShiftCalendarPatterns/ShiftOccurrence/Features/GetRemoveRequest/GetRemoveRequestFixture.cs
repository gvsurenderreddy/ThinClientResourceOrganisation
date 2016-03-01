using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetRemoveRequest
{
    public class GetRemoveRequestFixture : ResponseCommandFixture<ShiftOccurrenceIdentity, Response<RemoveShiftOccurrenceRequest>, IGetRemoveShiftOccurrenceRequest>
    {
        public TimeAllocation time_allocation()
        {
            return operations_calendar_repository
                                            .Entities.Single(o => o.id == request.operations_calendar_id)
                                            .ShiftCalendars
                                            .Single(sc => sc.id == request.shift_calendar_id)
                                            .ShiftCalendarPatterns
                                            .Single(scp => scp.id == request.shift_calendar_pattern_id)
                                            .TimeAllocationOccurrences.SingleOrDefault(oc => oc.id == request.shift_occurrence_id).time_allocation;
        }

        private OperationalCalendar OperationalCalendar()
        {
            var operational_calendar =
                operations_calendar_repository.Entities.Single(oc => oc.id == request.operations_calendar_id);
            return operational_calendar;
        }

        private IEnumerable<ShiftCalendars.ShiftCalendar> ShiftCalanders()
        {
            var shift_calanders = operations_calendar_repository
                .Entities.Single(o => o.id == request.operations_calendar_id)
                .ShiftCalendars.Select(x => x).OrderByDescending(x => x.id).ToList();
            return shift_calanders;
        }

        private int time_allocation_occurrence()
        {
            var operational_calendar =
                operations_calendar_repository.Entities.Single(oc => oc.id == request.operations_calendar_id);

            var shift_calendar = operational_calendar.ShiftCalendars.Single(sc => sc.id == request.shift_calendar_id);

            var shift_calendar_pattern =
                shift_calendar.ShiftCalendarPatterns.Single(sc => sc.id == request.shift_calendar_pattern_id);

            int shift_occurrence =
                shift_calendar_pattern.TimeAllocationOccurrences.Single(sc => sc.id == request.shift_occurrence_id).time_allocation.id;
            return shift_occurrence;
        }

        public IEnumerable<ShiftCalendarOccurencesCountDetails> get_number_of_occurrences_and_shiftcalendar_name()
        {
            var time_allocation = time_allocation_occurrence();
            var shift_calanders = ShiftCalanders();
            var operational_calendar = OperationalCalendar();

            shift_calendar_name_and_number_of_occurrences = new List<ShiftCalendarOccurencesCountDetails>();

            foreach (var calendar in shift_calanders)
            {
                var number_of_occurrences_for_each_calendar = operational_calendar.ShiftCalendars
                    .Where(sc => sc.id == calendar.id)
                    .SelectMany(sc => sc.ShiftCalendarPatterns)
                    .SelectMany(scp => scp.TimeAllocationOccurrences
                    .Where(oc => oc.time_allocation.id == time_allocation)).Count();

                if (number_of_occurrences_for_each_calendar != 0)
                {
                    shift_calendar_name_and_number_of_occurrences.Add(new ShiftCalendarOccurencesCountDetails() { name = calendar.calendar_name, count = number_of_occurrences_for_each_calendar });
                }

            }
            return shift_calendar_name_and_number_of_occurrences;
        }


        public GetRemoveRequestFixture(IGetRemoveShiftOccurrenceRequest the_command,
                                      IRequestHelper<ShiftOccurrenceIdentity> the_request,
                                      FakeOperationsCalendarRepository the_operations_calendar_repository
                                     )
            : base(the_command, the_request)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
        }

        private readonly FakeOperationsCalendarRepository operations_calendar_repository;

        private List<ShiftCalendarOccurencesCountDetails> shift_calendar_name_and_number_of_occurrences;
    }
}
