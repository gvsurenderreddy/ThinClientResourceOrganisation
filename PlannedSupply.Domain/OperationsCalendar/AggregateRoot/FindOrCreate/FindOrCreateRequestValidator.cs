using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Creational;
using WTS.WorkSuite.Library.DomainTypes.Colour.Sanatisation;
using WTS.WorkSuite.Library.DomainTypes.Colour.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenOneMinuteAndTwentyFourHours;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsSpeciftyAndIsANumber;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.BatchOfViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators.IsWithInATwentyFourHourDay;
using WTS.WorkSuite.PlannedSupply.Defaults;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate
{
    public class FindOrCreateRequestValidator
    {
        public FindOrCreateRequestValidatorResponse execute(FindOrCreateAndReturnTimeAllocationRequest the_request)
        {
            return
                 set_request(the_request)
                .validate_shift_title()
                .validate_shift_colour()
                .validate_shift_start_time()
                .validate_shift_duration()
                .validate_fields_for_each_break()
                .validate_each_break_is_longer_than_zero()
                .break_validation_between_peers()
                .validate_shift_with_breaks()
                .build_response();
        }

        private FindOrCreateRequestValidator set_request(FindOrCreateAndReturnTimeAllocationRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            sanitised_request.originated_from_client = request.shift.originated_from_client;
            return this;
        }

        private FindOrCreateRequestValidator validate_shift_title()
        {
            Guard.IsNotNull(request, "request");

            sanitised_request.title = request.shift.shift_title.normalise_for_persistence();

            validator
                .field(FindOrCreateTimeAllocationValidationErrors.TITLE_IS_NOT_SPECIFIED)
                .is_madatory(sanitised_request.title, FindOrCreateTimeAllocationValidationErrors.TITLE_IS_NOT_SPECIFIED);

            validator
                .field(FindOrCreateTimeAllocationValidationErrors.TITLE_EXCEEDS_MAX_CHARACTERS)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(sanitised_request.title, FindOrCreateTimeAllocationValidationErrors.TITLE_EXCEEDS_MAX_CHARACTERS);

            if (validator.errors.Any())
            {
                add_to_hash_set(request.shift);
                response_builder.add_errors(validator.errors);

            }

            return this;
        }

        private FindOrCreateRequestValidator validate_shift_colour()
        {
            Guard.IsNotNull(request, "request");

            rgb_colour_validator
                .execute(request.shift.colour.default_if_not_specifed(DefaultShiftColour.create()))
                 .Match(
                     is_valid:
                         colour_in_rgb_format =>
                             sanitised_request.colour = colour_in_rgb_format,

                    is_not_valid:
                       errors =>
                       {
                           response_builder.add_errors(FindOrCreateTimeAllocationValidationErrors.COLOUR_IS_NOT_VALID
                                                        .ToResponseMessage(FindOrCreateTimeAllocationValidationErrors.COLOUR_IS_NOT_VALID)
                                                        .ToEnumerable());
                           add_to_hash_set(request.shift);
                       }
                 );

            return this;
        }

        private FindOrCreateRequestValidator validate_shift_start_time()
        {
            Guard.IsNotNull(request, "request");

            time_is_within_a_24_hour_day_factory
                .create()
                .execute(request.shift.start_time.normalise_for_persistence())
                .Match(

                    is_valid:
                        time_in_seconds_from_midnight => sanitised_request.start_time_in_seconds_from_midnight = time_in_seconds_from_midnight,

                    is_not_valid:
                        errors =>
                        {
                            var errors_found = new HashSet<string>();

                            errors
                                .Do(error => error
                                    .Match(

                                        more_than_twenty_four_hours:
                                            time_exceeded_error => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.START_TIME_EXCEEDS_24_HOURS),
                                        hours_is_not_a_number:
                                            hours_is_not_a_number_error => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.START_TIME_HOURS_IS_NOT_A_NUMBER),
                                        minutes_is_not_a_number:
                                            minutes_is_not_a_number_error => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.START_TIME_MINUTES_IS_NOT_A_NUMBER),
                                        hours_is_not_specified:
                                            hours_not_specified_error => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.START_TIME_HOURS_IS_NOT_SPECIFIED),
                                        minutes_is_not_specified:
                                            minutes_is_not_specified_error => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.START_TIME_MINUTES_IS_NOT_SPECIFIED))
                                );

                            var response_messages = errors_found.Select(error_message => error_message.ToResponseMessage(error_message));

                            response_builder.add_errors(response_messages);

                            add_to_hash_set(request.shift);
                        }
                );

            return this;
        }

        private FindOrCreateRequestValidator validate_shift_duration()
        {
            Guard.IsNotNull(request, "request");


            duration_is_between_1_minute_and_24_hour_factory
                .create()
                .execute(request.shift.duration.normalise_for_persistence())
                .Match(
                    is_valid:
                        duration_in_seconds =>
                            sanitised_request.duration_in_seconds = duration_in_seconds,
                     is_not_valid:
                         errors =>
                         {
                             var errors_found = new HashSet<string>();
                             errors.Do(error =>
                                       error.Match(
                                       hours_not_specified:
                                           not_specified => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.DURATION_HOURS_IS_NOT_SPECIFIED),
                                        minutes_not_specified:
                                           not_specified => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.DURATION_MINUTES_IS_NOT_SPECIFIED),
                                       hours_not_a_number:
                                           not_a_number => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.DURATION_HOURS_IS_NOT_A_NUMBER),
                                        minutes_not_a_number:
                                           not_a_number => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.DURATION_MINUTES_IS_NOT_A_NUMBER),
                                      is_not_in_24_hour:
                                          duration_is_not_in_24_hour => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.DURATION_IS_NOT_WITHIN_24_HOURS)
                                          )
                                    );

                             var response_messages = errors_found.Select(error_message => error_message.ToResponseMessage(error_message));

                             response_builder.add_errors(response_messages);

                             add_to_hash_set(request.shift);
                         }
                );

            return this;
        }

        private FindOrCreateRequestValidator validate_fields_for_each_break()
        {
            Guard.IsNotNull(request, "request");

            sanitised_request.sanitised_breaks = request.breaks.Select(b =>
            {
                var the_duration_in_seconds = 0;

                duration_is_specified_and_is_a_number_factory.create().execute(b.duration)
                .Match(

                    is_valid:
                        duration_in_seconds => the_duration_in_seconds = duration_in_seconds,
                    is_not_valid:
                        errors =>
                        {

                            var errors_found = new HashSet<string>();
                            errors.Do(error =>
                                      error.Match(
                                      hours_not_specified:
                                          not_specified => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_HOURS_IS_NOT_SPECIFIED),
                                       minutes_not_specified:
                                          not_specified => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_MINUTES_IS_NOT_SPECIFIED),
                                      hours_not_a_number:
                                          not_a_number => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_HOURS_IS_NOT_A_NUMBER),
                                       minutes_not_a_number:
                                          not_a_number => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_MINUTES_IS_NOT_A_NUMBER),
                                     is_not_in_24_hour:
                                         duration_is_not_in_24_hour => { throw new Exception("Unexpected case."); }
                                          )
                                   );

                            var response_messages = errors_found.Select(error_message => error_message.ToResponseMessage(error_message));
                            response_builder.add_errors(response_messages);

                            add_to_hash_set(b);
                        });


                var the_offset_in_seconds = 0;
                duration_is_specified_and_is_a_number_factory.create().execute(b.off_set)
                    .Match(
                        is_valid:
                            request_duration_in_second => the_offset_in_seconds = request_duration_in_second,
                        is_not_valid:
                            errors =>
                            {
                                var errors_found = new HashSet<string>();
                                errors.Do(error =>
                                          error.Match(
                                          hours_not_specified:
                                              not_specified => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_HOURS_IS_NOT_SPECIFIED),
                                           minutes_not_specified:
                                              not_specified => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_MINUTES_IS_NOT_SPECIFIED),
                                          hours_not_a_number:
                                              not_a_number => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_HOURS_IS_NOT_A_NUMBER),
                                           minutes_not_a_number:
                                              not_a_number => errors_found.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_MINUTES_IS_NOT_A_NUMBER),
                                         is_not_in_24_hour:
                                             duration_is_not_in_24_hour => { throw new Exception("Unexpected case."); }
                                              )
                                       );

                                var response_messages = errors_found.Select(error_message => error_message.ToResponseMessage(error_message));
                                response_builder.add_errors(response_messages);

                                add_to_hash_set(b);
                            });

                return new SanitisedTimeAllocationBreak
                {

                    duration_in_seconds = the_duration_in_seconds,
                    offset_from_start_time_in_seconds = the_offset_in_seconds,
                    is_paid = b.is_paid,
                    originated_from_client = b.originated_from_client
                };

            }).ToList();

            return this;
        }

        private FindOrCreateRequestValidator validate_each_break_is_longer_than_zero()
        {
            var errors = new HashSet<string>();

            sanitised_request.sanitised_breaks.Do(br =>
            {
                if (br.duration_in_seconds <= 0)
                {
                    errors.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_MODEL_DURATION_IS_ZERO);

                    add_to_hash_set(br);
                }
            });

            errors.Do(ef => response_builder.add_error(ef.ToResponseMessage(ef)));

            return this;
        }

        //TODO: (D.O) Internal server error on clashing breaks
        //We can't currently do this because the clashing break checker is being done in a black box
        private FindOrCreateRequestValidator break_validation_between_peers()
        {
            //D.O: We agreed at some point to allow validations to run as long as the data to be validated is available.
            //in that light, i believe the check below for errors and returning should be removed.
            //None of the other methods in this class do this, so we need to be sure we're doing the right thing.
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(sanitised_request.sanitised_breaks, "sanitised_request.sanitised_breaks");

            var errors = new HashSet<string>();

            check_breaks_between_peers.validate(sanitised_request.sanitised_breaks.Select(to_time_period))
            .Do(r =>
            {
                if (r is ViolationCheckResult.BlockClashError)
                {
                    errors.Add(FindOrCreateTimeAllocationValidationErrors.BREAK_MODEL_CLASHES_WITH_ANOTHER);
                }
            });

            errors.Do(ef => response_builder.add_error(ef.ToResponseMessage(ef)));
            return this;
        }

        
        //TODO: (D.O) Internal server error on clashing shift and break.
        private FindOrCreateRequestValidator validate_shift_with_breaks()
        {
            Guard.IsNotNull(sanitised_request, "sanitised_request");
            Guard.IsNotNull(sanitised_request.sanitised_breaks, "sanitised_request.sanitised_breaks");
            if (sanitised_request.duration_in_seconds < 1) return this;
            if (!sanitised_request.sanitised_breaks.Any()) return this;

            var errors_to_check_for = new List<string>()
            {
                FindOrCreateTimeAllocationValidationErrors.DURATION_IS_NOT_WITHIN_24_HOURS,
                FindOrCreateTimeAllocationValidationErrors.DURATION_HOURS_IS_NOT_SPECIFIED,
                FindOrCreateTimeAllocationValidationErrors.DURATION_MINUTES_IS_NOT_SPECIFIED,
                FindOrCreateTimeAllocationValidationErrors.DURATION_HOURS_IS_NOT_A_NUMBER,
                FindOrCreateTimeAllocationValidationErrors.DURATION_MINUTES_IS_NOT_A_NUMBER,
                FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_HOURS_IS_NOT_SPECIFIED,
                FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_MINUTES_IS_NOT_SPECIFIED,
                FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_HOURS_IS_NOT_A_NUMBER,
                FindOrCreateTimeAllocationValidationErrors.BREAK_OFFSET_MINUTES_IS_NOT_A_NUMBER,
                FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_HOURS_IS_NOT_SPECIFIED,
                FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_MINUTES_IS_NOT_SPECIFIED,
                FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_HOURS_IS_NOT_A_NUMBER,
                FindOrCreateTimeAllocationValidationErrors.BREAK_DURATION_MINUTES_IS_NOT_A_NUMBER,
                FindOrCreateTimeAllocationValidationErrors.BREAK_MODEL_CLASHES_WITH_ANOTHER,
                FindOrCreateTimeAllocationValidationErrors.BREAK_MODEL_DURATION_IS_ZERO
            };

            if (response_builder.has_any(rm => errors_to_check_for.Any(ue => ue == rm.field_name))) return this;

            var last_break = sanitised_request.sanitised_breaks.OrderBy(ta => ta.offset_from_start_time_in_seconds + ta.duration_in_seconds).Last();

            if (last_break.offset_from_start_time_in_seconds + last_break.duration_in_seconds
                > sanitised_request.duration_in_seconds)
            {
                response_builder.add_error(FindOrCreateTimeAllocationValidationErrors.SHIFT_CLASHES_WITH_A_BREAK.ToResponseMessage(FindOrCreateTimeAllocationValidationErrors.SHIFT_CLASHES_WITH_A_BREAK));
            }

            return this;
        }

        private FindOrCreateRequestValidatorResponse build_response()
        {
            var response = response_builder.build();
            response.result = sanitised_request;
            response.error_types_found = error_types_found;
            return response;
        }

        private TimePeriod to_time_period(SanitisedTimeAllocationBreak break_details)
        {
            var date_time = new DateTime();
            var offset_to_date_time = date_time.AddSeconds( break_details.offset_from_start_time_in_seconds + request.shift.start_time.to_Seconds());
            return new TimePeriod(new UtcTime(offset_to_date_time.Year
                , offset_to_date_time.Month
                , offset_to_date_time.Day
                , offset_to_date_time.Hour
                , offset_to_date_time.Minute
                , offset_to_date_time.Second
                , offset_to_date_time.Millisecond),
                break_details.duration_in_seconds);
        }

        public FindOrCreateRequestValidator(Validator the_validator
                                            , RGBColourRequestValidation the_rgb_colour_validator
                                            , IFactory<DurationIsSpecifyAndIsANumber> the_duration_is_specified_and_not_a_number_factory
                                            , IFactory<DurationIsBetweenOneMinuteAndTwentyFourHours> the_duration_is_between_1_minute_and_24_hour_factory
                                            , IFactory<TimeIsWithinATwentyFourHourDay> the_time_is_within_a_24_hour_day_factory
                                            , CheckBatchOfViolation the_check_bach_of_violation)
        {
            validator = Guard.IsNotNull(the_validator, "the_validator");
            response_builder = new ResponseBuilder<FindOrCreateRequestValidatorResponse>();
            sanitised_request = new SanitisedTimeAllocation();

            rgb_colour_validator = Guard.IsNotNull(the_rgb_colour_validator, "the_rgb_colour_validator");
            duration_is_specified_and_is_a_number_factory = Guard.IsNotNull(the_duration_is_specified_and_not_a_number_factory, "the_duration_is_specified_and_not_a_number_factory");
            duration_is_between_1_minute_and_24_hour_factory = Guard.IsNotNull(the_duration_is_between_1_minute_and_24_hour_factory, "the_duration_is_between_1_minute_and_24_hour_factory");
            time_is_within_a_24_hour_day_factory = Guard.IsNotNull(the_time_is_within_a_24_hour_day_factory, "the_time_is_within_a_24_hour_day_factory");

            check_breaks_between_peers = Guard.IsNotNull(the_check_bach_of_violation, "the_check_bach_of_violation");

        }

        private readonly RGBColourRequestValidation rgb_colour_validator;
        private readonly CheckBatchOfViolation check_breaks_between_peers;
        private FindOrCreateAndReturnTimeAllocationRequest request;
        private readonly Validator validator;
        private readonly SanitisedTimeAllocation sanitised_request;
        private readonly ResponseBuilder<FindOrCreateRequestValidatorResponse> response_builder;
        private readonly HashSet<find_or_create_error_types> error_types_found = new HashSet<find_or_create_error_types>();

        private readonly IFactory<DurationIsSpecifyAndIsANumber> duration_is_specified_and_is_a_number_factory;
        private readonly IFactory<DurationIsBetweenOneMinuteAndTwentyFourHours> duration_is_between_1_minute_and_24_hour_factory;
        private readonly IFactory<TimeIsWithinATwentyFourHourDay> time_is_within_a_24_hour_day_factory;

        private void add_to_hash_set(FindOrCreateAndReturnTimeAllocationShiftRequest the_shift)
        {
            error_types_found.Add(the_shift.originated_from_client
                ? find_or_create_error_types.client_shift
                : find_or_create_error_types.internal_shift);
        }

        private void add_to_hash_set(FindOrCreateAndReturnTimeAllocationBreakRequest the_break)
        {
            error_types_found.Add(the_break.originated_from_client
                ? find_or_create_error_types.client_break
                : find_or_create_error_types.internal_break);
        }

        private void add_to_hash_set(SanitisedTimeAllocationBreak the_break)
        {
            error_types_found.Add(the_break.originated_from_client
                ? find_or_create_error_types.client_break
                : find_or_create_error_types.internal_break);
        }
    }

    public class FindOrCreateRequestValidatorResponse : Response<SanitisedTimeAllocation>
    {
        public HashSet<find_or_create_error_types> error_types_found { get; set; }
    }
}


