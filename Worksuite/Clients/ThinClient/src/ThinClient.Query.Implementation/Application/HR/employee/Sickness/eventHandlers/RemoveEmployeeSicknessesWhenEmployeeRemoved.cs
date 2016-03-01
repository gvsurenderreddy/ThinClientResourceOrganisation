using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.eventHandlers
{
    public class RemoveEmployeeSicknessesWhenEmployeeRemoved : IEventSubscriber<EmployeeRemovedEvent>
    {
        public void handle(EmployeeRemovedEvent the_event_to_handle)
        {
            set_event(the_event_to_handle)
                .find_sicknesses_for_employee()
                .remove_holidays_from_repository()
                .commmit();
        }

        private RemoveEmployeeSicknessesWhenEmployeeRemoved set_event(EmployeeRemovedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");

            return this;
        }

        private RemoveEmployeeSicknessesWhenEmployeeRemoved find_sicknesses_for_employee()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");

            holidays_to_be_removed = sickness_repository.Entities.Where(h => h.employee_id == event_to_handle.employee_id).ToList();

            return this;
        }

        private RemoveEmployeeSicknessesWhenEmployeeRemoved remove_holidays_from_repository()
        {
            Guard.IsNotNull(holidays_to_be_removed, "holidays_to_be_removed");

            holidays_to_be_removed.Do(h => sickness_repository.remove(h));

            return this;
        }

        private void commmit()
        {
            unit_of_work.Commit();
        }


        public RemoveEmployeeSicknessesWhenEmployeeRemoved(IUnitOfWork the_unit_of_work,
                                                           IEntityRepository<SicknessListView> the_holiday_repository)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            sickness_repository = Guard.IsNotNull(the_holiday_repository, "the_holiday_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<SicknessListView> sickness_repository;


        private EmployeeRemovedEvent event_to_handle;

        private IEnumerable<SicknessListView> holidays_to_be_removed;
    }
}
