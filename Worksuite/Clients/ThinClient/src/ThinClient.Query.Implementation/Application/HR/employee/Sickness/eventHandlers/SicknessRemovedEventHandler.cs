using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.eventHandlers
{
    public class SicknessRemovedEventHandler : IEventSubscriber<SicknessRemovedEvent>
    {
        public void handle(SicknessRemovedEvent the_event_to_handle)
        {
            this
                .get_sickness_entity_from_list(the_event_to_handle)
                .delete_sickness_from_repository();
        }

        private SicknessRemovedEventHandler get_sickness_entity_from_list(SicknessRemovedEvent sickness_remove_event)
        {
            sickness_list_report_item = sickness_list_report_repository.Entities.SingleOrDefault(
                                 e => e.employee_id == sickness_remove_event.employee_id &&
                                 e.sickness_date == sickness_remove_event.sickness_date
                );
            return this;
        }

        private void delete_sickness_from_repository()
        {
            if (sickness_list_report_item != null)
            {
                sickness_list_report_repository.remove(sickness_list_report_item);
                commit();
            }
          
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public SicknessRemovedEventHandler(IUnitOfWork the_unit_of_work
                                         , IEntityRepository<SicknessListView> the_sickness_list_report_repository )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            sickness_list_report_repository = Guard.IsNotNull(the_sickness_list_report_repository, "the_sickness_list_report_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<SicknessListView> sickness_list_report_repository;

        private SicknessListView sickness_list_report_item;
    }
}
