using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers
{
    public class UpdateAllocatableResourcesTableItemWhenLocationUpdated : IEventSubscriber<LocationUpdatedEvent>
    {
        public void handle(LocationUpdatedEvent the_event_to_handle)
        {
                 set_event(the_event_to_handle)
                .find_employee_views()
                .update_employee_views()
                .commit()
                ;
        }

        private UpdateAllocatableResourcesTableItemWhenLocationUpdated set_event(LocationUpdatedEvent the_event_to_handle)
        {
            location_updated_event = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            return this;
        }

        private UpdateAllocatableResourcesTableItemWhenLocationUpdated find_employee_views()
        {
            Guard.IsNotNull(location_updated_event, "location_updated_event");

            employee_views=employee_view_repository .Entities
                             .Where(e => e.location_id == location_updated_event.id);

            return this;
        }

        private UpdateAllocatableResourcesTableItemWhenLocationUpdated update_employee_views()
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

        public UpdateAllocatableResourcesTableItemWhenLocationUpdated( IEntityRepository<AllocatableResourcesTableView> employee_view_repository
                                                                     , IUnitOfWork unit_of_work)
        {
            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }
        private LocationUpdatedEvent location_updated_event;
        private IEnumerable<AllocatableResourcesTableView> employee_views;

        private readonly IEntityRepository<AllocatableResourcesTableView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}
