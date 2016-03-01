using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.EmployeeViews
{
    public class CreateEmployeeViewWhenEmployeeCreated : IEventSubscriber<EmployeeCreatedEvent>
    {
        public void handle
                     (EmployeeCreatedEvent the_employee_created_event)
        {

            this
                .set_event(the_employee_created_event)
                .create_employee_view()
                .commit()
                ;
        }

        public CreateEmployeeViewWhenEmployeeCreated
                (IEntityRepository<EmployeeView> employee_view_repository
                , IUnitOfWork unit_of_work)
        {

            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }


        private CreateEmployeeViewWhenEmployeeCreated set_event
                                                       (EmployeeCreatedEvent the_employee_created_event)
        {

            this.employee_created_event = Guard.IsNotNull(the_employee_created_event, "the_employee_created_event");
            return this;
        }

        private CreateEmployeeViewWhenEmployeeCreated create_employee_view()
        {

            Guard.IsNotNull(employee_created_event, "employee_created_event");


            employee_view = new EmployeeView
            {

                employee_id = employee_created_event.employee_id,
                forename = employee_created_event.forename,
                surname = employee_created_event.surname,
                employee_reference = employee_created_event.employee_reference,
            };
            return this;
        }

        private void commit()
        {

            Guard.IsNotNull(employee_view, "employee_view");

            employee_view_repository.add(employee_view);
            unit_of_work.Commit();
        }


        private readonly IEntityRepository<EmployeeView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;

        private EmployeeCreatedEvent employee_created_event;
        private EmployeeView employee_view;
    }

}
