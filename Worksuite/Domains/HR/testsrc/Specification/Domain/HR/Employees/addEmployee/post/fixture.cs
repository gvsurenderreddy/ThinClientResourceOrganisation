using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.addEmployee;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post
{
    public class AddEmployeeRequestHandler_fixture
    {
        public void seed_an_employee_with_this_employee_reference(string employee_ref)
        {
            employee_repository.add(new Employee()
            {
                id = -9999,
                employeeReference = employee_ref,
                forename = "seeded_forename",
                surname = "seeded_surname"
            });
        }
        
        public void execute_command()
        {
            response = request_handler.execute(request);
        }

        public Maybe<EmployeeCreatedEvent> get_employee_created_event_for(Employee employee)
        {

            var created_event = this
                                    .events_publisher
                                    .published_events
                                    .SingleOrDefault(e => e.employee_id == entity.id)
                                    ;

            return created_event != null
                        ? new Just<EmployeeCreatedEvent>(created_event) as Maybe<EmployeeCreatedEvent>
                        : new Nothing<EmployeeCreatedEvent>()
                        ;

        }

        public Employee entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                return employee_repository
                        .Entities
                        .Single(e => e.id == response.result.employee_id)
                        ;
            }
        }

        public FakeEventPublisher<EmployeeCreatedEvent> events_publisher { get; private set; }

        public bool changes_were_committed
        {
            get { return unit_of_work.commit_was_called; }
        }

        public AddEmployeeRequest request { get; set; }

        public AddEmployeeResponse response { get; set; }

        public AddEmployeeRequestHandler_fixture(AddEmployee_request_helper the_request_helper
                                                , IAddEmployeeRequestHandler the_request_handler
                                                , FakeUnitOfWork the_unit_of_work
                                                , IEntityRepository<Employee> the_employee_repository
                                                , FakeEventPublisher<EmployeeCreatedEvent> the_events_publisher)
        {
            request = Guard.IsNotNull(the_request_helper.given_a_valid_request(), "the_request_helper.given_a_valid_request()");
            request_handler = Guard.IsNotNull(the_request_handler, "the_request_handler");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            events_publisher = Guard.IsNotNull(the_events_publisher, "the_events_publisher");
        }

        private readonly IAddEmployeeRequestHandler request_handler;
        private readonly FakeUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> employee_repository;
    }
}
