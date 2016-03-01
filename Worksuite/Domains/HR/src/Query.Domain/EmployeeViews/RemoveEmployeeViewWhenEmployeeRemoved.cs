using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.EmployeeViews
{
    public class RemoveEmployeeViewWhenEmployeeRemoved : IEventSubscriber<EmployeeRemovedEvent>
    {

        public void handle
                     (EmployeeRemovedEvent the_employee_removed_event)
        {

            this
                .set_event(the_employee_removed_event)
                .find_employee_view()
                .remove_the_employee_view()
                .commit()
                ;
        }

        public RemoveEmployeeViewWhenEmployeeRemoved
                (IEntityRepository<EmployeeView> employee_view_repository
                , IUnitOfWork unit_of_work)
        {

            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }


        private RemoveEmployeeViewWhenEmployeeRemoved set_event
                                                       (EmployeeRemovedEvent the_employee_removed_event)
        {

            this.employee_removed_event = Guard.IsNotNull(the_employee_removed_event, "the_employee_removed_event");
            return this;
        }

        private RemoveEmployeeViewWhenEmployeeRemoved find_employee_view()
        {
            Guard.IsNotNull(employee_removed_event, "employee_removed_event");

            employee_view = employee_view_repository.Entities.Single(ev => ev.employee_id == employee_removed_event.employee_id);

            return this;
        }

        private RemoveEmployeeViewWhenEmployeeRemoved remove_the_employee_view()
        {
            Guard.IsNotNull(employee_view, "employee_view");

            employee_view_repository.remove(employee_view);

            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }


        private readonly IEntityRepository<EmployeeView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;

        private EmployeeRemovedEvent employee_removed_event;
        private EmployeeView employee_view;
    }

}
