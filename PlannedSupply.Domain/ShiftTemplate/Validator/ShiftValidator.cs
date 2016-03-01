using Content.Services.PlannedSupply.Messages;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Colour.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenOneMinuteAndTwentyFourHours;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators.IsWithInATwentyFourHourDay;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator
{
    public class ShiftValidator
    {
        public IEnumerable<ResponseMessage> validate_name
                                                (string name_to_validate
                                                , bool has_a_duplicate_shift_break_template_exist_with_this_name)
        {
            var validator = new Library.DomainTypes.Primitives.Validation.Validator();

            // to do: shift title should be renamed to shift_name
            validator
                .field("shift_title")
                .is_madatory(name_to_validate, ValidationMessages.error_00_0049)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(name_to_validate, ValidationMessages.error_00_0051)
                .premise_holds(!has_a_duplicate_shift_break_template_exist_with_this_name, ValidationMessages.error_00_0050)
                ;

            return validator.errors;
        }

        public TimeValidationResponse validate_start_time
                                           (TimeRequest start_time_validate)
        {
            var is_a_valid_time = new TimeIsWithinATwentyFourHourDay();
            return is_a_valid_time
                .execute(start_time_validate)
                .Match(

                    is_valid:
                        time_in_seconds_from_midnight =>
                            new TimeValidationResponse.Valid(time_in_seconds_from_midnight) as TimeValidationResponse,

                    is_not_valid:
                        errors =>
                        {
                            var field_errors = new HashSet<string>(); // displays the error messages for the filed
                            var component_errors = new HashSet<string>();
                            // holds the field components that we need to highlight as begin in error

                            var error_messages = new List<ResponseMessage>();

                            errors
                                .Do(error => error
                                    .Match(

                                        more_than_twenty_four_hours:
                                            time_exceeded_error =>
                                            {
                                                field_errors.Add(ValidationMessages.error_00_0055);
                                                component_errors.Add("hours");
                                                component_errors.Add("minutes");
                                            },
                                        hours_is_not_a_number:
                                            not_a_number_error =>
                                            {
                                                field_errors.Add(ValidationMessages.error_00_0054);
                                                component_errors.Add(not_a_number_error.field_name);
                                            },
                                        minutes_is_not_a_number:
                                            not_a_number_error =>
                                            {
                                                field_errors.Add(ValidationMessages.error_00_0054);
                                                component_errors.Add(not_a_number_error.field_name);
                                            },
                                        hours_is_not_specified:
                                            not_specified_error =>
                                            {
                                                field_errors.Add(ValidationMessages.error_00_0053);
                                                component_errors.Add(not_specified_error.field_name);
                                            },
                                        minutes_is_not_specified:
                                            not_specified_error =>
                                            {
                                                field_errors.Add(ValidationMessages.error_00_0053);
                                                component_errors.Add(not_specified_error.field_name);
                                            })
                                );

                            var response_messages = field_errors
                                .Select(
                                    error_message =>
                                        new ResponseMessage { field_name = "start_time", message = error_message })
                                .Union(
                                    component_errors.Select(
                                        component_name =>
                                            new ResponseMessage
                                            {
                                                field_name = "start_time." + component_name,
                                                message = "An Error"
                                            }))
                                ;

                            return new TimeValidationResponse.Errors(response_messages);
                        }
                );
        }

        public DurationValidationResponse validate_duration
                                           (DurationRequest duration_validate)
        {
            var is_a_valid_duration = new DurationIsBetweenOneMinuteAndTwentyFourHours();
            return is_a_valid_duration.execute(duration_validate)
                .Match(
                    is_valid:
                        duration_in_seconds =>
                            new DurationValidationResponse.valid(duration_in_seconds) as DurationValidationResponse,
                     is_not_valid:
                         errors =>
                         {
                             var field_errors = new HashSet<string>(); // displays the error messages for the filed
                             var component_errors = new HashSet<string>();
                             errors.Do(error =>
                                       error.Match(
                                       hours_not_specified:
                                           not_specified =>
                                           {
                                               field_errors.Add(ValidationMessages.error_00_0056);
                                               component_errors.Add(not_specified.field_name);
                                           },
                                           minutes_not_specified:
                                           not_specified =>
                                           {
                                               field_errors.Add(ValidationMessages.error_00_0056);
                                               component_errors.Add(not_specified.field_name);
                                           },
                                       hours_not_a_number:
                                           not_a_number =>
                                           {
                                               field_errors.Add(ValidationMessages.error_00_0057);
                                               component_errors.Add(not_a_number.field_name);
                                           },
                                           minutes_not_a_number:
                                           not_a_number =>
                                           {
                                               field_errors.Add(ValidationMessages.error_00_0057);
                                               component_errors.Add(not_a_number.field_name);
                                           },
                                      is_not_in_24_hour:
                                          duration_is_not_in_24_hour =>
                                          {
                                              field_errors.Add(ValidationMessages.error_00_0058);
                                              component_errors.Add("hours");
                                              component_errors.Add("minutes");
                                          }

                                           )
                                       );
                             var response_message = field_errors
                                 .Select(
                                     error_message =>
                                         new ResponseMessage() { field_name = "duration", message = error_message })
                                         .Union(
                                       component_errors.Select(
                                        component_name =>
                                            new ResponseMessage
                                            {
                                                field_name = "duration." + component_name,
                                                message = "An Error"
                                            }));

                             return new DurationValidationResponse.Errors(response_message);
                         }
                );
        }

        public RgbColourValidationResponse validate_rgb_colour(RGBColourRequest rgb_colour_validate)
        {
            var is_a_valid_colour = new RGBColourRequestValidation();
            var result = is_a_valid_colour.execute(rgb_colour_validate)
                 .Match(
                     is_valid:
                         colour_in_rgb_format =>
                             new RgbColourValidationResponse.valid(colour_in_rgb_format) as RgbColourValidationResponse,

                    is_not_valid:
                       errors =>
                       {
                           var response_messages = new List<ResponseMessage>();

                           errors.Do(error =>
                               error.Match(

                                   colour_is_not_in_the_correct_format:
                                    colour_error => response_messages.Add(new ResponseMessage()
                                    {
                                        field_name = colour_error.field_name,
                                        message = "error"
                                    })));


                           return new RgbColourValidationResponse.Error(response_messages);
                       }
                 );
            return result;
        }

        public bool are_the_associated_breaks_within_the_shift_boundary(int the_breaks_start_time_in_seconds, int the_breaks_end_time_in_seconds, int the_shifts_end_time_in_seconds)
        {
            bool is_breaks_start_time_greater_than_shifts_end_time = (the_breaks_start_time_in_seconds > the_shifts_end_time_in_seconds);
            bool is_breaks_end_time_greater_than_shifts_end_time = (the_breaks_end_time_in_seconds > the_shifts_end_time_in_seconds);

            if (is_breaks_start_time_greater_than_shifts_end_time)
            {
                return false; // No need check the other validation, exit the method now.
            }

            if (is_breaks_end_time_greater_than_shifts_end_time)
            {
                return false;
            }

            return true;    // No error, just return the empty error message list.
        }

    }
}