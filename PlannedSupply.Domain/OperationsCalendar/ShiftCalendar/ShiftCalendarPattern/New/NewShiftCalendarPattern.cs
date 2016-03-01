using Content.Services.PlannedSupply.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New
{
    public class NewShiftCalendarPattern
                        : INewShiftCalendarPattern
    {
        public NewShiftCalendarPatternResponse execute(NewShiftCalendarPatternRequest the_new_shift_calendar_pattern_request)
        {
            return this
                .set_request(the_new_shift_calendar_pattern_request)
                .authorise_to_create_a_new_shift_calendar_pattern()
                .sanitize_request()
                .find_operational_calendar()
                .find_shift_calendar()
                .validate_request()
                .create_new_shift_calendar_pattern()
                .commit()
                .publish_shift_calender_pattern_created_event()
                .publish_shift_calendar_pattern_auto_reordered_events()
                .build_response()
                ;
        }

        private NewShiftCalendarPattern set_request(NewShiftCalendarPatternRequest the_new_shift_calendar_pattern_request)
        {
            _new_shift_calendar_pattern_request = Guard.IsNotNull(the_new_shift_calendar_pattern_request,
                                                                    "the_new_shift_calendar_pattern_request"
                                                                 );
            _response_builder = new ResponseBuilder<ShiftCalendarPatternIdentity, NewShiftCalendarPatternResponse>();

            _response_builder
                .set_response(new ShiftCalendarPatternIdentity
                                    {
                                        shift_calendar_pattern_id = Null.Id
                                    }
                             );
            return this;
        }

        private NewShiftCalendarPattern authorise_to_create_a_new_shift_calendar_pattern()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_new_shift_calendar_pattern_request, "_new_shift_calendar_pattern_request");

            if (has_execution_permission_not_granted())
            {
                _response_builder.add_error(WarningMessages.warning_03_0021);
            }

            return this;
        }

        private NewShiftCalendarPattern sanitize_request()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_new_shift_calendar_pattern_request, "_new_shift_calendar_pattern_request");

            _new_shift_calendar_pattern_request = new NewShiftCalendarPatternRequest
                                                            {
                                                                operations_calendar_id = _new_shift_calendar_pattern_request.operations_calendar_id,
                                                                shift_calendar_id = _new_shift_calendar_pattern_request.shift_calendar_id,
                                                                pattern_name = _new_shift_calendar_pattern_request.pattern_name.normalise_for_persistence(),
                                                                number_of_resources = _new_shift_calendar_pattern_request.number_of_resources.normalise_for_persistence()
                                                            };

            return this;
        }

        private NewShiftCalendarPattern find_operational_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_new_shift_calendar_pattern_request, "_new_shift_calendar_pattern_request");
            Guard.IsNotNull(_operational_calendar_repository, "_operational_calendar_repository");

            _operational_calendar = _operational_calendar_repository
                                            .Entities
                                            .Single(oc => oc.id == _new_shift_calendar_pattern_request.operations_calendar_id)
                                            ;

            return this;
        }

        private NewShiftCalendarPattern find_shift_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_new_shift_calendar_pattern_request, "_new_shift_calendar_pattern_request");
            Guard.IsNotNull(_operational_calendar, "_operational_calendar");

            _shift_calendar = _operational_calendar
                                    .ShiftCalendars
                                    .Single(sc => sc.id == _new_shift_calendar_pattern_request.shift_calendar_id)
                                    ;

            return this;
        }

        private NewShiftCalendarPattern validate_request()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_new_shift_calendar_pattern_request, "_new_shift_calendar_pattern_request");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_validator, "_validator");

            if (has_validation_errors())
            {
                _response_builder.add_errors(_validation_errors);
            }

            return this;
        }

        private NewShiftCalendarPattern create_new_shift_calendar_pattern()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_new_shift_calendar_pattern_request, "_new_shift_calendar_pattern_request");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");

            int number_of_resources;
            int.TryParse(_new_shift_calendar_pattern_request.number_of_resources, out number_of_resources);

            _new_shift_calendar_pattern = new ShiftCalendarPatterns.ShiftCalendarPattern
                                                                            {
                                                                                name = _new_shift_calendar_pattern_request.pattern_name,
                                                                                number_of_resources = number_of_resources,
                                                                                priority = 1
                                                                            };

            var index_entry_mapper = new ListEntryIndexMapper<ShiftCalendarPatterns.ShiftCalendarPattern>
                                            (a => a.priority
                                            , (a, value) => a.priority = value);

            _shift_calendar
                    .ShiftCalendarPatterns
                    .Select(index_entry_mapper.map)
                    .Insert(index_entry_mapper.map(_new_shift_calendar_pattern),
                                                    () => _shift_calendar.ShiftCalendarPatterns
                                                                            .Add(_new_shift_calendar_pattern));

            return this;
        }

        private NewShiftCalendarPattern commit()
        {
            if (response_builder_has_errors()) return this;

            _unit_of_work.Commit();

            return this;
        }

        private NewShiftCalendarPattern publish_shift_calender_pattern_created_event()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_operational_calendar, "_operational_calendar");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_new_shift_calendar_pattern, "_new_shift_calendar_pattern");

            _shift_calendar_pattern_created_event_publisher.publish(new ShiftCalendarPatternCreatedEvent
                                                                            {
                                                                                operations_calendar_id = _operational_calendar.id,
                                                                                shift_calendar_id = _shift_calendar.id,
                                                                                shift_calendar_pattern_id = _new_shift_calendar_pattern.id,
                                                                                name = _new_shift_calendar_pattern.name,
                                                                                number_of_resources = _new_shift_calendar_pattern.number_of_resources,
                                                                                priority = _new_shift_calendar_pattern.priority
                                                                            });

            return this;
        }

        private NewShiftCalendarPattern publish_shift_calendar_pattern_auto_reordered_events()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_operational_calendar, "_operational_calendar");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_new_shift_calendar_pattern, "_new_shift_calendar_pattern");
            Guard.IsNotNull(_shift_calendar.ShiftCalendarPatterns, "_shift_calendar.ShiftCalendarPatterns");
            Guard.IsNotNull(event_publisher_auto_reordered, "event_publisher_auto_reordered");

            foreach (ShiftCalendarPatterns.ShiftCalendarPattern pattern in _shift_calendar.ShiftCalendarPatterns)
            {
                if (pattern.id == _new_shift_calendar_pattern.id) continue; // there is no need to trigger an auto reorder event for the new shift calendar pattern created.

                event_publisher_auto_reordered.publish(new ShiftCalendarPatternAutoReorderedEvent
                {
                    operations_calendar_id = _operational_calendar.id,
                    shift_calendar_id = _shift_calendar.id,
                    shift_calendar_pattern_id = pattern.id,
                    name = pattern.name,
                    number_of_resources = pattern.number_of_resources,
                    priority = pattern.priority
                });
            }

            return this;
        }

        private NewShiftCalendarPatternResponse build_response()
        {
            if (response_builder_has_errors())
            {
                _response_builder.add_errors(new List<string> { WarningMessages.warning_03_0021 });
            }
            else
            {
                _response_builder.add_message(ConfirmationMessages.confirmation_04_0026);

                _response_builder
                    .set_response(new ShiftCalendarPatternIdentity
                                        {
                                            shift_calendar_pattern_id = _new_shift_calendar_pattern.id
                                        }
                                 );
            }

            return _response_builder.build();
        }

        private bool response_builder_has_errors()
        {
            return _response_builder.has_errors;
        }

        private bool has_execution_permission_not_granted()
        {
            return _execute_permission.IsGrantedFor(_new_shift_calendar_pattern_request) == false;
        }

        private bool has_validation_errors()
        {
            ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern = _shift_calendar
                                                                                    .ShiftCalendarPatterns
                                                                                    .SingleOrDefault(scp => scp.name.Equals(_new_shift_calendar_pattern_request.pattern_name,
                                                                                                                                StringComparison.InvariantCultureIgnoreCase
                                                                                                                            )
                                                                                                    );

            bool has_a_duplicate_shift_calendar_pattern_exist_with_this_name = shift_calendar_pattern != null;

            _validator
                .field("number_of_resources")
                .is_madatory(_new_shift_calendar_pattern_request.number_of_resources, ValidationMessages.error_00_0059)
                .does_not_contain_non_numeric_characters(_new_shift_calendar_pattern_request.number_of_resources, ValidationMessages.error_00_0061)
                ;

            if (_validator.errors.Any() == false)
            {
                _validator
                    .field("number_of_resources")
                    .does_not_contain_less_than_one_for_a_number_field(_new_shift_calendar_pattern_request.number_of_resources, ValidationMessages.error_00_0060)
                    ;
            }

            _validator
                .field("pattern_name")
                     .is_madatory(_new_shift_calendar_pattern_request.pattern_name, ValidationMessages.error_00_0042)
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(_new_shift_calendar_pattern_request.pattern_name, ValidationMessages.error_00_0037)
                     .premise_holds(!has_a_duplicate_shift_calendar_pattern_exist_with_this_name, ValidationMessages.error_00_0043)
                    ;

            _validation_errors = _validator.errors;

            return _validation_errors.Any();
        }

        public NewShiftCalendarPattern(IEntityRepository<OperationalCalendar> the_operational_calendar_repository,
                                        IUnitOfWork the_unit_of_work,
                                        Validator the_validator,
                                        ICanAddNewShiftCalendarPattern the_execute_permission,
                                        IEventPublisher<ShiftCalendarPatternCreatedEvent> the_shift_calendar_pattern_created_event_publisher,
                                        IEventPublisher<ShiftCalendarPatternAutoReorderedEvent> the_event_publisher_auto_reordered
                                      )
        {
            _operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository,
                                                                "the_operational_calendar_repository"
                                                              );
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            _validator = Guard.IsNotNull(the_validator, "the_validator");
            _execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            _shift_calendar_pattern_created_event_publisher = Guard.IsNotNull(the_shift_calendar_pattern_created_event_publisher,
                                                                              "the_shift_calendar_pattern_created_event_publisher"
                                                                             );
            event_publisher_auto_reordered = Guard.IsNotNull(the_event_publisher_auto_reordered,
                                                             "the_event_publisher_auto_reordered"
                                                            );
        }

        private readonly IEntityRepository<OperationalCalendar>
            _operational_calendar_repository;

        private readonly IUnitOfWork _unit_of_work;
        private readonly Validator _validator;
        private readonly IEventPublisher<ShiftCalendarPatternCreatedEvent> _shift_calendar_pattern_created_event_publisher;
        private readonly IEventPublisher<ShiftCalendarPatternAutoReorderedEvent> event_publisher_auto_reordered;

        private readonly ICanAddNewShiftCalendarPattern _execute_permission;

        private NewShiftCalendarPatternRequest _new_shift_calendar_pattern_request;
        private OperationalCalendar _operational_calendar;
        private ShiftCalendars.ShiftCalendar _shift_calendar;
        private ShiftCalendarPatterns.ShiftCalendarPattern _new_shift_calendar_pattern;
        private IEnumerable<ResponseMessage> _validation_errors;

        private ResponseBuilder<ShiftCalendarPatternIdentity, NewShiftCalendarPatternResponse> _response_builder;
    }
}