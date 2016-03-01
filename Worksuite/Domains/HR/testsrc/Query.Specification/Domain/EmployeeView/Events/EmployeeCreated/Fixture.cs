using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.HR.Query.EmployeeViews;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeCreated
{
    public class EmployeeCreatedFixture
    {
        public EmployeeCreatedEvent simulate_event()
        {
            var next_id = ++new_event_id;

            return new EmployeeCreatedEvent
            {
                employee_id = next_id,
                employee_reference = "EB" + next_id,
                forename = "A forename" + next_id,
                surname = "A surname" + next_id
            };
        }

        public IEnumerable<Query.EmployeeView> all_employee_views { get { return employee_view_repository.Entities; } }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public EmployeeCreatedFixture()
        {
            employee_view_repository = DependencyResolver.resolve<IEntityRepository<Query.EmployeeView>>();
            event_handler = DependencyResolver.resolve<CreateEmployeeViewWhenEmployeeCreated>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly IEntityRepository<Query.EmployeeView> employee_view_repository;
        private readonly FakeUnitOfWork unit_of_work;
        public CreateEmployeeViewWhenEmployeeCreated event_handler { get; private set; }

        private int new_event_id = 0;

    }
}
