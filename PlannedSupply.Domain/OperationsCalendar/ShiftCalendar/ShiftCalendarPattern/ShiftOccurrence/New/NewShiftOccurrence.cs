using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New
{
    public class NewShiftOccurrence : INewShiftOccurrence
    {
        public NewShiftOccurrenceResponse execute(NewShiftOccurrenceRequest the_request)
        {
            return this
                .set_request(the_request)
                .build_find_or_create_request()
                .find_or_create_time_allocation()
                .get_the_shift_calendar_pattern()
                .create_time_allocation_occurrence()
                .commit()
                .build_response();
        }

        private NewShiftOccurrence set_request(NewShiftOccurrenceRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new ShiftOccurrenceIdentity()
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = Null.Id
            });

            return this;
        }

        private NewShiftOccurrence build_find_or_create_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            find_or_create_request = new FindOrCreateAndReturnTimeAllocationRequest()
            {
                shift = new FindOrCreateAndReturnTimeAllocationShiftRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    start_time = request.start_time,
                    duration = request.duration,
                    shift_title = request.shift_title,
                    colour = request.colour,
                    originated_from_client = true
                },
                breaks = Enumerable.Empty<FindOrCreateAndReturnTimeAllocationBreakRequest>()
            };

            return this;
        }

        private NewShiftOccurrence find_or_create_time_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(find_or_create_request, "find_or_create_request");

            get_or_create_time_allocation
                .execute(find_or_create_request)
                .Match(
                    was_successful: success_response =>
                    {
                        time_allocation = success_response.time_allocation;
                    },
                    had_errors: error_response =>
                    {
                        var errors =
                            error_response.filter_and_map_responses_by(error_reporting_policy);

                        response_builder.add_errors(errors);

                        error_response.Any(new HashSet<find_or_create_error_types>()
                       {
                           find_or_create_error_types.client_break,
                           find_or_create_error_types.internal_break,
                           find_or_create_error_types.internal_shift
                       }, delegate
                       {
                           throw new InternalCorruptDataException("Internal data corruption");
                       });
                    });

            return this;
        }

        private NewShiftOccurrence get_the_shift_calendar_pattern()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            shift_calendar_pattern = get_shift_calendar_pattern.execute(request);

            return this;
        }

        private NewShiftOccurrence create_time_allocation_occurrence()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(time_allocation, "time_allocation");
            Guard.IsNotNull(shift_calendar_pattern, "shift_calendar_pattern");

            create_time_allocation_for_occurrence.execute(new CreateTimeAllocationForOccurrenceRequest()
            {
                time_allocation = time_allocation,
               start_date = request.start_date,
               shift_calendar_pattern = shift_calendar_pattern
            })
            .Match(

                was_successful: success_response =>
                {
                    shift_occurrence = new TimeAllocationOccurrences.TimeAllocationOccurrence()
                    {
                        start_date = request.start_date,
                       time_allocation = success_response.time_allocation
                    };
                    shift_calendar_pattern.TimeAllocationOccurrences.Add(shift_occurrence);
                },

                had_errors: error_response =>
                {
                    var errors = error_response.filter_and_map_responses_by(error_reporting_policy);
                    response_builder.add_errors(errors);
                });

            return this;
        }

        private NewShiftOccurrence commit()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            unit_of_work.Commit();

            response_builder.set_response(new ShiftOccurrenceIdentity()
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = shift_occurrence.id
            });

            return this;
        }

        private NewShiftOccurrenceResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(WarningMessages.warning_03_0027);
            }
            else
            {
                response_builder.add_message(ConfirmationMessages.confirmation_04_0034);
            }

            return response_builder.build();
        }

        public NewShiftOccurrence( IUnitOfWork the_unit_of_work,
                                   FindOrCreateAndReturnTimeAllocation the_get_or_create_time_allocation,
                                   GetShiftCalendarPattern the_get_shift_calendar_pattern,
                                   ShiftErrorReportingPolicy the_error_reporting_policy,
                                   CreateTimeAllocationOccurrenceValidation the_create_time_allocation_for_occurrence)
        {

            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            get_or_create_time_allocation = Guard.IsNotNull(the_get_or_create_time_allocation, "get_or_create_time_allocation");
            get_shift_calendar_pattern = Guard.IsNotNull(the_get_shift_calendar_pattern, "the_get_shift_calendar_pattern");
            error_reporting_policy = Guard.IsNotNull(the_error_reporting_policy, "the_error_reporting_policy");
            create_time_allocation_for_occurrence = Guard.IsNotNull(the_create_time_allocation_for_occurrence, "the_create_time_allocation_for_occurrence");


            response_builder = new ResponseBuilder<ShiftOccurrenceIdentity, NewShiftOccurrenceResponse>();
        }

        private NewShiftOccurrenceRequest request;
        private readonly IUnitOfWork unit_of_work;
        private readonly ResponseBuilder<ShiftOccurrenceIdentity, NewShiftOccurrenceResponse> response_builder;

        private TimeAllocations.TimeAllocation time_allocation;

        private TimeAllocationOccurrences.TimeAllocationOccurrence shift_occurrence;

        private readonly FindOrCreateAndReturnTimeAllocation get_or_create_time_allocation;

        private FindOrCreateAndReturnTimeAllocationRequest find_or_create_request;

        private ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern;

        private readonly GetShiftCalendarPattern get_shift_calendar_pattern;

        private readonly ShiftErrorReportingPolicy error_reporting_policy;

        private readonly CreateTimeAllocationOccurrenceValidation create_time_allocation_for_occurrence;

    }
}



