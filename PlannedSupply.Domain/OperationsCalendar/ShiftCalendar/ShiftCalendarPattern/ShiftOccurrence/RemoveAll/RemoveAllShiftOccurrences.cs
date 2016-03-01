using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll
{
    public class RemoveAllShiftOccurrences : IRemoveAllShiftOccurrences
    {
        public RemoveAllShiftOccurrencesResponse execute(ShiftOccurrenceIdentity the_request)
        {
            return set_request(the_request)
                  .find_and_remove_all_occurrences_of_same_type()
                  .commit()
                  .build_response();
        }

        private RemoveAllShiftOccurrences set_request(ShiftOccurrenceIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private RemoveAllShiftOccurrences find_and_remove_all_occurrences_of_same_type()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(operational_calendar_repository, "operational_calendar_repository");

            var all_occurrences = get_all_related_occurrences.execute(request).ToList();

            all_occurrences.Do(i =>
            {
                i.pattern.TimeAllocationOccurrences.Remove(i.occurrence);
                operational_calendar_repository.remove(i.occurrence);
            });

            return this;
        }

        private RemoveAllShiftOccurrences commit()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            unit_of_work.Commit();

            response_builder.add_message(ConfirmationMessages.confirmation_04_0038);
            return this;
        }

        private RemoveAllShiftOccurrencesResponse build_response()
        {
            if (response_builder.has_errors)
                response_builder.add_error("An error occurred.");

            return response_builder.build();
        }

        public RemoveAllShiftOccurrences(IEntityRepository<OperationalCalendar> the_operational_calendar_repository,
                                        IUnitOfWork the_unit_of_work,
                                        GetAllRelatedOccurrencesFromOccurrenceIdentity the_get_all_related_occurrences)
        {

            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
            get_all_related_occurrences = Guard.IsNotNull(the_get_all_related_occurrences, "the_get_all_related_occurrences");

            response_builder = new ResponseBuilder<RemoveAllShiftOccurrencesResponse>();
        }

        private readonly IUnitOfWork unit_of_work;
        private ShiftOccurrenceIdentity request;

        private readonly ResponseBuilder<RemoveAllShiftOccurrencesResponse> response_builder;
        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;
        private readonly GetAllRelatedOccurrencesFromOccurrenceIdentity get_all_related_occurrences;
    }
}