using System;
using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate
{
    public class ApplyShiftBreaksFromBreakTemplateForAllOccurrences : IApplyShiftBreaksFromBreakTemplateForAllOccurrences
    {
        public ApplyShiftBreaksFromBreakTemplateResponse execute(ApplyShiftBreaksFromBreakTemplateRequest the_request)
        {
            return
                set_request(the_request)
                    .get_the_shift_occurrence()
                    .get_the_breaks_from_break_template()
                    .validate_break_template_request()
                    .build_find_or_create_request()
                    .find_or_create_time_allocation()
                    .find_all_occurrences_of_same_type_and_change_their_time_allocation()
                    .commit()
                    .build_response();

        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences set_request(ApplyShiftBreaksFromBreakTemplateRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new ShiftOccurrenceIdentity()
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id
            });

            return this;
        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences get_the_shift_occurrence()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            shift_occurrence = get_shift_occurrence.execute(request);

            return this;
        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences get_the_breaks_from_break_template()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            //Get the breaks from the template
            var break_template = break_template_repository
                                                    .Entities
                                                    .SingleOrDefault(sbt => sbt.id == request.break_template_id);

            breaks_from_break_template = break_template == null
                                        ? null
                                        : break_template
                                            .all_breaks
                                            .Select(b => new FindOrCreateAndReturnTimeAllocationBreakRequest()
                                            {
                                                off_set = b.offset_from_start_time_in_seconds.to_duration_request(),
                                                duration = b.duration_in_seconds.to_duration_request(),
                                                is_paid = b.is_paid,
                                                originated_from_client = false
                                            });

            return this;
        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences validate_break_template_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (breaks_from_break_template == null)
            {
                //As far as requirements are concerned, this condition has not been captured
                //So we can't mark any fields, all we can do is make sure that we register *something*
                //on the response builder
                validator.field("error").premise_holds(false, "error");
            }

            if (validator.errors.Any())
            {
                response_builder.add_errors(validator.errors);
            }

            return this;
        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences build_find_or_create_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_occurrence, "shift_occurrence");
            Guard.IsNotNull(shift_occurrence.time_allocation, "shift_occurrence.time_allocation");

            //build the combined breaks from template with the shift details
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
                breaks = breaks_from_break_template
            };

            return this;
        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences find_or_create_time_allocation()
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
                           find_or_create_error_types.client_break,
                           find_or_create_error_types.internal_shift,
                           find_or_create_error_types.client_shift
                       }, delegate
                       {
                           throw new InternalCorruptDataException("Internal data corruption");
                       });
                   });

            return this;
        }

        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences find_all_occurrences_of_same_type_and_change_their_time_allocation()
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


        private ApplyShiftBreaksFromBreakTemplateForAllOccurrences commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            response_builder.add_message(ConfirmationMessages.confirmation_04_0039);
            return this;
        }


        private ApplyShiftBreaksFromBreakTemplateResponse build_response()
        {
            if (response_builder.has_errors)
                response_builder.add_error(WarningMessages.warning_03_0031);

            return response_builder.build();
        }

        public ApplyShiftBreaksFromBreakTemplateForAllOccurrences(IUnitOfWork the_unit_of_work,
                                                                    GetOccurrence the_get_shift_occurrence,
                                                                    GetAllRelatedOccurrencesFromOccurrenceIdentity the_get_all_related_occurrences,
                                                                    IEntityRepository<BreakTemplate> the_break_template_repository,
                                                                    FindOrCreateAndReturnTimeAllocation the_get_or_create_time_allocation,
                                                                    ShiftBreakErrorReportingPolicy the_error_reporting_policy,
                                                                    ModifyTimeAllocationForOccurrence the_modify_time_allocation_for_occurrence,
            Validator the_validator)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
            get_or_create_time_allocation = Guard.IsNotNull(the_get_or_create_time_allocation, "get_or_create_time_allocation");

            get_all_related_occurrences = Guard.IsNotNull(the_get_all_related_occurrences, "the_get_all_related_occurrences");
            modify_time_allocation_for_occurrence = Guard.IsNotNull(the_modify_time_allocation_for_occurrence, "the_modify_time_allocation_for_occurrence");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            response_builder = new ResponseBuilder<ShiftOccurrenceIdentity, ApplyShiftBreaksFromBreakTemplateResponse>();

            error_reporting_policy = Guard.IsNotNull(the_error_reporting_policy, "the_error_reporting_policy");
        }

        private ApplyShiftBreaksFromBreakTemplateRequest request;
        private readonly IUnitOfWork unit_of_work;
        private readonly ResponseBuilder<ShiftOccurrenceIdentity, ApplyShiftBreaksFromBreakTemplateResponse> response_builder;


        private FindOrCreateAndReturnTimeAllocationRequest find_or_create_request;
        private TimeAllocations.TimeAllocation time_allocation;


        private TimeAllocationOccurrences.TimeAllocationOccurrence shift_occurrence;
        private readonly GetOccurrence get_shift_occurrence;

        private readonly FindOrCreateAndReturnTimeAllocation get_or_create_time_allocation;
        private readonly GetAllRelatedOccurrencesFromOccurrenceIdentity get_all_related_occurrences;
        private readonly ModifyTimeAllocationForOccurrence modify_time_allocation_for_occurrence;

        private readonly IEntityRepository<BreakTemplate> break_template_repository;

        private IEnumerable<FindOrCreateAndReturnTimeAllocationBreakRequest> breaks_from_break_template;


        private readonly Validator validator;

        private readonly ShiftBreakErrorReportingPolicy error_reporting_policy;

    }
}
