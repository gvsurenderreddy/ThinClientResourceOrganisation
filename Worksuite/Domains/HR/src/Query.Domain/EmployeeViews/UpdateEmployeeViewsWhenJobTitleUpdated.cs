using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.HR.Query.EmployeeViews
{
    public class UpdateEmployeeViewsWhenJobTitleUpdated : IEventSubscriber<JobTitleUpdatedEvent>
    {
        public void handle(JobTitleUpdatedEvent the_jobtitle_updated_event)
        {

            this
                .set_event(the_jobtitle_updated_event)
                .find_employee_views()
                .update_employee_views()
                .commit()
                ;
        }

        public UpdateEmployeeViewsWhenJobTitleUpdated
                                                (IEntityRepository<EmployeeView> employee_view_repository
                                                , IUnitOfWork unit_of_work)
        {

            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }


        private UpdateEmployeeViewsWhenJobTitleUpdated set_event
                                                                (JobTitleUpdatedEvent the_jobtitle_updated_event)
        {


            jobtitle_updated_event = Guard.IsNotNull(the_jobtitle_updated_event, "the_jobtitle_updated_event");
            return this;
        }

        private UpdateEmployeeViewsWhenJobTitleUpdated find_employee_views()
        {

            Guard.IsNotNull(jobtitle_updated_event, "jobtitle_updated_event");

            employee_views = employee_view_repository
                             .Entities
                             .Where(e => e.job_title_id == jobtitle_updated_event.id)
                             ;

            return this;
        }

        private UpdateEmployeeViewsWhenJobTitleUpdated update_employee_views()
        {

            Guard.IsNotNull(employee_views, "employee_views");

            employee_views.Do(ev =>
            {
                ev.job_title = jobtitle_updated_event.description;
            });

            return this;
        }

        private void commit()
        {

            unit_of_work.Commit();
        }

        private JobTitleUpdatedEvent jobtitle_updated_event;
        private IEnumerable<EmployeeView> employee_views;

        private readonly IEntityRepository<EmployeeView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}
