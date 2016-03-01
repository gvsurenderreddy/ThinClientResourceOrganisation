using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.AggregateRoot.FindOrCreate
{
    public class FindOrCreateAndReturnTimeAllocationRequestHelper : IRequestHelper<FindOrCreateAndReturnTimeAllocationRequest>
    {
        public FindOrCreateAndReturnTimeAllocationRequest given_a_valid_request()
        {
            var operation_calendar = get_an_operation_calendar(-111);

            repository.add(operation_calendar);


            return new FindOrCreateAndReturnTimeAllocationRequest()
            {
                shift = new FindOrCreateAndReturnTimeAllocationShiftRequest()
                {
                    operations_calendar_id = operation_calendar.id,
                    shift_title = "new_shift",
                    start_time = new TimeRequest()
                    {
                        hours = "1",
                        minutes = "0"
                    },
                    colour = new Library.DomainTypes.Colour.RGBColourRequest()
                    {
                        R = 10,
                        G = 10,
                        B = 10
                    },
                    duration = new Library.DomainTypes.Duration.DurationRequest()
                    {
                        hours = "12",
                        minutes = "0"
                    },
                    originated_from_client = true
                },
                breaks = new List<FindOrCreateAndReturnTimeAllocationBreakRequest>()
                {
                    new FindOrCreateAndReturnTimeAllocationBreakRequest()
                    {
                        off_set = new Library.DomainTypes.Duration.DurationRequest()
                        {
                            hours = "1",
                            minutes = "0"
                        },
                        duration = new Library.DomainTypes.Duration.DurationRequest()
                        {
                            hours = "1",
                            minutes = "0"
                        },
                        is_paid = false,
                        originated_from_client = true
                    }
                }
            };
        }

        private OperationsCalendars.OperationalCalendar get_an_operation_calendar(int id)
        {
            return new OperationsCalendars.OperationalCalendar()
            {
                id = id,
                calendar_name = "seed_cal"
            };
        }

        public FindOrCreateAndReturnTimeAllocationRequestHelper(IEntityRepository<OperationsCalendars.OperationalCalendar> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IEntityRepository<OperationsCalendars.OperationalCalendar> repository;
    }
}
