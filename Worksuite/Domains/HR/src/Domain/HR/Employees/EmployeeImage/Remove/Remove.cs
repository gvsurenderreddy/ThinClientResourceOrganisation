using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Remove
{
    public class Remove : IRemove
    {
        public Remove(IUnitOfWork theUnitOfWork
                      , IEntityRepository<Employee> theEmployeeRpository
                      , Validator theValidator
                      , IEventPublisher<EmployeeImageDetailsRemovedEvent> the_event_publisher
                     )
        {
            unit_of_work = Guard.IsNotNull(theUnitOfWork, "theUnitOfWork");
            employee_repository = Guard.IsNotNull(theEmployeeRpository, "theEmployeeRpository");
            validator = Guard.IsNotNull(theValidator, "theValidator");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        public RemoveResponse execute(EmployeeIdentity the_request)
        {
            return set_request(the_request)
                .find_employee()
                .validate_request()
                .remove_employee_image()
                .commit()
                .publish_image_details_removed_event()
                .build_response();
        }

        private Remove set_request(EmployeeIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new EmployeeIdentity { employee_id = request.employee_id });

            return this;
        }

        private Remove find_employee()
        {
            if (response_builder.has_errors) return this;

            employee = employee_repository
                            .Entities
                            .Single(e => e.id == request.employee_id)
                            ;
            return this;
        }

        private Remove validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            response_builder.add_errors(validator.errors);

            return this;
        }

        private Remove remove_employee_image()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(request, "request");

            employee.image_id = Null.Id;

            return this;
        }

        private Remove commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private Remove publish_image_details_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            event_publisher.publish(new EmployeeImageDetailsRemovedEvent { employee_id = employee.id });

            return this;
        }

        private RemoveResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            else
            {
                response_builder.add_message(ValidationMessages.confirmation_04_0011);

                response_builder.set_response(new EmployeeIdentity { employee_id = request.employee_id });
            }

            return response_builder.build();
        }

        private EmployeeIdentity request;
        private Employee employee;

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> employee_repository;
        private readonly Validator validator;
        private readonly IEventPublisher<EmployeeImageDetailsRemovedEvent> event_publisher;
        private readonly ResponseBuilder<EmployeeIdentity, RemoveResponse> response_builder = new ResponseBuilder<EmployeeIdentity, RemoveResponse>();
    }
}