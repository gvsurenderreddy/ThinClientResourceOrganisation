using Content.Services.HR.Messages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.OrderList;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Remove
{
    public class RemoveAddress
                    : IRemoveAddress
    {
        public RemoveAddress
                (IUnitOfWork the_unit_of_work
                , IEntityRepository<Employee> the_employee_repository
                , IEventPublisher<EmployeeAddressRemovedEvent> the_event_publisher_address_removed
                , IEventPublisher<EmployeeAddressAutoReorderedEvent> the_event_publisher_address_auto_reordered
                )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher_address_removed = Guard.IsNotNull(the_event_publisher_address_removed, "the_event_publisher_address_removed");
            event_publisher_address_auto_reordered = Guard.IsNotNull(the_event_publisher_address_auto_reordered, "the_event_publisher_address_auto_reordered");
        }

        public RemoveAddressResponse execute
                                (AddressIdentity the_request)
        {
            return this
                    .set_request(the_request)
                    .find_employee()
                    .find_address()
                    .create_employee_address_removed_event()
                    .identify_the_priority_of_the_address_to_be_removed()
                    .remove_address()
                    .commit()
                    .publish_address_removed_event()
                    .publish_address_auto_reordered_events()
                    .build_response()
                    ;
        }

        private RemoveAddress set_request
                        (AddressIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private RemoveAddress find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            // NOTE - this is duplicate code really we should
            //        have something that gets the employee for
            //        an identity.

            // Until we get internal error handling sorted out
            // just throw an exception. Really this is a
            // client error or a resource not found error
            // which the client can decide what to do with
            employee = employee_repository
                        .Entities
                        .Single(e => e.id == request.employee_id);
            return this;
        }

        private RemoveAddress find_address()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)

            Guard.IsNotNull(request, "request");
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
                        .Single(a => a.id == request.address_id);
            return this;
        }

        private RemoveAddress create_employee_address_removed_event()
        {
            if (response_builder.has_errors) return this;
            if (address == null) return this;  // To do: sort out internal error handling and 404 (e.g the address no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(address, "address");

            employee_address_removed_event = new EmployeeAddressRemovedEvent
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
                                                    };

            return this;
        }

        private RemoveAddress identify_the_priority_of_the_address_to_be_removed()
        {
            if (response_builder.has_errors) return this;
            if (address == null) return this;  // To do: sort out internal error handling and 404 (e.g the address no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(address, "address");

            priority_of_the_address_to_be_removed = address.priority;

            return this;
        }

        private RemoveAddress remove_address()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)
            if (address == null) return this;  // To do: sort out internal error handling and 404 (e.g the address no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");

            var index_entry_mapper = new ListEntryIndexMapper<Address>
                                            (a => a.priority
                                            , (a, value) => a.priority = value);

            employee
                .Address
                .Select(index_entry_mapper.map)
                .Remove(index_entry_mapper.map(address)
                       , () =>
                       {
                           employee.Address.Remove(address);
                           employee_repository.remove(address);
                       });

            return this;
        }

        private RemoveAddress commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private RemoveAddress publish_address_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(address, "address");

            event_publisher_address_removed
                .publish(employee_address_removed_event)
                ;

            return this;
        }

        private RemoveAddress publish_address_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");
            Guard.IsNotNull(priority_of_the_address_to_be_removed, "priority_of_the_address_to_be_removed");

            foreach (Address otherAddress in employee.Address)
            {
                if (otherAddress.priority < priority_of_the_address_to_be_removed) continue; // there is no need to trigger an auto reorder event for the for addresses that are not affected.

                event_publisher_address_auto_reordered.publish(new EmployeeAddressAutoReorderedEvent
                {
                    employee_id = employee.id,
                    address_id = otherAddress.id,
                    number_or_name = otherAddress.number_or_name,
                    line_one = otherAddress.line_one,
                    line_two = otherAddress.line_two,
                    line_three = otherAddress.line_three,
                    county = otherAddress.county,
                    country = otherAddress.country,
                    postcode = otherAddress.postcode,
                    priority = otherAddress.priority
                }
                                                         );
            }

            return this;
        }

        private RemoveAddressResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.remove_was_successfull);
            }
            return response_builder.build();
        }

        private readonly ResponseBuilder<RemoveAddressResponse> response_builder = new ResponseBuilder<RemoveAddressResponse>();
        private readonly IEntityRepository<Employee> employee_repository;
        private readonly IUnitOfWork unit_of_work;

        private AddressIdentity request;
        private Employee employee;
        private Address address;
        private int priority_of_the_address_to_be_removed;
        private EmployeeAddressRemovedEvent employee_address_removed_event;
        private readonly IEventPublisher<EmployeeAddressRemovedEvent> event_publisher_address_removed;
        private readonly IEventPublisher<EmployeeAddressAutoReorderedEvent> event_publisher_address_auto_reordered;
    }
}