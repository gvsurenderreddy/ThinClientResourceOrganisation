using Content.Services.PlannedSupply.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllAssociatedShiftTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Validator;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New
{
    public class NewBreak
                    : INewBreak
    {
        public NewBreakResponse execute(NewBreakRequest the_new_break_request)
        {
            return
                 set_request(the_new_break_request)
                .sanitize_request()
                .find_break_template()
                .validate_we_can_create_a_new_break_from_the_request()
                .validate_new_break_does_not_clash_with_existing_breaks()
                .validate_new_break_would_not_violate_an_template_shifts_that_the_break_template_has_been_applied_to()
                .create_new_break()
                .commit()
                .build_response()
                ;
        }

        private NewBreak set_request(NewBreakRequest the_new_break_request)
        {
            new_break_request = Guard.IsNotNull(the_new_break_request, "the_new_break_request");

            response_builder = new ResponseBuilder<BreakIdentity, NewBreakResponse>();
            response_builder
                .set_response(new BreakIdentity
                {
                    template_id = new_break_request.template_id,
                    break_id = Null.Id
                });

            return this;
        }

        private NewBreak sanitize_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(new_break_request, "new_break_request");

            new_break_request = new NewBreakRequest
            {
                template_id = new_break_request.template_id,
                break_id = new_break_request.break_id,
                off_set = new_break_request.off_set.normalise_for_persistence(), 
                duration = new_break_request.duration.normalise_for_persistence(),
                is_paid = new_break_request.is_paid
            };

            return this;
        }

        private NewBreak find_break_template()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(break_template_repository, "break_template_repository");

            break_template = break_template_repository
                                        .Entities
                                        .Single(sbt => sbt.id == new_break_request.template_id)
                                        ;

            return this;
        }

        private NewBreak validate_we_can_create_a_new_break_from_the_request()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            Guard.IsNotNull(new_break_request, "new_break_request");

            validator.validate_off_set(new_break_request.off_set)
                .Match(

                        is_valid:
                               request_off_set_in_seconds => off_set_in_seconds = request_off_set_in_seconds,
                        is_not_valid:
                              messages => response_builder.add_errors(messages)
                );

            validator.validate_duration(new_break_request.duration)
               .Match(
                   is_valid:
                       request_duration_in_seconds => duration_in_seconds = request_duration_in_seconds,
                   is_not_valid:
                       messages => response_builder.add_errors(messages)
               );

            if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string> { WarningMessages.warning_03_0025 });
            }
            return this;
        }

        private NewBreak validate_new_break_does_not_clash_with_existing_breaks()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(new_break_request, "new_break_request");
            response_builder.add_errors(clashing_validation_result.execute(new_break_request).messages);
            return this;
        }

        private NewBreak validate_new_break_would_not_violate_an_template_shifts_that_the_break_template_has_been_applied_to()
        {
            if (response_builder.has_errors) return this;
            validate_break_template_against_associated_shift_templates();
            return this;
        }

        private NewBreak create_new_break()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(off_set_in_seconds, "off_set_in_seconds");
            Guard.IsNotNull(duration_in_seconds, "duration_in_seconds");
            Guard.IsNotNull(break_template, "break_template");
            Guard.IsNotNull(new_break_request, "new_break_request");

            new_break = new Breaks.Break
            {
                offset_from_start_time_in_seconds = off_set_in_seconds.Value,
                duration_in_seconds = duration_in_seconds.Value,
                is_paid = new_break_request.is_paid
            };

            break_template.all_breaks.Add(new_break);

            return this;
        }

        private NewBreak commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private NewBreakResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.build();
            }
            else
            {
                response_builder.add_message(ConfirmationMessages.confirmation_04_0032);

                response_builder
                    .set_response(new BreakIdentity
                    {
                        template_id = break_template.id,
                        break_id = new_break.id
                    });
            }

            return response_builder.build();
        }

        /// <summary>
        /// this validation is about when we want to apply the new break into the shift template.
        /// new break should not violate shift, that the break has been applied to .
        /// this validation should not be located here .(should find a place for move this validation from this class)
        /// the way of representing error messages in this method is wrong .
        /// </summary>
        private void validate_break_template_against_associated_shift_templates()
        {
            var all_associated_shift_templates = get_all_associated_shift_templates
                                                        .execute(new BreakTemplateIdentity
                                                        {
                                                            template_id = new_break_request.template_id
                                                        })
                                                        .result
                                                        ;

            var all_break_start_time_validation_messages = new List<string>();
            var all_break_duration_validation_messages = new List<string>();

            foreach (var shift_template in all_associated_shift_templates)
            {
                var shift_end_time_in_seconds = shift_template.start_time.to_Seconds() + shift_template.duration.to_seconds();

                if (off_set_in_seconds == null) continue;
                var break_start_time_in_seconds = shift_template.start_time.to_Seconds() + off_set_in_seconds.Value;
                if (shift_validator.are_the_associated_breaks_within_the_shift_boundary(break_start_time_in_seconds, 0, shift_end_time_in_seconds) == false)
                {
                    all_break_start_time_validation_messages.Add(string.Format("{0} Start time {1}, Duration {2}.", shift_template.shift_title, shift_template.start_time.to_domain_string(), shift_template.duration.to_domain_format_string()));
                }

                if (duration_in_seconds == null) continue;
                var break_end_time_in_seconds = break_start_time_in_seconds + duration_in_seconds.Value;
                if (shift_validator.are_the_associated_breaks_within_the_shift_boundary(0, break_end_time_in_seconds, shift_end_time_in_seconds) == false)
                {
                    all_break_duration_validation_messages.Add(string.Format("{0} Start time {1}, Duration {2}.", shift_template.shift_title, shift_template.start_time.to_domain_string(), shift_template.duration.to_domain_format_string()));
                }
            }

            if (all_break_start_time_validation_messages.Count > 0)
            {
                var message = "This break duration cannot be used because it starts beyond the end of the following shift templates it is applied to: ";

                foreach (var error in all_break_start_time_validation_messages)
                {
                    message = message + "<br> - " + error;
                }

                response_builder.add_error(message.ToResponseMessage("off_set"));
            }

            if (all_break_duration_validation_messages.Count > 0)
            {
                var message = "This break duration cannot be used because it lasts beyond the end of the following shift templates it is applied to: ";

                foreach (var error in all_break_duration_validation_messages)
                {
                    message = message + "<br> - " + error;
                }

                response_builder.add_error(message.ToResponseMessage("duration"));
            }

        }


        public NewBreak ( IEntityRepository<BreakTemplate> the_break_template_repository,
                          IGetAllAssociatedShiftTemplatesForBreakTemplate the_get_all_associated_shift_templates,
                          IUnitOfWork the_unit_of_work,
                          BreakValidator the_validator,
                          ShiftValidator the_shift_validator,
                          ClashingNewBreaksValidationResualt the_clashing_validation_result
                          )
        {
            get_all_associated_shift_templates = Guard.IsNotNull(the_get_all_associated_shift_templates, "the_get_all_associated_shift_templates");
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            shift_validator = Guard.IsNotNull(the_shift_validator, "the_shift_validator");
            clashing_validation_result = Guard.IsNotNull(the_clashing_validation_result, "the_clashing_validation_result");
        }

        private readonly IGetAllAssociatedShiftTemplatesForBreakTemplate get_all_associated_shift_templates;
        private readonly IEntityRepository<BreakTemplate> break_template_repository;
        private ResponseBuilder<BreakIdentity, NewBreakResponse> response_builder;
        private readonly ShiftValidator shift_validator;
        private NewBreakRequest new_break_request;
        private readonly IUnitOfWork unit_of_work;
        private readonly BreakValidator validator;
        private int? off_set_in_seconds;
        private int? duration_in_seconds;
        private BreakTemplate break_template;
        private Breaks.Break new_break;
        private readonly ClashingNewBreaksValidationResualt clashing_validation_result;

    }
}
