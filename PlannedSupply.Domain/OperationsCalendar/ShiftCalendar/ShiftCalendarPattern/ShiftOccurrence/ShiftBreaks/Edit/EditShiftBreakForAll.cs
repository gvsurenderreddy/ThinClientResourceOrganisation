using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit
{
    public class EditShiftBreakForAllOccurrences : IEditShiftBreakForAllOccurrences
    {
        public EditShiftBreakResponse execute(EditShiftBreakRequest the_request)
        {
            return
                set_request(the_request)
                    .get_the_shift_occurrence()
                    .get_the_break_to_be_edited()
                    .build_find_or_create_request()
                    .find_or_create_time_allocation()
                    .find_all_occurrences_of_same_type_and_change_their_time_allocation()
                    .commit()
                    .build_response();

        }

        private EditShiftBreakForAllOccurrences set_request(EditShiftBreakRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new ShiftOccurrenceIdentity
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id

            });

            return this;
        }

        private EditShiftBreakForAllOccurrences get_the_shift_occurrence()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            shift_occurrence = get_shift_occurrence.execute(request);

            return this;
        }

        private EditShiftBreakForAllOccurrences get_the_break_to_be_edited()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_occurrence, "shift_occurrence");
            Guard.IsNotNull(shift_occurrence.time_allocation, "shift_occurrence.time_allocation");
            Guard.IsNotNull(shift_occurrence.time_allocation.TimeAllocationBreaks, "shift_occurrence.time_allocation.TimeAllocationBreaks");


            the_break_to_be_edited = shift_occurrence.time_allocation.TimeAllocationBreaks.Single(eb => eb.id == request.shift_break_id);

            return this;
        }

        private EditShiftBreakForAllOccurrences build_find_or_create_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_occurrence, "shift_occurrence");
            Guard.IsNotNull(shift_occurrence.time_allocation, "shift_occurrence.time_allocation");
            Guard.IsNotNull(shift_occurrence.time_allocation.TimeAllocationBreaks, "shift_occurrence.time_allocation.TimeAllocationBreaks");

            //Get the breaks to be transformed without the one we want to edit
            var breaks_to_be_transformed = shift_occurrence
                                                    .time_allocation
                                                    .TimeAllocationBreaks
                                                    .Except(the_break_to_be_edited.ToEnumerable());


            //transform the breaks to the internal command break request
            var internal_break_requests = breaks_to_be_transformed.Select(b => new FindOrCreateAndReturnTimeAllocationBreakRequest()
            {
                off_set = b.offset_from_start_time_in_seconds.to_duration_request(),
                duration = b.duration_in_seconds.to_duration_request(),
                is_paid = b.is_paid,
                originated_from_client = false
            })

            //Add the break to be edited to the internal break requests
            .Union(new FindOrCreateAndReturnTimeAllocationBreakRequest()
            {
                off_set = request.off_set,
                duration = request.duration,
                is_paid = request.is_paid,
                originated_from_client = true
            }.ToEnumerable());

            find_or_create_request = new FindOrCreateAndReturnTimeAllocationRequest()
            {
                shift = new FindOrCreateAndReturnTimeAllocationShiftRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    start_time = shift_occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                    duration = shift_occurrence.time_allocation.duration_in_seconds.to_duration_request(),
                    shift_title = shift_occurrence.time_allocation.title,
                    colour = shift_occurrence.time_allocation.colour.to_rgb_colour_request_from_persistence_format(),
                    originated_from_client = false
                },
                breaks = internal_break_requests
            };

            return this;

        }

        private EditShiftBreakForAllOccurrences find_or_create_time_allocation()
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
                           find_or_create_error_types.internal_break,
                           find_or_create_error_types.internal_shift,
                           find_or_create_error_types.client_shift
                       }, delegate
                       {
                           throw new InternalCorruptDataException("Internal data corruption");
                       });
                   });

            return this;
        }

        private EditShiftBreakForAllOccurrences find_all_occurrences_of_same_type_and_change_their_time_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            var all_occurrences = get_all_related_occurrences.execute(request);

            all_occurrences.Do(i => modify_time_allocation_for_occurrence.execute(new ModifyTimeAllocationForOccurrenceRequest()
            {
                new_time_allocation = time_allocation,
                time_allocation_occurrence = i.occurrence
            }));

            return this;
        }

        private EditShiftBreakForAllOccurrences commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            response_builder.set_response(new ShiftBreakIdentity
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id

            });

            response_builder.add_message(ConfirmationMessages.confirmation_201501071422);
            return this;
        }

        private EditShiftBreakResponse build_response()
        {
            if (response_builder.has_errors)
                response_builder.add_error(WarningMessages.warning_03_0044);

            return response_builder.build();

        }

        public EditShiftBreakForAllOccurrences(IUnitOfWork the_unit_of_work,
                                                GetOccurrence the_get_shift_occurrence,
                                                GetAllRelatedOccurrencesFromOccurrenceIdentity the_get_all_related_occurrences,
                                                ModifyTimeAllocationForOccurrence the_modify_time_allocation_for_occurrence,
                                                FindOrCreateAndReturnTimeAllocation the_get_or_create_time_allocation,
                                                ShiftBreakErrorReportingPolicy the_error_reporting_policy)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
            get_all_related_occurrences = Guard.IsNotNull(the_get_all_related_occurrences, "the_get_all_related_occurrences");
            get_or_create_time_allocation = Guard.IsNotNull(the_get_or_create_time_allocation, "get_or_create_time_allocation");
            modify_time_allocation_for_occurrence = Guard.IsNotNull(the_modify_time_allocation_for_occurrence, "the_modify_time_allocation_for_occurrence");
            error_reporting_policy = Guard.IsNotNull(the_error_reporting_policy, "the_error_reporting_policy");

            response_builder = new ResponseBuilder<ShiftOccurrenceIdentity, EditShiftBreakResponse>();
        }

        private EditShiftBreakRequest request;
        private readonly GetOccurrence get_shift_occurrence;
        private readonly IUnitOfWork unit_of_work;
        private readonly ResponseBuilder<ShiftOccurrenceIdentity, EditShiftBreakResponse> response_builder;



        private TimeAllocationOccurrences.TimeAllocationOccurrence shift_occurrence;
        private TimeAllocationBreak the_break_to_be_edited;

        private FindOrCreateAndReturnTimeAllocationRequest find_or_create_request;
        private TimeAllocations.TimeAllocation time_allocation;

        private readonly FindOrCreateAndReturnTimeAllocation get_or_create_time_allocation;

        private readonly ModifyTimeAllocationForOccurrence modify_time_allocation_for_occurrence;
        private readonly GetAllRelatedOccurrencesFromOccurrenceIdentity get_all_related_occurrences;

        private readonly ShiftBreakErrorReportingPolicy error_reporting_policy;

    }
}
