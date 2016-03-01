using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate
{
    public class NewShiftOccurrenceFromShiftTemplate : INewShiftOccurrenceFromShiftTemplate
    {
        public NewShiftOccurrenceFromShiftTemplateResponse execute(NewShiftOccurrenceFromShiftTemplateRequest the_request)
        {
            return
                set_request(the_request)
                .find_shift_template_from_request()
                .validate_shift_template_request()
                .build_find_or_create_request()
                .find_or_create_time_allocation()
                .get_the_shift_calendar_pattern()
                .create_time_allocation_occurrence()
                .commit()
                .build_response();
        }

        private NewShiftOccurrenceFromShiftTemplate set_request(NewShiftOccurrenceFromShiftTemplateRequest the_request)
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

        private NewShiftOccurrenceFromShiftTemplate find_shift_template_from_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_template_repository, "shift_template_repository");

            shift_template = shift_template_repository.Entities.SingleOrDefault(s => s.id == request.shift_template_id);

            return this;
        }

        private NewShiftOccurrenceFromShiftTemplate validate_shift_template_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (shift_template == null && request.shift_template_id > 0)
            {
                validator.field("shift_template_id").premise_holds(false, "");
            }
            else if (shift_template == null)
            {
                validator.field("shift_template_id").premise_holds(false, "");
            }

            if (validator.errors.Any())
            {
                response_builder.add_errors(validator.errors);
            }

            return this;
        }

        private NewShiftOccurrenceFromShiftTemplate build_find_or_create_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_template, "shift_template");

            find_or_create_request = new FindOrCreateAndReturnTimeAllocationRequest()
            {
                shift = new FindOrCreateAndReturnTimeAllocationShiftRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    colour = shift_template.colour.to_rgb_colour_request_from_persistence_format(),
                    shift_title = shift_template.shift_title,
                    start_time = shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                    duration = shift_template.duration_in_seconds.to_duration_request(),
                    originated_from_client = false
                },
                breaks = shift_template.break_template == null ? Enumerable.Empty<FindOrCreateAndReturnTimeAllocationBreakRequest>() : shift_template.break_template.all_breaks.Select(b => new FindOrCreateAndReturnTimeAllocationBreakRequest()
                {
                    off_set = b.offset_from_start_time_in_seconds.to_duration_request(),
                    duration = b.duration_in_seconds.to_duration_request(),
                    is_paid = b.is_paid,
                    originated_from_client = false
                })
            };
            return this;
        }

        private NewShiftOccurrenceFromShiftTemplate find_or_create_time_allocation()
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
                   had_errors: error_response => error_response.Any(new HashSet<find_or_create_error_types>()
                   {
                       find_or_create_error_types.client_break,
                       find_or_create_error_types.internal_break,
                       find_or_create_error_types.internal_shift,
                       find_or_create_error_types.client_shift
                   }, delegate
                   {
                       throw new InternalCorruptDataException("Internal data corruption");
                   }));

            return this;
        }

        private NewShiftOccurrenceFromShiftTemplate get_the_shift_calendar_pattern()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            shift_calendar_pattern = get_shift_calendar_pattern.execute(request);

            return this;
        }

        private NewShiftOccurrenceFromShiftTemplate create_time_allocation_occurrence()
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

        private NewShiftOccurrenceFromShiftTemplate commit()
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

        private NewShiftOccurrenceFromShiftTemplateResponse build_response()
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

        public NewShiftOccurrenceFromShiftTemplate( IEntityRepository<ShiftTemplates.ShiftTemplate> the_shift_template_repository,
                                                    IUnitOfWork the_unit_of_work,
                                                    FindOrCreateAndReturnTimeAllocation the_get_or_create_time_allocation,
                                                    GetShiftCalendarPattern the_get_shift_calendar_pattern,
                                                    Validator the_validator,
                                                    ShiftErrorReportingPolicy the_error_reporting_policy,
                                                    CreateTimeAllocationOccurrenceValidation the_create_time_allocation_for_occurrence)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            shift_template_repository = Guard.IsNotNull(the_shift_template_repository, "the_shift_template_repository");
            get_or_create_time_allocation = Guard.IsNotNull(the_get_or_create_time_allocation, "get_or_create_time_allocation");
            get_shift_calendar_pattern = Guard.IsNotNull(the_get_shift_calendar_pattern, "the_get_shift_calendar_pattern");

            error_reporting_policy = Guard.IsNotNull(the_error_reporting_policy, "the_error_reporting_policy");
            create_time_allocation_for_occurrence = Guard.IsNotNull(the_create_time_allocation_for_occurrence, "the_create_time_allocation_for_occurrence");
            response_builder = new ResponseBuilder<ShiftOccurrenceIdentity, NewShiftOccurrenceFromShiftTemplateResponse>();
        }

        private readonly Validator validator;
        private readonly IUnitOfWork unit_of_work;
        private ShiftTemplates.ShiftTemplate shift_template;
        private NewShiftOccurrenceFromShiftTemplateRequest request;
        private readonly IEntityRepository<ShiftTemplates.ShiftTemplate> shift_template_repository;
        
        private readonly ResponseBuilder<ShiftOccurrenceIdentity, NewShiftOccurrenceFromShiftTemplateResponse> response_builder;

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
