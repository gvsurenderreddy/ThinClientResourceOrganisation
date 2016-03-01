using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.eventHandlers
{
    public class HolidayRemovedEventHandler : IEventSubscriber<HolidayRemovedEvent>
    {
        public void handle(HolidayRemovedEvent the_event_to_handle)
        {
            this
               .get_holiday_entity_from_list(the_event_to_handle)
               .delete_holiday_from_repository();
        }

        private HolidayRemovedEventHandler get_holiday_entity_from_list(HolidayRemovedEvent holiday_remove_event)
        {
            holiday_list_report_item = holiday_list_report_repository.Entities.SingleOrDefault(
                                 e => e.employee_id == holiday_remove_event.employee_id &&
                                 e.holiday_date == holiday_remove_event.holiday_date
                );
            return this;
        }

        private void delete_holiday_from_repository()
        {
            if (holiday_list_report_item != null)
            {
                holiday_list_report_repository.remove(holiday_list_report_item);
                commit();
            }
           
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public HolidayRemovedEventHandler(IUnitOfWork the_unit_of_work
                                         , IEntityRepository<HolidayListView> the_holiday_list_report_repository )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            holiday_list_report_repository = Guard.IsNotNull(the_holiday_list_report_repository, "the_holiday_list_report_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<HolidayListView> holiday_list_report_repository;

        private HolidayListView holiday_list_report_item;
    }
}
