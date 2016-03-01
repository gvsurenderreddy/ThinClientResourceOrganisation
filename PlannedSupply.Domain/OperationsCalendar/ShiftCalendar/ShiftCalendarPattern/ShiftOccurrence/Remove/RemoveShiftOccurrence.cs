using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove
{
    public class RemoveShiftOccurrence : IRemoveShiftOccurrence
    {
        public RemoveShiftOccurrenceResponse execute(ShiftOccurrenceIdentity the_request)
        {
            return set_request(the_request)
                        .get_the_shift_calendar_pattern()
                        .find_and_remove_the_occurrence()
                        .commit()
                        .build_response();
        }

        private RemoveShiftOccurrence set_request(ShiftOccurrenceIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private RemoveShiftOccurrence get_the_shift_calendar_pattern()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            shift_calendar_pattern = get_shift_calendar_pattern.execute(request);
            return this;
        }

        private RemoveShiftOccurrence find_and_remove_the_occurrence()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_calendar_pattern, "shift_calendar_pattern");
            Guard.IsNotNull(operational_calendar_repository, "operational_calendar_repository");

            var occurrence = get_occurrence.execute(request);

            shift_calendar_pattern.TimeAllocationOccurrences.Remove(occurrence);
            operational_calendar_repository.remove(occurrence);

            return this;
        }

        private RemoveShiftOccurrence commit()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            unit_of_work.Commit();

            response_builder.add_message(ConfirmationMessages.confirmation_04_0038);
            return this;
        }

        private RemoveShiftOccurrenceResponse build_response()
        {
            if (response_builder.has_errors)
                response_builder.add_error("An error occurred.");

            return response_builder.build();
        }

        public RemoveShiftOccurrence(IEntityRepository<OperationalCalendar> the_operational_calendar_repository,
                                        IUnitOfWork the_unit_of_work,
                                        GetShiftCalendarPattern the_get_shift_calendar_pattern,
                                        GetOccurrence the_get_occurrence)
        {

            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
            get_shift_calendar_pattern = Guard.IsNotNull(the_get_shift_calendar_pattern, "the_get_shift_calendar_pattern");
            get_occurrence = Guard.IsNotNull(the_get_occurrence, "the_get_occurrence");

            response_builder = new ResponseBuilder<RemoveShiftOccurrenceResponse>();
        }

        private readonly IUnitOfWork unit_of_work;
        private ShiftOccurrenceIdentity request;

        private ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern;

        private readonly ResponseBuilder<RemoveShiftOccurrenceResponse> response_builder;
        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;


        private readonly GetOccurrence get_occurrence;
        private readonly GetShiftCalendarPattern get_shift_calendar_pattern;
    }
}
