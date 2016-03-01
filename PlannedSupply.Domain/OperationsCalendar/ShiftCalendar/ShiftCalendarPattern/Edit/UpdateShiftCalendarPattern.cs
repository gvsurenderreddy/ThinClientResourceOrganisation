using Content.Services.PlannedSupply.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit
{
    public class UpdateShiftCalendarPattern
                    : IUpdateShiftCalendarPattern
    {
        public UpdateShiftCalendarPatternResponse execute(UpdateShiftCalendarPatternRequest the_update_shift_calendar_pattern_request)
        {
            return this
                .set_request(the_update_shift_calendar_pattern_request)
                .authorize_to_update_shift_calendar_pattern()
                .sanitize_request()
                .find_operational_calendar()
                .find_shift_calendar()
                .find_shift_calendar_pattern()
                .validate_request()
                .update_shift_calendar()
                .commit()
                .publish_shift_calendar_pattern_updated_event()
                .build_response()
                ;
        }

        private UpdateShiftCalendarPattern set_request(UpdateShiftCalendarPatternRequest the_update_shift_calendar_pattern_request)
        {
            _update_shift_calendar_pattern_request = Guard.IsNotNull(the_update_shift_calendar_pattern_request,
                                                                    "the_update_shift_calendar_pattern_request"
                                                                    );

            _response_builder = new ResponseBuilder<ShiftCalendarPatternIdentity, UpdateShiftCalendarPatternResponse>();

            _response_builder
                .set_response(new ShiftCalendarPatternIdentity
                                    {
                                        operations_calendar_id = _update_shift_calendar_pattern_request.operations_calendar_id,
                                        shift_calendar_id = _update_shift_calendar_pattern_request.shift_calendar_id,
                                        shift_calendar_pattern_id = _update_shift_calendar_pattern_request.shift_calendar_pattern_id
                                    }
                             )
                ;

            return this;
        }

        private UpdateShiftCalendarPattern authorize_to_update_shift_calendar_pattern()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");

            if (has_execution_permission_not_granted())
            {
                _response_builder.add_error(WarningMessages.warning_03_0022);
            }

            return this;
        }

        private UpdateShiftCalendarPattern sanitize_request()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");

            _update_shift_calendar_pattern_request = new UpdateShiftCalendarPatternRequest
                                                            {
                                                                operations_calendar_id = _update_shift_calendar_pattern_request.operations_calendar_id,
                                                                shift_calendar_id = _update_shift_calendar_pattern_request.shift_calendar_id,
                                                                shift_calendar_pattern_id = _update_shift_calendar_pattern_request.shift_calendar_pattern_id,
                                                                pattern_name = _update_shift_calendar_pattern_request.pattern_name.normalise_for_persistence(),
                                                                number_of_resources = _update_shift_calendar_pattern_request.number_of_resources.normalise_for_persistence()
                                                            };

            return this;
        }

        private UpdateShiftCalendarPattern find_operational_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");
            Guard.IsNotNull(_operational_calendar_repository, "_operational_calendar_repository");

            _operational_calendar = _operational_calendar_repository
                                            .Entities
                                            .Single(oc => oc.id == _update_shift_calendar_pattern_request.operations_calendar_id)
                                            ;
            return this;
        }

        private UpdateShiftCalendarPattern find_shift_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");
            Guard.IsNotNull(_operational_calendar, "_operational_calendar");

            _shift_calendar = _operational_calendar
                                    .ShiftCalendars
                                    .Single(sc => sc.id == _update_shift_calendar_pattern_request.shift_calendar_id)
                                    ;
            return this;
        }

        private UpdateShiftCalendarPattern find_shift_calendar_pattern()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");

            _shift_calendar_pattern_to_be_updated = _shift_calendar
                                                        .ShiftCalendarPatterns
                                                        .Single(scp => scp.id == _update_shift_calendar_pattern_request.shift_calendar_pattern_id)
                                                        ;

            return this;
        }

        private UpdateShiftCalendarPattern validate_request()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_validator, "_validator");

            if (has_validation_errors())
            {
                _response_builder.add_errors(_validation_errors);
            }

            return this;
        }

        private UpdateShiftCalendarPattern update_shift_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_update_shift_calendar_pattern_request, "_update_shift_calendar_pattern_request");
            Guard.IsNotNull(_shift_calendar_pattern_to_be_updated, "_shift_calendar_pattern_to_be_updated");

            _shift_calendar_pattern_to_be_updated.name = _update_shift_calendar_pattern_request.pattern_name;

            int number_of_resources;
            int.TryParse(_update_shift_calendar_pattern_request.number_of_resources, out number_of_resources);
            _shift_calendar_pattern_to_be_updated.number_of_resources = number_of_resources;

            return this;
        }

        private UpdateShiftCalendarPattern commit()
        {
            if (response_builder_has_errors()) return this;

            _unit_of_work.Commit();

            return this;
        }

        private UpdateShiftCalendarPattern publish_shift_calendar_pattern_updated_event()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_operational_calendar, "_operational_calendar");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_shift_calendar_pattern_to_be_updated, "_shift_calendar_pattern_to_be_updated");

            _shift_calendar_pattern_updated_event_publisher.publish(new ShiftCalendarPatternUpdatedEvent
                                                                            {
                                                                                operations_calendar_id = _operational_calendar.id,
                                                                                shift_calendar_id = _shift_calendar.id,
                                                                                shift_calendar_pattern_id = _shift_calendar_pattern_to_be_updated.id,
                                                                                name = _shift_calendar_pattern_to_be_updated.name,
                                                                                number_of_resources = _shift_calendar_pattern_to_be_updated.number_of_resources,
                                                                                priority = _shift_calendar_pattern_to_be_updated.priority
                                                                            });

            return this;
        }

        private UpdateShiftCalendarPatternResponse build_response()
        {
            if (response_builder_has_errors())
            {
                _response_builder.add_errors(new List<string> { WarningMessages.warning_03_0022 });
            }
            else
            {
                _response_builder.add_message(ConfirmationMessages.confirmation_04_0027);
                _response_builder
                    .set_response(new ShiftCalendarPatternIdentity
                                        {
                                            operations_calendar_id = _operational_calendar.id,
                                            shift_calendar_id = _shift_calendar.id,
                                            shift_calendar_pattern_id = _shift_calendar_pattern_to_be_updated.id
                                        }
                                 )
                    ;
            }

            return _response_builder.build();
        }

        private bool response_builder_has_errors()
        {
            return _response_builder.has_errors;
        }

        private bool has_execution_permission_not_granted()
        {
            return _execute_permission.IsGrantedFor(_update_shift_calendar_pattern_request) == false;
        }

        private bool has_validation_errors()
        {
            ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern = _shift_calendar
                                                                                    .ShiftCalendarPatterns
                                                                                    .SingleOrDefault(scp => scp.name.Equals(_update_shift_calendar_pattern_request.pattern_name,
                                                                                                                                StringComparison.InvariantCultureIgnoreCase
                                                                                                                            ) && scp.id != _shift_calendar_pattern_to_be_updated.id
                                                                                                    );

            bool has_a_duplicate_shift_calendar_pattern_exist_with_this_name = shift_calendar_pattern != null;

            _validator
                .field("number_of_resources")
                .is_madatory(_update_shift_calendar_pattern_request.number_of_resources, ValidationMessages.error_00_0059)
                .does_not_contain_non_numeric_characters(_update_shift_calendar_pattern_request.number_of_resources, ValidationMessages.error_00_0061)
                ;

            if (_validator.errors.Any() == false)
            {
                _validator
                    .field("number_of_resources")
                    .does_not_contain_less_than_one_for_a_number_field(
                        _update_shift_calendar_pattern_request.number_of_resources, ValidationMessages.error_00_0060)
                    ;
            }

            _validator
                .field("pattern_name")
                     .is_madatory(_update_shift_calendar_pattern_request.pattern_name, ValidationMessages.error_00_0042)
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(_update_shift_calendar_pattern_request.pattern_name, ValidationMessages.error_00_0037)
                     .premise_holds(!has_a_duplicate_shift_calendar_pattern_exist_with_this_name, ValidationMessages.error_00_0043)
                    ;

            _validation_errors = _validator.errors;

            return _validation_errors.Any();
        }

        public UpdateShiftCalendarPattern(IEntityRepository<OperationalCalendar> the_operational_calendar_repository,
                                        IUnitOfWork the_unit_of_work,
                                        Validator the_validator,
                                        ICanUpdateShiftCalendarPattern the_execute_permission,
                                        IEventPublisher<ShiftCalendarPatternUpdatedEvent> the_shift_calendar_pattern_updated_event_publisher
                                      )
        {
            _operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository,
                                                                "the_operational_calendar_repository"
                                                              );
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            _validator = Guard.IsNotNull(the_validator, "the_validator");
            _execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            _shift_calendar_pattern_updated_event_publisher = Guard.IsNotNull(the_shift_calendar_pattern_updated_event_publisher,
                                                                              "the_shift_calendar_pattern_updated_event_publisher"
                                                                             );
        }

        private readonly IEntityRepository<OperationalCalendar>
            _operational_calendar_repository;

        private readonly IUnitOfWork _unit_of_work;
        private readonly Validator _validator;
        private readonly IEventPublisher<ShiftCalendarPatternUpdatedEvent> _shift_calendar_pattern_updated_event_publisher;

        private readonly ICanUpdateShiftCalendarPattern _execute_permission;

        private UpdateShiftCalendarPatternRequest _update_shift_calendar_pattern_request;
        private OperationalCalendar _operational_calendar;
        private ShiftCalendars.ShiftCalendar _shift_calendar;
        private ShiftCalendarPatterns.ShiftCalendarPattern _shift_calendar_pattern_to_be_updated;
        private IEnumerable<ResponseMessage> _validation_errors;

        private ResponseBuilder<ShiftCalendarPatternIdentity, UpdateShiftCalendarPatternResponse> _response_builder;
    }
}