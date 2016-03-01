using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.holidayRemoved
{
    public class HolidayRemovedEventFixture
    {
        public void add_to_repository()
        {
            DateTime add_date = new DateTime(2015, 4, 1);
            holiday_list_view_helper.add().employee_id(1).holiday_date(add_date);
            holiday_list_view_helper.add().employee_id(1).holiday_date(add_date.AddDays(1));
        }


        public HolidayRemovedEvent CreateEvent(DateTime holiday_date)
        {
            return new HolidayRemovedEvent
            {
                employee_id = 1,
                holiday_date = holiday_date
            };
        }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public int count_matching_events_in_repository(HolidayRemovedEvent removed_event)
        {
            return
                holiday_list_view_helper.entities.Count(
                    h => h.employee_id == removed_event.employee_id && h.holiday_date == removed_event.holiday_date);
        }
        public HolidayRemovedEventFixture(HolidayListViewHelper holiday_list_view_helper
                                         , FakeUnitOfWork unit_of_work
                                         , IEventSubscriber<HolidayRemovedEvent> holiday_removed_event_handler)
        {
            this.holiday_list_view_helper = Guard.IsNotNull(holiday_list_view_helper, "holiday_list_view_helper");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.holiday_removed_event_handler = Guard.IsNotNull(holiday_removed_event_handler, "holiday_removed_event_handler");
        }

        private readonly HolidayListViewHelper holiday_list_view_helper;
        private readonly FakeUnitOfWork unit_of_work;
        public IEventSubscriber<HolidayRemovedEvent> holiday_removed_event_handler { private set; get; }
    }
}
