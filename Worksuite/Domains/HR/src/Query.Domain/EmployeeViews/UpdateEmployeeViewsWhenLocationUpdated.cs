using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.EmployeeViews
{
    public class UpdateEmployeeViewsWhenLocationUpdated : IEventSubscriber<LocationUpdatedEvent>
    {
        public void handle(LocationUpdatedEvent the_location_updated_event)
        {

            this
                .set_event(the_location_updated_event)
                .find_employee_views()
                .update_employee_views()
                .commit()
                ;
        }

        public UpdateEmployeeViewsWhenLocationUpdated
                                                (IEntityRepository<EmployeeView> employee_view_repository
                                                , IUnitOfWork unit_of_work)
        {

            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }


        private UpdateEmployeeViewsWhenLocationUpdated set_event
                                                                (LocationUpdatedEvent the_location_updated_event)
        {


            location_updated_event = Guard.IsNotNull(the_location_updated_event, "the_location_updated_event");
            return this;
        }

        private UpdateEmployeeViewsWhenLocationUpdated find_employee_views()
        {

            Guard.IsNotNull(location_updated_event, "location_updated_event");

            employee_views = employee_view_repository
                             .Entities
                             .Where(e => e.location_id == location_updated_event.id)
                             ;

            return this;
        }

        private UpdateEmployeeViewsWhenLocationUpdated update_employee_views()
        {

            Guard.IsNotNull(employee_views, "employee_views");

            employee_views.Do(ev =>
            {
                ev.location = location_updated_event.description;
            });

            return this;
        }

        private void commit()
        {

            unit_of_work.Commit();
        }

        private LocationUpdatedEvent location_updated_event;
        private IEnumerable<EmployeeView> employee_views;

        private readonly IEntityRepository<EmployeeView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}
