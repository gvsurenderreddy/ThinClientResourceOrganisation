using Content.Services.PlannedSupply.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllAssociatedShiftTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Validator;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit
{
    public class UpdateBreak
                    : IUpdateBreak
    {
        public UpdateBreakResponse execute(UpdateBreakRequest the_update_break_request)
        {
            return set_request(the_update_break_request)
                .find_break_template()
                .find_break()
                .sanitize_request()
                .validate_we_can_update_a_new_break_from_the_request()
                .validate_update_break_does_not_clash_with_existing_breaks()
                .validate_update_break_would_not_violate_an_template_shifts_that_the_break_template_has_been_applied_to()
                .update_break()
                .commit()
                .build_response()
                ;
        }

        private UpdateBreak set_request(UpdateBreakRequest the_update_break_request)
        {
            update_break_request = Guard.IsNotNull(the_update_break_request,"the_update_break_request");

            response_builder = new ResponseBuilder<BreakIdentity, UpdateBreakResponse>();
            response_builder
                .set_response(new BreakIdentity
                {
                    template_id = update_break_request.template_id,
                    break_id = update_break_request.break_id
                });

            return this;
        }

        private UpdateBreak find_break_template()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(update_break_request, "update_break_request");
            Guard.IsNotNull(break_template_repository, "break_template_repository");

            break_template = break_template_repository
                                        .Entities
                                        .Single(sbt => sbt.id == update_break_request.template_id)
                                        ;
             if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string>
                {
                    WarningMessages.warning_03_0026
                });
            }

            return this;
        }

        private UpdateBreak find_break()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(update_break_request, "update_break_request");
            Guard.IsNotNull(break_template, "break_template");

            break_to_be_updated = break_template
                                            .all_breaks
                                            .Single(sb => sb.id == update_break_request.break_id)
                                            ;
            if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string>
                {
                    WarningMessages.warning_03_0026
                });
            }

            return this;
        }

        private UpdateBreak sanitize_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(break_template, "break_template");
            Guard.IsNotNull(break_to_be_updated, "break_to_be_updated");
            Guard.IsNotNull(update_break_request, "update_break_request");

            var all_breaks = break_template
                                        .all_breaks
                                        .OrderBy(sb => sb.offset_from_start_time_in_seconds)
                                        .ToList()
                                        ;

            var order = all_breaks.IndexOf(break_to_be_updated) + 1;

            update_break_request = new UpdateBreakRequest
                                        {
                                            template_id = update_break_request.template_id,
                                            break_id = update_break_request.break_id,
                                            off_set = update_break_request.off_set.normalise_for_persistence(),
                                            duration = update_break_request.duration.normalise_for_persistence(),
                                            is_paid = update_break_request.is_paid,
                                            current_priority = order.ToString()
                                        };
            if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string>
                {
                    WarningMessages.warning_03_0026
                });
            }

            return this;
        }

        private UpdateBreak validate_we_can_update_a_new_break_from_the_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(update_break_request, "update_break_request");

            var validator_response_off_set = validator.validate_off_set(update_break_request.off_set);

            validator_response_off_set
                .Match(
                    is_valid:
                        request_off_set_in_seconds => off_set_in_seconds = request_off_set_in_seconds,

                    is_not_valid:
                        messages => response_builder.add_errors(messages)
                );

            var validator_response_duration = validator.validate_duration(update_break_request.duration);

            validator_response_duration
                .Match(
                    is_valid:
                        request_duration_in_seconds => duration_in_seconds = request_duration_in_seconds,
                    is_not_valid:
                        messages => response_builder.add_errors(messages)
                );

            if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string>
                {
                    WarningMessages.warning_03_0026
                });
            }

            return this;
        }

        private UpdateBreak validate_update_break_does_not_clash_with_existing_breaks()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(update_break_request, "update_break_request");
            response_builder.add_errors(clashing_validation_resualt.execute(update_break_request).messages);
            return this;
        }

        private UpdateBreak validate_update_break_would_not_violate_an_template_shifts_that_the_break_template_has_been_applied_to()
        {
            if (response_builder.has_errors) return this;

            validate_break_template_against_associated_shift_templates();
            if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string>
                {
                    WarningMessages.warning_03_0026
                });
            }
            return this;
        }

        private UpdateBreak update_break()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(off_set_in_seconds, "off_set_in_seconds");
            Guard.IsNotNull(duration_in_seconds, "duration_in_seconds");
            Guard.IsNotNull(update_break_request, "update_break_request");

            break_to_be_updated.offset_from_start_time_in_seconds = off_set_in_seconds.Value;
            break_to_be_updated.duration_in_seconds = duration_in_seconds.Value;
            break_to_be_updated.is_paid = update_break_request.is_paid;

            return this;
        }

        private UpdateBreak commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private UpdateBreakResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.build();
            }
            else
            {
                response_builder.add_message(ConfirmationMessages.confirmation_04_0033);
                response_builder
                        .set_response(new BreakIdentity
                        {
                            template_id = update_break_request.template_id,
                            break_id = update_break_request.break_id
                        }
                        );
            }

            return response_builder.build();
        }

        private void validate_break_template_against_associated_shift_templates()
        {
            var all_associated_shift_templates = get_all_associated_shift_templates
                                                        .execute(new BreakTemplateIdentity
                                                        {
                                                            template_id = update_break_request.template_id
                                                        })
                                                        .result
                                                        ;

            var all_break_start_time_validation_messages = new List<string>();
            var all_break_duration_validation_messages = new List<string>();

            foreach (var shift_template in all_associated_shift_templates)
            {
                var shift_end_time_in_seconds = shift_template.start_time.to_Seconds() + shift_template.duration.to_seconds();

                if (off_set_in_seconds == null) continue;
                var break_start_time_in_seconds = shift_template.start_time.to_Seconds()+off_set_in_seconds.Value;
                if ( shift_validator.are_the_associated_breaks_within_the_shift_boundary( break_start_time_in_seconds, 0, shift_end_time_in_seconds ) == false )
                {
                    all_break_start_time_validation_messages.Add( string.Format("{0} Start time {1}, Duration {2}.", shift_template.shift_title, shift_template.start_time.to_domain_string(), shift_template.duration.to_domain_format_string() ) );
                }

                if (duration_in_seconds == null) continue;
                var break_end_time_in_seconds = break_start_time_in_seconds + duration_in_seconds.Value;
                if ( shift_validator.are_the_associated_breaks_within_the_shift_boundary( 0, break_end_time_in_seconds, shift_end_time_in_seconds ) == false )
                {
                    all_break_duration_validation_messages.Add( string.Format("{0} Start time {1}, Duration {2}.", shift_template.shift_title, shift_template.start_time.to_domain_string(), shift_template.duration.to_domain_format_string() ) );
                }
            }

            if (all_break_start_time_validation_messages.Count > 0)
            {
                var message = "This break duration cannot be used because it starts beyond the end of the following shift templates it is applied to: ";

                foreach ( var error in all_break_start_time_validation_messages )
                {
                    message = message + "<br> - " + error;
                }

                response_builder.add_error( message.ToResponseMessage( "off_set" ) );
            }

            if (all_break_duration_validation_messages.Count > 0)
            {
                var message = "This break duration cannot be used because it lasts beyond the end of the following shift templates it is applied to: ";

                foreach ( var error in all_break_duration_validation_messages )
                {
                    message = message + "<br> - " + error;
                }

                response_builder.add_error( message.ToResponseMessage("duration" ) );
            }

        }


        public UpdateBreak ( IUnitOfWork the_unit_of_work,
                             BreakValidator the_validator,
                             ShiftValidator the_shift_validator,
                             IGetAllAssociatedShiftTemplatesForBreakTemplate the_get_all_associated_shift_templates,
                             ClashingUpdateBreaksValidationResualt the_clashing_validation_resualt,
                             IEntityRepository<BreakTemplate> the_break_template_repository)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            shift_validator = Guard.IsNotNull(the_shift_validator, "the_shift_validator");
            get_all_associated_shift_templates = Guard.IsNotNull(the_get_all_associated_shift_templates, "the_get_all_associated_shift_templates");
            clashing_validation_resualt = Guard.IsNotNull(the_clashing_validation_resualt, "the_clashing_validation_resualt");
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
        }

        private readonly IEntityRepository<BreakTemplate> break_template_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly BreakValidator validator;
        private readonly ShiftValidator shift_validator;
        private readonly IGetAllAssociatedShiftTemplatesForBreakTemplate get_all_associated_shift_templates;
        private ResponseBuilder<BreakIdentity, UpdateBreakResponse> response_builder;
        private BreakTemplate break_template;
        private UpdateBreakRequest update_break_request;
        private Breaks.Break break_to_be_updated;
        private int? off_set_in_seconds;
        private int? duration_in_seconds;
        private readonly ClashingUpdateBreaksValidationResualt clashing_validation_resualt;
        
    }
}