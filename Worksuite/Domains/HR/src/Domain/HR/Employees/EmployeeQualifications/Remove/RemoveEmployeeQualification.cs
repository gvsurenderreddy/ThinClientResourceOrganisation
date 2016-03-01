using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Remove
{
    public class RemoveEmployeeQualification
                        : IRemoveEmployeeQualification
    {
        public RemoveEmployeeQualificationResponse execute(EmployeeQualificationIdentity the_request_to_unassign_a_qualification_from_an_employee)
        {
            return this
                .set_the_request(the_request_to_unassign_a_qualification_from_an_employee)
                .find_the_employee()
                .find_the_employee_qualification()
                .create_employee_qualification_removed_event()
                .remove_the_qualification_from_the_employee()
                .commit()
                .publish_qualification_removed_event()
                .build_response()
                ;
        }

        private RemoveEmployeeQualification set_the_request(EmployeeQualificationIdentity the_request_to_unassign_a_qualification_from_an_employee)
        {
            _request_to_unassign_a_qualification_from_an_employee =
                Guard.IsNotNull(the_request_to_unassign_a_qualification_from_an_employee,
                    "the_request_to_unassign_a_qualification_from_an_employee");

            _remove_employee_qualification_response_builder
                .set_response(new EmployeeQualificationIdentity
                {
                    employee_id = Null.Id,
                    employee_qualification_id = Null.Id
                });

            return this;
        }

        private RemoveEmployeeQualification find_the_employee()
        {
            if (_remove_employee_qualification_response_builder.has_errors) return this;

            _employee = _employee_repository
                            .Entities
                            .Single(e => e.id == _request_to_unassign_a_qualification_from_an_employee.employee_id)
                            ;

            return this;
        }

        private RemoveEmployeeQualification find_the_employee_qualification()
        {
            if (_remove_employee_qualification_response_builder.has_errors) return this;

            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_employee.EmployeeQualifications, "_employee.EmployeeQualifications");

            _employee_qualification = _employee
                                            .EmployeeQualifications
                                            .Single(q => q.id == _request_to_unassign_a_qualification_from_an_employee.employee_qualification_id)
                                            ;

            return this;
        }

        private RemoveEmployeeQualification create_employee_qualification_removed_event()
        {
            if (_remove_employee_qualification_response_builder.has_errors) return this;

            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_employee_qualification, "_employee_qualification");
            Guard.IsNotNull(_employee_qualification.qualification, "_employee_qualification.qualification");

            _employee_qualification_removed_event = new EmployeeQualificationRemovedEvent
                                                            {
                                                                employee_id = _employee.id,
                                                                employee_qualification_id = _employee_qualification.qualification.id,
                                                                employee_qualification_description = _employee_qualification.qualification.description
                                                            };

            return this;
        }

        private RemoveEmployeeQualification remove_the_qualification_from_the_employee()
        {
            if (_remove_employee_qualification_response_builder.has_errors) return this;

            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_employee_qualification, "_employee_qualification");

            _employee
                .EmployeeQualifications
                .Remove(_employee_qualification)
                ;

            _employee_repository.remove(_employee_qualification);

            return this;
        }

        private RemoveEmployeeQualification commit()
        {
            if (_remove_employee_qualification_response_builder.has_errors) return this;

            _unit_of_work.Commit();

            return this;
        }

        private RemoveEmployeeQualification publish_qualification_removed_event()
        {
            if (_remove_employee_qualification_response_builder.has_errors) return this;

            Guard.IsNotNull(_employee_qualification_removed_event, "_employee_qualification_removed_event");

            _event_publisher_qualification_removed.publish(_employee_qualification_removed_event);

            return this;
        }

        private RemoveEmployeeQualificationResponse build_response()
        {
            if (!_remove_employee_qualification_response_builder.has_errors)
            {
                _remove_employee_qualification_response_builder
                        .add_message(ConfirmationMessages.confirmation_04_0014);
            }

            return _remove_employee_qualification_response_builder.build();
        }

        public RemoveEmployeeQualification(IEntityRepository<Employee> the_employee_repository,
                                           IUnitOfWork the_unit_of_work,
                                           IEventPublisher<EmployeeQualificationRemovedEvent> the_event_publisher_qualification_removed
                                          )
        {
            _employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            _event_publisher_qualification_removed = Guard.IsNotNull(the_event_publisher_qualification_removed,
                                                                    "the_event_publisher_qualification_removed"
                                                                   );
        }

        private readonly IEntityRepository<Employee> _employee_repository;
        private readonly IUnitOfWork _unit_of_work;
        private readonly IEventPublisher<EmployeeQualificationRemovedEvent> _event_publisher_qualification_removed;

        private readonly ResponseBuilder<EmployeeQualificationIdentity, RemoveEmployeeQualificationResponse> _remove_employee_qualification_response_builder =
                                    new ResponseBuilder<EmployeeQualificationIdentity, RemoveEmployeeQualificationResponse>();

        private EmployeeQualificationIdentity _request_to_unassign_a_qualification_from_an_employee;
        private Employee _employee;
        private EmployeeQualification _employee_qualification;
        private EmployeeQualificationRemovedEvent _employee_qualification_removed_event;
    }
}