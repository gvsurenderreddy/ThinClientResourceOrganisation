using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.EmployeeViews
{
    public class UpdateEmployeeViewWhenPersonalDetailsUpdated : IEventSubscriber<EmployeePersonalDetailsUpdatedEvent>
    {
        public void handle(EmployeePersonalDetailsUpdatedEvent the_employee_details_updated_event)
        {

            this
                .set_event(the_employee_details_updated_event)
                .find_employee_view()
                .update_employee()
                .commit()
                ;
        }

        public UpdateEmployeeViewWhenPersonalDetailsUpdated
                (IEntityRepository<EmployeeView> employee_view_repository
                , IUnitOfWork unit_of_work)
        {

            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }


        private UpdateEmployeeViewWhenPersonalDetailsUpdated set_event
                                                                (EmployeePersonalDetailsUpdatedEvent the_employee_details_updated_event)
        {
            this.employee_details_updated_event = Guard.IsNotNull(the_employee_details_updated_event, "the_employee_details_updated_event");
            return this;
        }

        private UpdateEmployeeViewWhenPersonalDetailsUpdated find_employee_view()
        {

            Guard.IsNotNull(employee_details_updated_event, "employee_details_updated_event");

            employee_view = employee_view_repository
                             .Entities
                             .Single(e => e.employee_id == employee_details_updated_event.employee_id)
                             ;

            return this;
        }

        private UpdateEmployeeViewWhenPersonalDetailsUpdated update_employee()
        {

            Guard.IsNotNull(employee_view, "employee_view");

            employee_view.forename = employee_details_updated_event.forename;
           // employee_view.surname = employee_details_updated_event.surname;

            return this;
        }

        private UpdateEmployeeViewWhenPersonalDetailsUpdated commit()
        {

            unit_of_work.Commit();
            return this;
        }

        private EmployeePersonalDetailsUpdatedEvent employee_details_updated_event;
        private EmployeeView employee_view;

        private readonly IEntityRepository<EmployeeView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}
