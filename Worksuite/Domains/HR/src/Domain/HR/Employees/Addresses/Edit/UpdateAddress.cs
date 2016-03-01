using Content.Services.HR.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.Address;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.IsUnique;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Edit
{
    public class UpdateAddress
                    : IUpdateAddress
    {
        public UpdateAddressResponse execute
                                        (UpdateAddressRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .authorize()
                    .find_employee()
                    .find_address()
                    .sanatise_request()
                    .validate_request()
                    .update_address()
                    .commit()
                    .publish_address_details_updated_event()
                    .build_response()
                    ;
        }

        public UpdateAddress
                (IUnitOfWork the_unit_of_work
                , IEntityRepository<Employee> the_repository
                , PostalAddressSanitiser the_sanitiser
                , EmployeeAddressValidator the_validator
                , EmployeeAddressIsUniqueValidator the_is_unique_validator
                , ICanUpdateAddress the_execute_permission
                , IEventPublisher<EmployeeAddressDetailsUpdatedEvent> the_event_publisher
                )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
            sanitiser = Guard.IsNotNull(the_sanitiser, "the_sanitiser");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            is_unique_validator = Guard.IsNotNull(the_is_unique_validator, "the_is_unique_validator");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private UpdateAddress set_request
                                (UpdateAddressRequest the_request)
        {
            Guard.IsNotNull(the_request, "the_request");

            request = the_request;
            // to do: remove the result from the update address it is not needed as you already know the identity.
            response_builder.set_response(
                new AddressIdentity
                {
                    employee_id = the_request.employee_id,
                    address_id = the_request.address_id,
                }
            );
            return this;
        }

        private UpdateAddress authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                // to do: the message will need to change once the it has been entered into the style guide.
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        public UpdateAddress find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            // Until we get internal error handling sorted out
            // just throw an exception. Really this is a
            // client error or a resource not found error
            // which the client can decide what to do with

            // After talking with Tim as this is a root missing this
            // should be a 404 error or something similar
            employee = repository
                        .Entities
                        .Single(e => e.id == request.employee_id);
            return this;
        }

        public UpdateAddress find_address()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Address, "employee.Address");

            // After talking with Tim we decided that these are not
            // 404 errors because the root that the entity belongs to
            // still exists. So we treat this as a standard error
            address = employee
                        .Address
                        .SingleOrDefault(a => a.id == request.address_id);

            if (address == null)
            {
                response_builder.add_error("TODO: address-not-found  Error message is yet to be defined");
            }
            return this;
        }

        private UpdateAddress sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            sanitiser.sanitise(request);
            return this;
        }

        private UpdateAddress validate_request()
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
                                                (UpdateAddressRequest update_request
                                                , IEnumerable<Address> addresses)
        {
            Guard.IsNotNull(address, "address");
            Guard.IsNotNull(addresses, "addresses");

            return is_unique_validator.validate(new PostalAddressIsUniqueRequest
            {
                address = update_request,
                addresses = addresses.Where(a => a.id != update_request.address_id),
            });
        }

        public UpdateAddress update_address()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(address, "address");

            address.number_or_name = request.number_or_name;
            address.line_one = request.line_one;
            address.line_two = request.line_two;
            address.line_three = request.line_three;
            address.county = request.county;
            address.country = request.country;
            address.postcode = request.postcode;

            return this;
        }

        private UpdateAddress commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private UpdateAddress publish_address_details_updated_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(address, "address");

            event_publisher.publish(new EmployeeAddressDetailsUpdatedEvent
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

        private UpdateAddressResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
                return response_builder.build();
            }

            response_builder.add_message(ValidationMessages.update_was_successfull);
            return response_builder.build();
        }

        private readonly ResponseBuilder<AddressIdentity, UpdateAddressResponse> response_builder = new ResponseBuilder<AddressIdentity, UpdateAddressResponse>();
        private readonly ICanUpdateAddress execute_permission;
        private readonly IEntityRepository<Employee> repository;
        private readonly PostalAddressSanitiser sanitiser;
        private readonly EmployeeAddressValidator validator;
        private readonly EmployeeAddressIsUniqueValidator is_unique_validator;
        private readonly IUnitOfWork unit_of_work;

        private UpdateAddressRequest request;
        private Employee employee;
        private Address address;
        private readonly IEventPublisher<EmployeeAddressDetailsUpdatedEvent> event_publisher;
    }
}