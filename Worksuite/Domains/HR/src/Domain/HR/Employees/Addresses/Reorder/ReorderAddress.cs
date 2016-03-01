using Content.Services.Common.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder
{
    public class ReorderAddress
                    : IReorderAddress
    {
        public ReorderAddressResponse execute
                                (ReorderAddressRequest request)
        {
            return this
                    .set_request(request)
                    .authorize()
                    .find_employee()
                    .find_address()
                    .get_a_copy_of_all_addresses()
                    .create_move_request()
                    .validate()
                    .move_address()
                    .commit()
                    .publish_address_manual_reordered_event()
                    .publish_address_auto_reordered_events()
                    .build_response();
        }

        public ReorderAddress
                (IUnitOfWork the_unit_of_work
                , IEntityRepository<Employee> the_repository
                , Validator the_validator
                , ICanReorderAddress the_execute_permission
                , IEventPublisher<EmployeeAddressManualReorderedEvent> the_event_publisher_address_manual_reordered
                , IEventPublisher<EmployeeAddressAutoReorderedEvent> the_event_publisher_address_auto_reordered
                )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            event_publisher_address_manual_reordered = Guard.IsNotNull(the_event_publisher_address_manual_reordered, "the_event_publisher_address_manual_reordered");
            event_publisher_address_auto_reordered = Guard.IsNotNull(the_event_publisher_address_auto_reordered, "the_event_publisher_address_auto_reordered");
        }

        private ReorderAddress set_request
                            (ReorderAddressRequest request)
        {
            reorder_request = Guard.IsNotNull(request, "reorder_request");
            return this;
        }

        public ReorderAddress authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(reorder_request, "reorder_request");

            if (!execute_permission.IsGrantedFor(reorder_request))
            {
                response_builder.add_error(ValidationMessages.default_reorder_permission_not_granted);
            }
            return this;
        }

        private ReorderAddress find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(reorder_request, "reorder_request");

            // NOTE - this is duplicate code really we should
            //        have something that gets the employee for
            //        an identity.

            // Until we get internal error handling sorted out
            // just throw an exception. Really this is a
            // client error or a resource not found error
            // which the client can decide what to do with
            employee = repository
                        .Entities
                        .Single(e => e.id == reorder_request.employee_id);
            return this;
        }

        private ReorderAddress find_address()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)

            Guard.IsNotNull(reorder_request, "reorder_request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");

            // NOTE - this is duplicate code really we should
            //        have something that gets the employee for
            //        an identity.

            // Until we get internal error handling sorted out
            // just throw an exception. Really this is a
            // client error or a resource not found error
            // which the client can decide what to do with
            address = employee
                        .Address
                        .Single(a => a.id == reorder_request.address_id);
            return this;
        }

        private ReorderAddress get_a_copy_of_all_addresses()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");

            cached_addresses = new AddressPriority[employee.Address.Count];
            int count = 0;
            foreach (Address otherAddress in employee.Address)
            {
                cached_addresses[count] = new AddressPriority { address_id = otherAddress.id, priority = otherAddress.priority };
                count++;
            }

            cached_addresses.OrderBy(a => a.priority);

            return this;
        }

        public ReorderAddress create_move_request()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)
            if (address == null) return this;  // To do: sort out internal error handling and 404 (e.g the address no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(reorder_request, "reorder_request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(address, "employee.Address");

            move_request = new MoveIndexEntryRequest
            {
                @from = address.priority,
                to = reorder_request.priority
            };
            return this;
        }

        private ReorderAddress validate()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)
            if (address == null) return this;  // To do: sort out internal error handling and 404 (e.g the address no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(move_request, "move_request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");

            validator
                .field("priority")
                .premise_holds(move_request.to >= 1, ValidationMessages.error_03_0007)
                .premise_holds(move_request.to <= employee.Address.Count(), ValidationMessages.error_03_0008)
                ;

            response_builder.add_errors(validator.errors);
            return this;
        }

        private ReorderAddress move_address()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)

            Guard.IsNotNull(move_request, "move_request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");

            var to_index_mapper = new ListEntryIndexMapper<Address>
                                        (m => m.priority
                                        , (m, value) => m.priority = value);

            employee
                .Address
                .Select(to_index_mapper.map)
                .Move(move_request);

            return this;
        }

        private ReorderAddress commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private ReorderAddress publish_address_manual_reordered_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(address, "address");
            Guard.IsNotNull(event_publisher_address_manual_reordered, "event_publisher_address_manual_reordered");

            event_publisher_address_manual_reordered.publish(new EmployeeAddressManualReorderedEvent
                                        {
                                            employee_id = employee.id,
                                            address_id = address.id,
                                            number_or_name = address.number_or_name,
                                            line_one = address.line_one,
                                            line_two = address.line_two,
                                            line_three = address.line_three,
                                            county = address.county,
                                            country = address.country,
                                            postcode = address.postcode,
                                            priority = address.priority
                                        });

            return this;
        }

        private ReorderAddress publish_address_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");
            Guard.IsNotNull(address, "address");
            Guard.IsNotNull(cached_addresses, "cached_addresses");
            Guard.IsNotNull(event_publisher_address_auto_reordered, "event_publisher_address_auto_reordered");

            foreach (AddressPriority otherAddress in cached_addresses)
            {
                if (move_request.from == move_request.to) break; // re-ordered to the same position, therefore no need to raise any auto reordered events.

                if (otherAddress.address_id == address.id) continue; // a manual reordered event has been raised already for the address re-ordered.

                var the_address = employee.Address.Single(a => a.id == otherAddress.address_id); // Get the updated copy of the address.

                if (otherAddress.priority == the_address.priority) continue; // if there is no priority change made for the address, there is no need to trigger an auto reordered event.

                event_publisher_address_auto_reordered.publish(new EmployeeAddressAutoReorderedEvent
                {
                    employee_id = employee.id,
                    address_id = the_address.id,
                    number_or_name = the_address.number_or_name,
                    line_one = the_address.line_one,
                    line_two = the_address.line_two,
                    line_three = the_address.line_three,
                    county = the_address.county,
                    country = the_address.country,
                    postcode = the_address.postcode,
                    priority = the_address.priority
                }
                                                         );
            }

            return this;
        }

        private ReorderAddressResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                Guard.IsNotNull(move_request, "move_request");

                response_builder.add_message(
                    ValidationMessages.reorder_was_successfull(
                        move_request.from,
                        move_request.to
                ));
            }
            return response_builder.build();
        }

        private readonly ResponseBuilder<ReorderAddressResponse> response_builder = new ResponseBuilder<ReorderAddressResponse>();
        private readonly ICanReorderAddress execute_permission;
        private readonly IEntityRepository<Employee> repository;
        private readonly Validator validator;
        private readonly IUnitOfWork unit_of_work;

        private ReorderAddressRequest reorder_request;
        private Employee employee;
        private Address address;
        private AddressPriority[] cached_addresses;
        private MoveIndexEntryRequest move_request;
        private readonly IEventPublisher<EmployeeAddressManualReorderedEvent> event_publisher_address_manual_reordered;
        private readonly IEventPublisher<EmployeeAddressAutoReorderedEvent> event_publisher_address_auto_reordered;
    }

    public class AddressPriority
    {
        public int address_id { get; set; }

        public int priority { get; set; }
    }
}