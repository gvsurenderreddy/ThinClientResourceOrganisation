using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Event.Location
{
    public class LocationUpdatedFixture
    {
        public LocationUpdatedEvent simulate_event()
        {
            var the_id = ++new_event_id;

            var fake_employee_view = new ConfirmResourceAllocationEditorView
            {
                location = "location" + the_id,
                location_id = the_id,
                id = the_id
            };

            var find_employee_table_view = employee_repository_helper.add().entity;
            find_employee_table_view.location_id = fake_employee_view.location_id;
            find_employee_table_view.location = fake_employee_view.location;

            return new LocationUpdatedEvent
            {
                id = fake_employee_view.job_title_id,
                description = fake_employee_view.location + "updated"
            };
        }

        public IEnumerable<ConfirmResourceAllocationEditorView> all_employee_views {get{return employee_repository_helper.entities;}}

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public LocationUpdatedFixture(UpdateConfirmResourceAllocationEditorViewWhenLocationUpdated event_handler
                                      , FindConfirmResourceAllocationEditorViewHelper employee_repository_helper
                                      , FakeUnitOfWork unit_of_work)
        {
            this.event_handler = Guard.IsNotNull(event_handler, "event_handler");
            this.employee_repository_helper = Guard.IsNotNull(employee_repository_helper, "employee_repository_helper");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }

        private readonly FindConfirmResourceAllocationEditorViewHelper employee_repository_helper;
        private readonly FakeUnitOfWork unit_of_work;
        public UpdateConfirmResourceAllocationEditorViewWhenLocationUpdated event_handler { get; private set; }

        private int new_event_id = 0;
    }
}
