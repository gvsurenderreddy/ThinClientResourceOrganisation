using Content.Services.PlannedSupply.Messages;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenOneMinuteAndTwentyFourHours;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenZeroMinuteAndTwentyFourHours;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ClashingTimePeriodScenario;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.OneViolation;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Validator
{
    public class BreakValidator
    {
        public DurationValidationResponse validate_off_set(DurationRequest the_off_set_to_be_validated)
        {
            var is_a_valid_duration = new DurationIsBetweenZeroMinuteAndTwentyFourHours();
            return is_a_valid_duration.execute(the_off_set_to_be_validated)
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
                                            field_errors.Add(ValidationMessages.error_00_0064);
                                            component_errors.Add(not_specified.field_name);
                                        },
                                    minutes_not_specified:
                                        not_specified =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0064);
                                            component_errors.Add(not_specified.field_name);
                                        },
                                    hours_not_a_number:
                                        not_a_number =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0065);
                                            component_errors.Add(not_a_number.field_name);
                                        },
                                    minutes_not_a_number:
                                        not_a_number =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0065);
                                            component_errors.Add(not_a_number.field_name);
                                        },

                                    is_not_in_24_hour:
                                        duration_is_not_in_24_hour =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0066);
                                            component_errors.Add("hours");
                                            component_errors.Add("minutes");
                                        }

                                    )
                                );
                            var response_message = field_errors
                                .Select(
                                    error_message =>
                                        new ResponseMessage {field_name = "off_set", message = error_message})
                                .Union(
                                    component_errors.Select(
                                        component_name =>
                                            new ResponseMessage
                                            {
                                                field_name = "off_set." + component_name,
                                                message = "An Error"
                                            }));

                            return new DurationValidationResponse.Errors(response_message);
                        }
                );
        }

        public DurationValidationResponse validate_duration(DurationRequest the_duration_to_be_validated)
        {
            var is_a_valid_duration = new DurationIsBetweenOneMinuteAndTwentyFourHours();
            return is_a_valid_duration.execute(the_duration_to_be_validated)
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
                                            field_errors.Add(ValidationMessages.error_00_0069);
                                            component_errors.Add(not_specified.field_name);
                                        },
                                    minutes_not_specified:
                                        not_specified =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0069);
                                            component_errors.Add(not_specified.field_name);
                                        },
                                    hours_not_a_number:
                                        not_a_number =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0070);
                                            component_errors.Add(not_a_number.field_name);
                                        },
                                    minutes_not_a_number:
                                        not_a_number =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0070);
                                            component_errors.Add(not_a_number.field_name);
                                        },
                                    is_not_in_24_hour:
                                        duration_is_not_in_24_hour =>
                                        {
                                            field_errors.Add(ValidationMessages.error_00_0071);
                                            component_errors.Add("hours");
                                            component_errors.Add("minutes");
                                        }

                                    )
                                );
                            var response_message = field_errors
                                .Select(
                                    error_message =>
                                        new ResponseMessage {field_name = "duration", message = error_message})
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

        public List<ViolationCheckResponse> clashing_break_validation_for_single_overlapped ( IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period )
        {

            ViolationCheckResponse violation_check_response;
            var violation_check_response_list = new List<ViolationCheckResponse>();
            var single_overlap_result = list_of_time_period.clashing_time_period_for_single_overlap(new_time_period);

            if (single_overlap_result.single_envelop_error)
            {
                return violation_check_response_list;
            }

            if (single_overlap_result.single_overlapped_start_time_error)
            {
                var field_errors_start_after = new HashSet<string> { ValidationMessages.error_00_0085 };
                violation_check_response =new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);
            }

            if (single_overlap_result.single_overlapped_duration_error)
            {
                var field_errors_duration = new HashSet<string> { ValidationMessages.error_00_0086 };
                violation_check_response =
                    new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
            }

            return violation_check_response_list;
        }

        public List<ViolationCheckResponse> clashing_break_validation_for_enveloped ( IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period )
        {
            var violation_check_response_list = new List<ViolationCheckResponse>();
            var single_enveloped_result = list_of_time_period.clashing_time_period_for_single_enveloped(new_time_period);

            if (single_enveloped_result.single_enveloped_start_time_and_end_time_error)
           {
               var field_errors_start_after = new HashSet<string> { ValidationMessages.error_00_0089 };
               ViolationCheckResponse violation_check_response = new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
               violation_check_response_list.Add(violation_check_response);

               var field_errors_duration = new HashSet<string> { ValidationMessages.error_00_0090 };
               violation_check_response = new ViolationCheckResponse.Errors(field_errors_duration.duration());
               violation_check_response_list.Add(violation_check_response);
            }
            return violation_check_response_list;
        }

        public List<ViolationCheckResponse> clashing_break_validation_for_envelops ( IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period )
        {

            ViolationCheckResponse violation_check_response;
            var violation_check_response_list = new List<ViolationCheckResponse>();
            var single_envelop_result = list_of_time_period.clashing_time_period_for_single_envelop(new_time_period);

            if (single_envelop_result.single_envelop_start_time_and_end_time_error)
            {
                var field_errors_start_after = new HashSet<string> {ValidationMessages.error_00_0089};
                violation_check_response =new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);

                var field_errors_duration = new HashSet<string> {ValidationMessages.error_00_0090};
                violation_check_response =new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
            }

            if (single_envelop_result.single_envelop_duration_error)
            {
                var field_errors_duration = new HashSet<string> {ValidationMessages.error_00_0090};
                violation_check_response =new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
            }

            if (single_envelop_result.single_envelop_start_time_error)
            {
                var field_errors_start_after = new HashSet<string> {ValidationMessages.error_00_0089};
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);
            }

            return violation_check_response_list;
        }

        public List<ViolationCheckResponse> clashing_break_validation_for_multiple_envelop ( IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period )
        {

            ViolationCheckResponse violation_check_response;
            var violation_check_response_list = new List<ViolationCheckResponse>();
            var multiple_envelop = list_of_time_period.clashing_break_validation_for_multiple_envelop(new_time_period);
            if (multiple_envelop.multiple_envelop_end_time_error)
             {
                var field_errors_duration = new HashSet<string> {ValidationMessages.error_00_0093};
                violation_check_response =new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
             }
            if (multiple_envelop.multiple_envelop_start_time_error)
            {
                var field_errors_start_after = new HashSet<string>{ValidationMessages.error_00_0092};
                violation_check_response =new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);
            }

            if (multiple_envelop.multiple_envelop_when_start_and_end_time_is_the_same)
           {
               var field_errors_duration = new HashSet<string> {ValidationMessages.error_00_0093};
               violation_check_response =new ViolationCheckResponse.Errors(field_errors_duration.duration());
               violation_check_response_list.Add(violation_check_response);

               var field_errors_start_after = new HashSet<string> {ValidationMessages.error_00_0092};
               violation_check_response =new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
               violation_check_response_list.Add(violation_check_response);
           }

           if (multiple_envelop.multiple_envelop_start_is_overlapped_end_time_is_greater)
           {
               var field_errors_start_after = new HashSet<string> {ValidationMessages.error_00_0092};
               violation_check_response =new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
               violation_check_response_list.Add(violation_check_response);
           }

           if (multiple_envelop.multiple_envelop_start_is_less_than_old_start_and_end_time_is_overlapped)
           {
               var field_errors_duration = new HashSet<string> { ValidationMessages.error_00_0093 };
               violation_check_response = new ViolationCheckResponse.Errors(field_errors_duration.duration());
               violation_check_response_list.Add(violation_check_response);
           }
            return violation_check_response_list;
        }

        public List<ViolationCheckResponse> clashing_break_validation_for_multiple_overlap_and_envelop(IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period)
        {
            ViolationCheckResponse violation_check_response;
            var violation_check_response_list = new List<ViolationCheckResponse>();
            var multiple_envelop = list_of_time_period.clashing_break_validation_for_multiple_overlap_and_envelop(new_time_period);
          
            if (multiple_envelop.multiple_envelop_same_start_time_and_overlapped_end_time)
            {
                var field_errors_start_after = new HashSet<string> { ValidationMessages.error_00_0092 };
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);

                var field_errors_duration = new HashSet<string> { ValidationMessages.error_00_0086 };
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
            }

            if (multiple_envelop.multiple_envelop_start_time_is_overlapped_and_end_time_is_the_same)
            {
                var field_errors_start_after = new HashSet<string> { ValidationMessages.error_00_0086 };
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);

                var field_errors_duration = new HashSet<string> { ValidationMessages.error_00_0092 };
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
            }

            if (multiple_envelop.multiple_envelop_start_and_end_time_overlapped)
            {
                var field_errors_start_after = new HashSet<string> { ValidationMessages.error_00_0086 };
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_start_after.start_time());
                violation_check_response_list.Add(violation_check_response);

                var field_errors_duration = new HashSet<string> { ValidationMessages.error_00_0086 };
                violation_check_response = new ViolationCheckResponse.Errors(field_errors_duration.duration());
                violation_check_response_list.Add(violation_check_response);
            }
            return violation_check_response_list;
        }
    }
}

public static class CreateFieldError
{
    public static IEnumerable<ResponseMessage> start_time(this HashSet<string> field_errors_start_after)
    {
        var component_errors = new HashSet<string>();
        IEnumerable<ResponseMessage> response_message_for_strt = field_errors_start_after
                                .Select(error_message => new ResponseMessage { field_name = "off_set", message = error_message })
                                .Union(component_errors.Select(component_name => new ResponseMessage { field_name = "off_set." + component_name, message = "An Error" }));
        component_errors.Add("hours");
        component_errors.Add("minutes");

        return response_message_for_strt;
    }

    public static IEnumerable<ResponseMessage> duration(this HashSet<string> field_errors_duration)
    {
        var component_errors = new HashSet<string>();
        IEnumerable<ResponseMessage> response_message_for_duration = field_errors_duration
                                .Select(error_message => new ResponseMessage { field_name = "duration", message = error_message })
                                .Union(component_errors.Select(component_name => new ResponseMessage { field_name = "duration." + component_name, message = "An Error" }));
        component_errors.Add("hours");
        component_errors.Add("minutes");

        return response_message_for_duration;
    }
}

