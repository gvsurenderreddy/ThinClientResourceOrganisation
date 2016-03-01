using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.HR.Query.EmployeeViews;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.LocationUpdated
{
    public class LocationUpdatedFixture
    {
        public LocationUpdatedEvent simulate_event()
        {
            var the_id = ++new_event_id;

            //We need to create a fake employee
            var fake_employee_view = new Query.EmployeeView()
            {
                employee_id = the_id,
                employee_reference = "ref" + the_id,
                forename = "name" + the_id,
                surname = "surname" + the_id,
                job_title = "job" + the_id,
                job_title_id = the_id,
                location = "location" + the_id,
                location_id = the_id,
                id = the_id
            };

            //then seed the fake employee view into the repository
            employee_view_repository.add(fake_employee_view);

            //then return a fake event, derived from the fake employee
            return new LocationUpdatedEvent
            {
                id = fake_employee_view.job_title_id,
                description = fake_employee_view.location + "updated"
            };
        }

        public IEnumerable<Query.EmployeeView> all_employee_views { get { return employee_view_repository.Entities; } }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public LocationUpdatedFixture()
        {
            employee_view_repository = DependencyResolver.resolve<IEntityRepository<Query.EmployeeView>>();
            event_handler = DependencyResolver.resolve<UpdateEmployeeViewsWhenLocationUpdated>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly IEntityRepository<Query.EmployeeView> employee_view_repository;
        private readonly FakeUnitOfWork unit_of_work;
        public IEventSubscriber<LocationUpdatedEvent> event_handler { get; private set; }

        private int new_event_id = 0;

    }
}
