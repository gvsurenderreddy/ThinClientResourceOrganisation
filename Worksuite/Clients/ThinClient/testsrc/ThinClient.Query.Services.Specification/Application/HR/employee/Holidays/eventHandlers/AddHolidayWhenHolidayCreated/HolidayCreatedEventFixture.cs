using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.AddHolidayWhenHolidayCreated
{
    public class HolidayCreatedEventFixture
    {
        public HolidayCreatedEvent CreateEvent()
        {
            return new HolidayCreatedEvent
            {
                employee_id = 1,
                holiday_date = DateTime.Now
            };
        }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public int count_matching_events_in_repository( HolidayCreatedEvent created_event )
        {
            return
                holiday_list_view_helper.entities.Count(
                    h => h.employee_id == created_event.employee_id && h.holiday_date == created_event.holiday_date);
        }

        public HolidayCreatedEventFixture( HolidayListViewHelper holiday_list_view_helper 
                                         , FakeUnitOfWork unit_of_work 
                                         , IEventSubscriber<HolidayCreatedEvent> holiday_created_event_handler )
        {
            this.holiday_list_view_helper =Guard.IsNotNull(holiday_list_view_helper, "holiday_list_view_helper");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.holiday_created_event_handler = Guard.IsNotNull(holiday_created_event_handler, "holiday_created_event_handler");
        }

        private readonly HolidayListViewHelper holiday_list_view_helper;
        private readonly FakeUnitOfWork unit_of_work;
        public IEventSubscriber<HolidayCreatedEvent> holiday_created_event_handler { private set; get; }

    }
}
