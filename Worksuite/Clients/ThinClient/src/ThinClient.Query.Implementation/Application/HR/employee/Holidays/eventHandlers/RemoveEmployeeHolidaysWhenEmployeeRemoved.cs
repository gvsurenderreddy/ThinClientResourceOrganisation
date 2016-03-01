using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.eventHandlers
{
    public class RemoveEmployeeHolidaysWhenEmployeeRemoved : IEventSubscriber<EmployeeRemovedEvent>
    {
        public void handle(EmployeeRemovedEvent the_event_to_handle)
        {
            set_event(the_event_to_handle)
                .find_holidays_for_employee()
                .remove_holidays_from_repository()
                .commmit();
        }

        private RemoveEmployeeHolidaysWhenEmployeeRemoved set_event(EmployeeRemovedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");

            return this;
        }

        private RemoveEmployeeHolidaysWhenEmployeeRemoved find_holidays_for_employee()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");

            holidays_to_be_removed = holiday_repository.Entities.Where(h => h.employee_id == event_to_handle.employee_id).ToList();

            return this;
        }

        private RemoveEmployeeHolidaysWhenEmployeeRemoved remove_holidays_from_repository()
        {
            Guard.IsNotNull(holidays_to_be_removed, "holidays_to_be_removed");

            holidays_to_be_removed.Do(h => holiday_repository.remove(h));

            return this;
        }

        private void commmit()
        {
            unit_of_work.Commit();
        }


        public RemoveEmployeeHolidaysWhenEmployeeRemoved(IUnitOfWork the_unit_of_work,
                                                           IEntityRepository<HolidayListView> the_holiday_repository)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            holiday_repository = Guard.IsNotNull(the_holiday_repository, "the_holiday_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<HolidayListView> holiday_repository;


        private EmployeeRemovedEvent event_to_handle;

        private IEnumerable<HolidayListView> holidays_to_be_removed;
    }
}
