using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Colour.Sanatisation;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.PlannedSupply.Defaults;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.New
{
    public class NewShiftTemplates
                       : INewShiftTemplates
    {
        public NewShiftTemplateResponse execute
                                            (NewShiftTemplatesRequest the_request)
        {
            return this
                .set_request(the_request)
                .sanatise_request()
                .find_break_template()
                .validate_request()
                .create()
                .commit()
                .build_response();
        }

        private NewShiftTemplates set_request
                                    (NewShiftTemplatesRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder = new ResponseBuilder<ShiftTemplateIdentity, NewShiftTemplateResponse>();
            response_builder.set_response(new ShiftTemplateIdentity
            {
                shift_template_id = Null.Id
            });
            return this;
        }

        private NewShiftTemplates sanatise_request()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            request = new NewShiftTemplatesRequest
            {
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

        private NewShiftTemplates find_break_template()
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

        private NewShiftTemplates validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_template_repository, "repository");
            Guard.IsNotNull( associated_break_template, "associated_break_template" );

            bool has_a_duplicate_shift_template_exist_with_this_name = !shift_template_repository.name_is_unique(new ShiftTemplateNameIsUniqueRequest(Null.Id, request.shift_title));

            response_builder.add_errors(validator.validate_name(request.shift_title, has_a_duplicate_shift_template_exist_with_this_name));

            validator
                .validate_start_time(request.start_time)
                .Match(

                    is_valid:
                        request_start_time_in_seconds_from_midnight =>
                            start_time_in_seconds_from_midnight = request_start_time_in_seconds_from_midnight,

                    is_not_valid:
                        messages => response_builder.add_errors(messages)

                );

            validator
                .validate_duration(request.duration)
                .Match(

                    is_valid:
                       request_duration_in_second =>
                             duration_in_second = request_duration_in_second,

                    is_not_valid:
                       message => response_builder.add_errors(message)
                );

            validator
                .validate_rgb_colour(request.colour)
                .Match(

                    is_valid:
                      colour_in_rgb_format =>
                             requested_colour = colour_in_rgb_format,

                    is_not_valid:
                        error => response_builder.add_errors(error)
                );

            validate_break_template();

            if (response_builder.has_errors)
            {
                response_builder.add_error(WarningMessages.warning_03_0019);
            }
            return this;
        }

        private NewShiftTemplates create()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.PremiseHolds(start_time_in_seconds_from_midnight.HasValue, "HasValue");
            Guard.PremiseHolds(duration_in_second.HasValue, "HasValue");
            Guard.IsNotNull(requested_colour, "requested_colour");

            BreakTemplates.BreakTemplate break_template_to_be_added = null;

            associated_break_template
                .Match(

                    has_value:
                        break_template => break_template_to_be_added = break_template,

                    nothing:
                        () => { } // this means it has been set to not specified

                );

            

            entity = new ShiftTemplates.ShiftTemplate
            {
                shift_title = request.shift_title,
                start_time_in_seconds_from_midnight = start_time_in_seconds_from_midnight.Value,
                duration_in_seconds = duration_in_second.Value,
                colour = requested_colour.ToString(),
                break_template = break_template_to_be_added
            };

            shift_template_repository.add(entity);
            return this;
        }

        private NewShiftTemplates commit()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(entity, "entity");

            unit_of_work.Commit();

            response_builder.set_response(new ShiftTemplateIdentity
            {
                shift_template_id = entity.id
            });
            response_builder.add_message(ConfirmationMessages.confirmation_04_0023);
            return this;
        }

        private NewShiftTemplateResponse build_response()
        {
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
                                            if ( validator.are_the_associated_breaks_within_the_shift_boundary( break_start_time_in_seconds, break_end_time_in_seconds, shift_end_time_in_seconds ) == false )
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

        private int get_shift_start_time_in_seconds(TimeRequest the_start_time)
        {
            int start_time_hours;
            int.TryParse(the_start_time.hours, out start_time_hours);

            int start_time_minutes;
            int.TryParse(the_start_time.minutes, out start_time_minutes);

            return (start_time_hours * Times_to_convert_an_hour_in_seconds) + (start_time_minutes * Times_to_convert_a_minute_in_seconds);
        }

        private int get_shift_duration_in_seconds(DurationRequest the_duration)
        {
            int duration_hours;
            int.TryParse(the_duration.hours, out duration_hours);

            int duration_minutes;
            int.TryParse(the_duration.minutes, out duration_minutes);

            return (duration_hours * Times_to_convert_an_hour_in_seconds) + (duration_minutes * Times_to_convert_a_minute_in_seconds);
        }

        public NewShiftTemplates
                (IEntityRepository<ShiftTemplates.ShiftTemplate> the_repository,
                 IEntityRepository<BreakTemplates.BreakTemplate> the_break_template_repository,
                 IUnitOfWork the_unit_of_work,
                 ShiftValidator the_validator
                )
        {
            shift_template_repository = Guard.IsNotNull(the_repository, "the_repository");
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        private readonly IEntityRepository<ShiftTemplates.ShiftTemplate> shift_template_repository;
        private readonly IEntityRepository<BreakTemplates.BreakTemplate> break_template_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly ShiftValidator validator;

        private ResponseBuilder<ShiftTemplateIdentity, NewShiftTemplateResponse> response_builder;
        private NewShiftTemplatesRequest request;
        private int? start_time_in_seconds_from_midnight;
        private int? duration_in_second;
        private RgbColour requested_colour;
        private ShiftTemplates.ShiftTemplate entity;
        private Maybe<BreakTemplates.BreakTemplate> associated_break_template;

        private const int Times_to_convert_an_hour_in_seconds = 60 * 60;
        private const int Times_to_convert_a_minute_in_seconds = 60;
    }
}