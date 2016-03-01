using Content.Services.PlannedSupply.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Colour.Sanatisation;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.PlannedSupply.Defaults;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Edit
{
    public class UpdateShiftTemplate
                    : IUpdateShiftTemplate
    {
        public UpdateShiftTemplateResponse execute
                                           (UpdateShiftTemplateRequest the_request)
        {
            return this
                .set_request(the_request)
                .sanatise_request()
                .find_shift_template()
                .find_break_template()
                .validate()
                .update_shift_template()
                .commit()
                .build_response();
        }

        private UpdateShiftTemplate set_request(UpdateShiftTemplateRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_Request");
            response_builder = new ResponseBuilder<ShiftTemplateIdentity, UpdateShiftTemplateResponse>();

            response_builder.set_response(new ShiftTemplateIdentity()
            {
                shift_template_id = request.shift_template_id
            });
            return this;
        }

        private UpdateShiftTemplate sanatise_request()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");
            request = new UpdateShiftTemplateRequest()
            {
                shift_template_id = request.shift_template_id,
                shift_title = request.shift_title.normalise_for_persistence(),
                start_time = new TimeRequest()
                {
                    hours = request.start_time.hours.normalise_for_persistence(),
                    minutes = request.start_time.minutes.normalise_for_persistence()
                },

                duration = new DurationRequest()
                {
                    hours = request.duration.hours.normalise_for_persistence(),
                    minutes = request.duration.minutes.normalise_for_persistence()
                },
                colour = request.colour.default_if_not_specifed(DefaultShiftColour.create()),
                break_template_id = request.break_template_id
            };
            return this;
        }

        private UpdateShiftTemplate find_shift_template()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_template_repository, "repository");

            entity = shift_template_repository
                .Entities
                .Single(x => x.id == request.shift_template_id);
            return this;
        }

        private UpdateShiftTemplate find_break_template()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            associated_break_template = break_template_repository
                                            .Entities
                                            .SingleOrDefault(bt => bt.id == request.break_template_id)
                                            .to_maybe()
                                            ;

            return this;
        }

        private UpdateShiftTemplate validate()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_template_repository, "repository");
            Guard.IsNotNull(associated_break_template, "associated_break_template");

            var has_a_duplicate_shift_template_exist_with_this_name = !shift_template_repository.name_is_unique(new ShiftTemplateNameIsUniqueRequest(request.shift_template_id, request.shift_title));

            response_builder
                .add_errors( validator.validate_name( request.shift_title,  has_a_duplicate_shift_template_exist_with_this_name ));

            validator
                .validate_start_time( request.start_time )
                .Match(
                    is_valid:
                          request_start_time_in_seconds_from_midnight =>
                            start_time_in_seconds_from_midnight = request_start_time_in_seconds_from_midnight,

                    is_not_valid:
                          messages => response_builder.add_errors( messages )
                 );

            validator
                .validate_duration( request.duration )
                .Match(
                    is_valid:
                        request_duration_in_second => duration_in_seconds = request_duration_in_second,

                    is_not_valid:
                        message => response_builder.add_errors( message )
               );

            validator
               .validate_rgb_colour( request.colour )
               .Match(
                    is_valid:
                        request_colour_in_rgb_format => 
                            colour_in_the_rgb_format = request_colour_in_rgb_format,

                    is_not_valid:
                        error => response_builder.add_errors( error )
               );

            validate_break_template();

            return this;
        }

        private UpdateShiftTemplate update_shift_template()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull( request, "request");
            Guard.IsNotNull( entity, "entity" );
            Guard.PremiseHolds( duration_in_seconds.HasValue, "HasValue" );
            Guard.PremiseHolds( start_time_in_seconds_from_midnight.HasValue, "HasValue");
            Guard.IsNotNull( colour_in_the_rgb_format, "colour_in_the_rgb_format" );

            BreakTemplates.BreakTemplate break_template_to_be_updated = null;

            associated_break_template
                .Match(

                    has_value:
                        break_template => break_template_to_be_updated = break_template,

                    nothing:
                        () => { } // this means it has been set to not specified

                );

            // ReSharper disable PossibleInvalidOperationException
            entity.shift_title = request.shift_title;
            entity.start_time_in_seconds_from_midnight = start_time_in_seconds_from_midnight.Value;
            entity.duration_in_seconds = duration_in_seconds.Value;
            entity.colour = colour_in_the_rgb_format.ToString();
            entity.break_template = break_template_to_be_updated;
            // ReSharper restore PossibleInvalidOperationException

            return this;
        }

        private UpdateShiftTemplate commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            response_builder.add_message(ConfirmationMessages.confirmation_04_0024);

            return this;
        }

        private UpdateShiftTemplateResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_errors(new List<string> { WarningMessages.warning_03_0020 });
            }
            else
            {
                response_builder.set_response(new ShiftTemplateIdentity()
                {
                    shift_template_id = entity.id
                });
            }

            return response_builder.build();
        }

        private void validate_break_template()
        {
            if (associated_break_template == null) return;

            var shift_start_time_in_seconds = get_shift_start_time_in_seconds(request.start_time);
            var shift_duration_in_seconds = get_shift_duration_in_seconds(request.duration);
            var shift_end_time_in_seconds = shift_start_time_in_seconds + shift_duration_in_seconds;

            associated_break_template
                .Match(

                    has_value:
                        break_template =>
                                    {
                                        var all_breaks = break_template.all_breaks.OrderBy(sb => sb.offset_from_start_time_in_seconds);
                                        var last_break = all_breaks.LastOrDefault();

                                        last_break
                                            .to_maybe()
                                            .Match(

                                                has_value:
                                                    shift_break =>
                                                        {
                                                            int break_start_time_in_seconds = shift_start_time_in_seconds + shift_break.offset_from_start_time_in_seconds;
                                                            int break_end_time_in_seconds = break_start_time_in_seconds + shift_break.duration_in_seconds;

                                                            //response_builder.add_errors(validator.is_a_validate_break_template(break_start_time_in_seconds, break_end_time_in_seconds, shift_end_time_in_seconds, "break_template_id", ValidationMessages.error_00_0082));
                                                            if ( validator.are_the_associated_breaks_within_the_shift_boundary( break_start_time_in_seconds,break_end_time_in_seconds, shift_end_time_in_seconds ) == false )
                                                            {
                                                                response_builder.add_error( ValidationMessages.error_00_0082.ToResponseMessage( "break_template_id" ) );
                                                            }
                                                        },

                                                nothing:
                                                    () => { } // this means there is no break in shift break template.
                                            );
                                    },

                    nothing:
                        () => { } // this means it has been set to not specified

                );            
        }

        private int get_shift_start_time_in_seconds( TimeRequest the_start_time )
        {
            int start_time_hours;
            int.TryParse(the_start_time.hours, out start_time_hours);

            int start_time_minutes;
            int.TryParse(the_start_time.minutes, out start_time_minutes);

            return ( start_time_hours * Times_to_convert_an_hour_in_seconds ) + ( start_time_minutes * Times_to_convert_a_minute_in_seconds );
        }

        private int get_shift_duration_in_seconds( DurationRequest the_duration )
        {
            int duration_hours;
            int.TryParse(the_duration.hours, out duration_hours);

            int duration_minutes;
            int.TryParse(the_duration.minutes, out duration_minutes);

            return ( duration_hours * Times_to_convert_an_hour_in_seconds ) + ( duration_minutes * Times_to_convert_a_minute_in_seconds );
        }

        public UpdateShiftTemplate(IUnitOfWork the_unit_of_work
                                   , IEntityRepository<ShiftTemplates.ShiftTemplate> the_shift_template_repository
                                   , IEntityRepository<BreakTemplates.BreakTemplate> the_break_template_repository
                                   , ShiftValidator the_validator
                                  )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            shift_template_repository = Guard.IsNotNull(the_shift_template_repository, "the_shift_template_repository");
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<ShiftTemplates.ShiftTemplate> shift_template_repository;
        private readonly IEntityRepository<BreakTemplates.BreakTemplate> break_template_repository;
        private readonly ShiftValidator validator;

        private ResponseBuilder<ShiftTemplateIdentity, UpdateShiftTemplateResponse> response_builder;
        private ShiftTemplates.ShiftTemplate entity;
        private UpdateShiftTemplateRequest request;
        private int? start_time_in_seconds_from_midnight;
        private RgbColour colour_in_the_rgb_format;
        private int? duration_in_seconds;
        private Maybe<BreakTemplates.BreakTemplate> associated_break_template;

        private const int Times_to_convert_an_hour_in_seconds = 60 * 60;
        private const int Times_to_convert_a_minute_in_seconds = 60;
    }
}