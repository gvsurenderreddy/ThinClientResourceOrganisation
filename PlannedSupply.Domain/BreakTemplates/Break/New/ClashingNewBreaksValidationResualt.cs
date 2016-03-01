using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.OneViolation;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Validator;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New
{
    public class ClashingNewBreaksValidationResualt
    {
        public Response execute(NewBreakRequest the_new_break_request)
        {
            return set_request(the_new_break_request)
                   .convert_breaks_to_time_period()
                   .single_overlapping()
                   .single_enveloped()
                   .single_envelops()
                   .multipl_envelop()
                   .multipl_overlap_and_envelop()
                   .build_response();
        }

        private ClashingNewBreaksValidationResualt set_request(NewBreakRequest the_new_break_request)
        {
            new_break_request = Guard.IsNotNull(the_new_break_request, "the_new_break_request");
            return this;
        }

        private ClashingNewBreaksValidationResualt convert_breaks_to_time_period()
        {
            if (the_response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");

            var get_all_breaks = the_break_template_repository.Entities.Where(x => x.id == new_break_request.template_id).SelectMany(x => x.all_breaks);
            list_of_time_period = get_all_breaks.Select(ConvertBreaksToTimePeriod.to_time_period).ToList();
            list_of_time_period.Add(new_break_request.from_new_request_to_time_period());

            return this;
        }

        private ClashingNewBreaksValidationResualt single_overlapping()
        {
            if (the_response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(list_of_time_period, "list_of_time_period");

            var overlapping_validation = the_validator.clashing_break_validation_for_single_overlapped(list_of_time_period, new_break_request.from_new_request_to_time_period());

            if (overlapping_validation.Count > 1)
            {
                for (int i = 0; i < overlapping_validation.Count; i++)
                {
                    overlapping_validation.ElementAtOrDefault(i).Match(

                        is_valid:
                                 valid => { },
                        is_not_valid:
                                messages => the_response_builder.add_errors(messages)

                        );
                }

                the_response_builder.add_errors(new List<string> { WarningMessages.warning_03_0037 });
            }
            else
            {
                for (int i = 0; i < overlapping_validation.Count; i++)
                {
                    overlapping_validation.ElementAtOrDefault(i).Match(

                        is_valid:
                            valid => { },
                        is_not_valid:
                            messages =>
                            {
                                the_response_builder.add_errors(messages);
                                the_response_builder.add_errors(new List<string> { WarningMessages.warning_03_0033 });
                            }

                        );
                }

            }
            return this;
        }

        private ClashingNewBreaksValidationResualt single_enveloped()
        {
            if (the_response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(list_of_time_period, "list_of_time_period");

            var enveloping_validation = the_validator.clashing_break_validation_for_enveloped(list_of_time_period, new_break_request.from_new_request_to_time_period());

            if (enveloping_validation.Count <= 1) return this;
            for (var i = 0; i < enveloping_validation.Count; i++)
            {
                enveloping_validation.ElementAtOrDefault(i).Match(

                    is_valid:
                        valid => { },
                    is_not_valid:
                        messages => the_response_builder.add_errors(messages)

                    );
            }
            the_response_builder.add_errors(new List<string> { WarningMessages.warning_03_0035 });
            return this;
        }

        private ClashingNewBreaksValidationResualt single_envelops()
        {
            if (the_response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(list_of_time_period, "list_of_time_period");


            var envelopes_validation = the_validator.clashing_break_validation_for_envelops(list_of_time_period, new_break_request.from_new_request_to_time_period());

            if (envelopes_validation.Count < 1) return this;
            for (var i = 0; i < envelopes_validation.Count; i++)
            {
                envelopes_validation.ElementAtOrDefault(i).Match(

                    is_valid:
                        valid => { },
                    is_not_valid:
                        messages => the_response_builder.add_errors(messages)

                    );
            }

            the_response_builder.add_errors(new List<string> { WarningMessages.warning_03_0039 });
            return this;
        }

        private ClashingNewBreaksValidationResualt multipl_envelop()
        {
            if (the_response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(list_of_time_period, "list_of_time_period");

            var multiple_enveloped_validation = the_validator.clashing_break_validation_for_multiple_envelop(list_of_time_period, new_break_request.from_new_request_to_time_period());

            if (multiple_enveloped_validation.Count < 1) return this;
            for (var i = 0; i < multiple_enveloped_validation.Count; i++)
            {
                multiple_enveloped_validation.ElementAtOrDefault(i).Match(

                    is_valid:
                        valid => { },
                    is_not_valid:
                        messages => the_response_builder.add_errors(messages)

                    );
            }
            the_response_builder.add_errors(new List<string> { WarningMessages.warning_03_0041 });
            return this;
        }

        private ClashingNewBreaksValidationResualt multipl_overlap_and_envelop()
        {

            if (the_response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(list_of_time_period, "list_of_time_period");

            var multiple_enveloped_validation = the_validator.clashing_break_validation_for_multiple_overlap_and_envelop(list_of_time_period, new_break_request.from_new_request_to_time_period());

            if (multiple_enveloped_validation.Count < 1) return this;
            for (var i = 0; i < multiple_enveloped_validation.Count; i++)
            {
                multiple_enveloped_validation.ElementAtOrDefault(i).Match(

                    is_valid:
                        valid => { },
                    is_not_valid:
                        messages => the_response_builder.add_errors(messages)

                    );
            }
            the_response_builder.add_errors(new List<string> { WarningMessages.warning_03_0041 });
            return this;
        }

        private Response build_response()
        {
            return the_response_builder.build();
        }

        public ClashingNewBreaksValidationResualt(IEntityRepository<BreakTemplate> break_template_repository, ResponseBuilder<Response> response_builder, BreakValidator validator)
        {
            the_response_builder = Guard.IsNotNull(response_builder, "response_builder");
            the_validator = Guard.IsNotNull(validator, "validator");
            the_break_template_repository = Guard.IsNotNull(break_template_repository, "break_template_repository");
        }

        private List<TimePeriod> list_of_time_period; 
        private NewBreakRequest new_break_request;
        private readonly ResponseBuilder<Response> the_response_builder;
        private readonly BreakValidator the_validator;
        private readonly IEntityRepository<BreakTemplate> the_break_template_repository;
    }
}
