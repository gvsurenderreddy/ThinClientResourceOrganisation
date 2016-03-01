using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.addEmployee.post
{
    public class AddEmployeeRequestHandler : IAddEmployeeRequestHandler
    {
        public AddEmployeeResponse execute(AddEmployeeRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .sanitise_request()
                    .validate_request()
                    .create_employee()
                    .add_employee()
                    .commit()
                    .publish_employee_created_event()
                    .set_response()
                    .build_response();
        }

        private AddEmployeeRequestHandler set_request(AddEmployeeRequest the_request)
        {
            if (response_builder.has_errors) return this;

            request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private AddEmployeeRequestHandler sanitise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request.employee_reference = request.employee_reference.normalise_for_persistence();
            request.forename = request.forename.normalise_for_persistence();
            request.surname = request.surname.normalise_for_persistence();

            return this;
        }

        private AddEmployeeRequestHandler validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");


            response_builder.add_statuses(
                add_employee_request_validator.execute(request)
            );

            return this;
        }

        private AddEmployeeRequestHandler create_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = new Employee()
            {
                employeeReference = request.employee_reference,
                forename = request.forename,
                surname = request.surname,
                image_id = Null.Id
            };

            return this;
        }

        private AddEmployeeRequestHandler add_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            employee_repository.add(employee);

            return this;
        }

        private AddEmployeeRequestHandler commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private AddEmployeeRequestHandler publish_employee_created_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            employee_event_publisher.publish(new EmployeeCreatedEvent
            {
                employee_id = employee.id,
                employee_reference = employee.employeeReference,
                forename = employee.forename,
                surname = employee.surname,
            });
            return this;
        }

        private AddEmployeeRequestHandler set_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.set_response(new EmployeeIdentity() { employee_id = Null.Id });
            }
            else
            {
                Guard.IsNotNull(employee, "employee");
                response_builder.set_response(new EmployeeIdentity() { employee_id = employee.id });
            }

            return this;
        }

        private AddEmployeeResponse build_response()
        {
            return response_builder.build();
        }

        public AddEmployeeRequestHandler(
                                            IEntityRepository<Employee> the_employee_repository,
                                            IUnitOfWork the_unit_of_work,
                                            AddEmployeeRequestValidator the_add_employee_request_validator,
                                            ServiceStatusResponseBuilder<EmployeeIdentity, AddEmployeeResponse> the_response_builder,
                                            IEventPublisher<EmployeeCreatedEvent> the_employee_event_publisher
                                        )
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            add_employee_request_validator = Guard.IsNotNull(the_add_employee_request_validator, "the_add_employee_request_validator");
            response_builder = Guard.IsNotNull(the_response_builder, "the_response_builder");
            employee_event_publisher = Guard.IsNotNull(the_employee_event_publisher, "the_employee_event_publisher");
        }

        private readonly IEntityRepository<Employee> employee_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly AddEmployeeRequestValidator add_employee_request_validator;
        private readonly ServiceStatusResponseBuilder<EmployeeIdentity, AddEmployeeResponse> response_builder;
        private readonly IEventPublisher<EmployeeCreatedEvent> employee_event_publisher;

        private AddEmployeeRequest request;
        private Employee employee;

        

    }
}
