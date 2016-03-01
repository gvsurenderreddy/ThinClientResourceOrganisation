using Content.Services.HR.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.Address;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.IsUnique;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.New
{
    public class NewAddress
                    : INewAddress
    {
        public NewAddressResponse execute
                                    (NewAddressRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .authorize()
                    .find_employee()
                    .sanatise_request()
                    .validate_request()
                    .create_address()
                    .commit()
                    .publish_address_details_created_event()
                    .publish_address_auto_reordered_events()
                    .build_response()
                    ;
        }

        public NewAddress
                    (IEntityRepository<Employee> the_repository
                    , IUnitOfWork the_unit_of_work
                    , ICanAddNewAddress the_execute_permission
                    , PostalAddressSanitiser the_sanitiser
                    , EmployeeAddressValidator the_validator
                    , EmployeeAddressIsUniqueValidator the_is_unique_validator
                    , IEventPublisher<EmployeeAddressDetailsCreatedEvent> the_event_publisher_address_created
                    , IEventPublisher<EmployeeAddressAutoReorderedEvent> the_event_publisher_address_auto_reordered
                    )
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            sanitiser = Guard.IsNotNull(the_sanitiser, "the_sanitiser");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            is_unique_validator = Guard.IsNotNull(the_is_unique_validator, "the_is_unique_validator ");
            event_publisher_address_created = Guard.IsNotNull(the_event_publisher_address_created, "the_event_publisher_address_created");
            event_publisher_address_auto_reordered = Guard.IsNotNull(the_event_publisher_address_auto_reordered, "the_event_publisher_address_auto_reordered");
        }

        private NewAddress set_request
                                (NewAddressRequest the_request)
        {
            Guard.IsNotNull(the_request, "the_request");

            request = the_request;

            response_builder.set_response(new AddressIdentity
            {
                employee_id = request.employee_id,
                address_id = Null.Id,
            });
            return this;
        }

        public NewAddress authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        public NewAddress find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            // Until we get internal error handling sorted out
            // just throw an exception. Really this is a
            // client error or a resource not found error
            // which the client can decide what to do with
            employee = repository
                        .Entities
                        .Single(e => e.id == request.employee_id);
            return this;
        }

        private NewAddress sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            sanitiser.sanitise(request);
            return this;
        }

        private NewAddress validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Addresses");

            response_builder.add_errors(validator.validate(request));
            response_builder.add_errors(validate_address_is_unique(request, employee.Address));
            return this;
        }

        private IEnumerable<ResponseMessage> validate_address_is_unique
                                                (NewAddressRequest address
                                                , IEnumerable<Address> addresses)
        {
            Guard.IsNotNull(address, "address");
            Guard.IsNotNull(addresses, "addresses");

            return is_unique_validator.validate(new PostalAddressIsUniqueRequest
            {
                address = address,
                addresses = addresses,
            });
        }

        private NewAddress create_address()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Addresses");

            // create the address, new addresses are always set as the primary address
            new_address = new Address
            {
                number_or_name = request.number_or_name,
                line_one = request.line_one,
                line_two = request.line_two,
                line_three = request.line_three,
                county = request.county,
                country = request.country,
                postcode = request.postcode,
                priority = 1,
            };

            // Add the address to the employee.
            //
            // We have a set of index maintenance library routines which ensure that when we insert, remove, or move elements
            // within a list the index is maintained correctly.  As the index maintenance routines all work against an IListIndexEntry
            // collection we have to create a mapper that can map an Address to an IListEntryIndex.
            //
            // (Note - the objects that the mapper creates are really generic mediators)
            var index_entry_mapper = new ListEntryIndexMapper<Address>
                                            (a => a.priority
                                            , (a, value) => a.priority = value);

            employee
                .Address
                .Select(index_entry_mapper.map)
                .Insert(index_entry_mapper.map(new_address)
                       , () => employee.Address.Add(new_address))
                ;
            return this;
        }

        private NewAddress commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private NewAddress publish_address_details_created_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(new_address, "new_address");

            event_publisher_address_created.publish(new EmployeeAddressDetailsCreatedEvent
                                        {
                                            employee_id = employee.id,
                                            address_id = new_address.id,
                                            number_or_name = new_address.number_or_name,
                                            line_one = new_address.line_one,
                                            line_two = new_address.line_two,
                                            line_three = new_address.line_three,
                                            county = new_address.county,
                                            country = new_address.country,
                                            postcode = new_address.postcode,
                                            priority = new_address.priority
                                        });

            return this;
        }

        private NewAddress publish_address_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Addresses");
            Guard.IsNotNull(new_address, "new_address");

            foreach (Address address in employee.Address)
            {
                if (address.id == new_address.id) continue; // there is no need to trigger an auto reorder event for the new address created.

                event_publisher_address_auto_reordered.publish(new EmployeeAddressAutoReorderedEvent
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
                                                                }
                                                         );
            }

            return this;
        }

        private NewAddressResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
                return response_builder.build();
            }

            response_builder.add_message(ValidationMessages.update_was_successfull);

            response_builder.set_response(new AddressIdentity
            {
                employee_id = employee.id,
                address_id = new_address.id,
            });
            return response_builder.build();
        }

        private readonly ResponseBuilder<AddressIdentity, NewAddressResponse> response_builder = new ResponseBuilder<AddressIdentity, NewAddressResponse>();
        private readonly ICanAddNewAddress execute_permission;
        private readonly IEntityRepository<Employee> repository;
        private readonly PostalAddressSanitiser sanitiser;
        private readonly EmployeeAddressValidator validator;
        private readonly EmployeeAddressIsUniqueValidator is_unique_validator;
        private readonly IUnitOfWork unit_of_work;

        private NewAddressRequest request;
        private Employee employee;
        private Address new_address;
        private readonly IEventPublisher<EmployeeAddressDetailsCreatedEvent> event_publisher_address_created;
        private readonly IEventPublisher<EmployeeAddressAutoReorderedEvent> event_publisher_address_auto_reordered;
    }
}