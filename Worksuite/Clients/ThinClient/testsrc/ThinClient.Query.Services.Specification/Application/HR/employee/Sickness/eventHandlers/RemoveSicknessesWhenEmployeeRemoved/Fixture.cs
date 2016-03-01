using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.eventHandlers;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.eventHandlers.RemoveSicknessesWhenEmployeeRemoved
{
    public class RemoveEmployeeSicknessesWhenEmployeeRemovedFixture
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
            remove_sicknesses_when_employee_removed_handler.handle(the_event);
        }

        public void seed_sicknesses_for_a_fake_new_employee()
        {
            the_employee_id++;

            sickness_repository.add(new SicknessListView()
            {
                employee_id = the_employee_id,
                sickness_date = DateTime.Now.AddDays(1).Date,
                id = 1
            });

            sickness_repository.add(new SicknessListView()
            {
                employee_id = the_employee_id,
                sickness_date = DateTime.Now.AddDays(2).Date,
                id = 2
            });
        }

        public int number_of_sicknesses_for_employee()
        {
            return sickness_repository.Entities.Count(h => h.employee_id == the_employee_id);
        }



        public RemoveEmployeeSicknessesWhenEmployeeRemovedFixture
                                                (RemoveEmployeeSicknessesWhenEmployeeRemoved the_remove_sicknesses_when_employee_removed_handler
                                                , IEntityRepository<SicknessListView> the_sickness_repository)
        {
            sickness_repository = Guard.IsNotNull(the_sickness_repository, "the_sickness_repository");
            remove_sicknesses_when_employee_removed_handler = Guard.IsNotNull(the_remove_sicknesses_when_employee_removed_handler, "the_remove_sicknesses_when_employee_removed_handler");
        }

        private readonly IEntityRepository<SicknessListView> sickness_repository;
        private readonly RemoveEmployeeSicknessesWhenEmployeeRemoved remove_sicknesses_when_employee_removed_handler;

        private int the_employee_id = 0;
    }
}
