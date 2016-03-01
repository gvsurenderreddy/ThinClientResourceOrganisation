using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.AggregateRoot.FindOrCreate
{
    public class FindOrCreateAndReturnTimeAllocationFixture
    {
        public FindOrCreateAndReturnTimeAllocationRequest request { get; private set; }
        public FindOrCreateAndReturnTimeAllocationResponse response { get; private set; }

        public TimeAllocations.TimeAllocation seed_a_time_allocation_with_this_signature_before_command_executes(FindOrCreateAndReturnTimeAllocationRequest the_seed_request)
        {
            var operation_calendar = repository.Entities.Single(oc => oc.id == the_seed_request.shift.operations_calendar_id);

            var time_allocation = build_time_allocation_from(the_seed_request);

            var breaks = build_breaks_from(the_seed_request);

            breaks.Do(breakk => time_allocation.TimeAllocationBreaks.Add(breakk));

            operation_calendar.TimeAllocations.Add(time_allocation);

            return time_allocation;
        }

        public ICollection<TimeAllocations.TimeAllocation> existing_time_allocations
        {
            get
            {
                return repository.Entities.Single(oc => oc.id == request.shift.operations_calendar_id).TimeAllocations;
            }
        }

        public void execute_command()
        {
            response = command.execute(request);
        }

        public FindOrCreateAndReturnTimeAllocationFixture(FindOrCreateAndReturnTimeAllocation the_command,
                                                            IRequestHelper<FindOrCreateAndReturnTimeAllocationRequest> the_request_builder,
                                                            IEntityRepository<OperationsCalendars.OperationalCalendar> the_repository)
        {
            command = Guard.IsNotNull(the_command, "the_command");
            request = Guard.IsNotNull(the_request_builder, "the_request_builder").given_a_valid_request();

            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly FindOrCreateAndReturnTimeAllocation command;
        private readonly IEntityRepository<OperationsCalendars.OperationalCalendar> repository;

        private TimeAllocations.TimeAllocation build_time_allocation_from(FindOrCreateAndReturnTimeAllocationRequest the_seed_request)
        {
            Guard.IsNotNull(the_seed_request, "the_seed_request");

            return new TimeAllocations.TimeAllocation()
            {
                title = the_seed_request.shift.shift_title,
                colour = to_persistence_string(the_seed_request.shift.colour),
                start_time_in_seconds_from_midnight = the_seed_request.shift.start_time.to_Seconds(),
                duration_in_seconds = the_seed_request.shift.duration.to_seconds()
            };
        }

        private IEnumerable<TimeAllocationBreak> build_breaks_from(FindOrCreateAndReturnTimeAllocationRequest the_seed_request)
        {
            Guard.IsNotNull(the_seed_request, "the_seed_request");

            var breaks = the_seed_request.breaks.Select(br => new TimeAllocationBreak()
            {
                offset_from_start_time_in_seconds = br.off_set.to_seconds(),
                duration_in_seconds = br.duration.to_seconds(),
                is_paid = br.is_paid
            });

            return breaks.ToList();
        }

        private string to_persistence_string(RGBColourRequest source)
        {
            Guard.IsNotNull(source, "source");
            return string.Format("{0},{1},{2}", source.R, source.G, source.B);
        }

    }
}
