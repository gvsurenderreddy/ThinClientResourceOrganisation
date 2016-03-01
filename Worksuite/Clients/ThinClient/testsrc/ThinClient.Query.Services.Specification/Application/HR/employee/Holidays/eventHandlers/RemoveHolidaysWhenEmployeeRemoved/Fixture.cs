using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.RemoveHolidaysWhenEmployeeRemoved
{
    public class RemoveEmployeeHolidaysWhenEmployeeRemovedFixture
    {
        public EmployeeRemovedEvent trigger_employee_removed_event()
        {
            return new EmployeeRemovedEvent
            {
                employee_id = the_employee_id,
            };
        }

        public void handle_event(EmployeeRemovedEvent the_event)
        {
            remove_holidays_when_employee_removed_handler.handle(the_event);
        }

        public void seed_holidays_for_a_fake_new_employee()
        {
            the_employee_id++;

            holiday_repository.add(new HolidayListView()
            {
                employee_id = the_employee_id,
                holiday_date = DateTime.Now.AddDays(1).Date,
                id = 1
            });

            holiday_repository.add(new HolidayListView()
            {
                employee_id = the_employee_id,
                holiday_date = DateTime.Now.AddDays(2).Date,
                id = 2
            });
        }

        public int number_of_holidays_for_employee()
        {
            return holiday_repository.Entities.Count(h => h.employee_id == the_employee_id);
        }

        

        public RemoveEmployeeHolidaysWhenEmployeeRemovedFixture
                                                (RemoveEmployeeHolidaysWhenEmployeeRemoved the_remove_holidays_when_employee_removed_handler
                                                , IEntityRepository<HolidayListView> the_holiday_repository)
        {
            holiday_repository = Guard.IsNotNull(the_holiday_repository, "the_holiday_repository");
            remove_holidays_when_employee_removed_handler = Guard.IsNotNull(the_remove_holidays_when_employee_removed_handler, "the_remove_holidays_when_employee_removed_handler");
        }

        private readonly IEntityRepository<HolidayListView> holiday_repository;
        private readonly RemoveEmployeeHolidaysWhenEmployeeRemoved remove_holidays_when_employee_removed_handler;

        private int the_employee_id = 0;
    }
}
