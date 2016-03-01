using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.eventHandlers
{
    public class SicknessCreatedEventHandler : IEventSubscriber<SicknessCreatedEvent>
    {
        public void handle(SicknessCreatedEvent sickness_created_event)
        {
            this
                .create_entity(sickness_created_event)
                .set_sickness_created_event_previously_handled_flag()
                .add_sickness_to_repository()
                .commit();

        }

        private SicknessCreatedEventHandler create_entity(SicknessCreatedEvent sickness_created_event)
        {
            sickness_list_report_item = new SicknessListView
            {
                employee_id = sickness_created_event.employee_id,
                sickness_date = sickness_created_event.sickness_date
            };

            return this;
        }

        private SicknessCreatedEventHandler set_sickness_created_event_previously_handled_flag()
        {
            Guard.IsNotNull(sickness_list_report_item, "sickness_list_report_item");

            sicknessy_created_event_previously_handled = sickness_list_report_repository.Entities.Any(
                e => e.employee_id == sickness_list_report_item.employee_id &&
                     e.sickness_date == sickness_list_report_item.sickness_date);

            return this;

        }

        private SicknessCreatedEventHandler add_sickness_to_repository()
        {
            Guard.IsNotNull(sickness_list_report_item, "sickness_list_report_item");
            if (sicknessy_created_event_previously_handled == false)
            {
                sickness_list_report_repository.add(sickness_list_report_item);
            }
            return this;
        }

        private void commit()
        {
            if (sicknessy_created_event_previously_handled == false)
            {
                unit_of_work.Commit();
            }
        }

        public SicknessCreatedEventHandler(IUnitOfWork the_unit_of_work
                                         , IEntityRepository<SicknessListView> the_sickness_list_report_repository )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            sickness_list_report_repository = Guard.IsNotNull(the_sickness_list_report_repository, "the_sickness_list_report_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<SicknessListView> sickness_list_report_repository;

        private SicknessListView sickness_list_report_item;
        private bool sicknessy_created_event_previously_handled;
    }
}
