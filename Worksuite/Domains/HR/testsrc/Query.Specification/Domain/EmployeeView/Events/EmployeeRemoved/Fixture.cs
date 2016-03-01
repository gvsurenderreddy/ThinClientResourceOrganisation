using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.HR.Query.EmployeeViews;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeRemoved
{
    public class EmployeeRemovedFixture
    {
        public EmployeeRemovedEvent simulate_event()
        {
            var the_id = ++new_event_id;

            //We need to implicitly seed an employee view into the repository
            //before returning the removed event for that same employee
            employee_view_repository.add(new Query.EmployeeView()
            {
                employee_id = the_id,
                employee_reference = "ref" + the_id,
                forename = "name" + the_id,
                surname = "surname" + the_id,
                id = the_id
            });

            return new EmployeeRemovedEvent
            {
                employee_id = the_id
            };
        }

        public IEnumerable<Query.EmployeeView> all_employee_views { get { return employee_view_repository.Entities; } }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public EmployeeRemovedFixture()
        {
            employee_view_repository = DependencyResolver.resolve<IEntityRepository<Query.EmployeeView>>();
            event_handler = DependencyResolver.resolve<RemoveEmployeeViewWhenEmployeeRemoved>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly IEntityRepository<Query.EmployeeView> employee_view_repository;
        private readonly FakeUnitOfWork unit_of_work;
        public IEventSubscriber<EmployeeRemovedEvent> event_handler { get; private set; }

        private int new_event_id = 0;

    }
}
