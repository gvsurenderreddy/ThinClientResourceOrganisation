using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.eventHandlers
{
    public class HolidayCreatedEventHandler : IEventSubscriber<HolidayCreatedEvent>
    {
        public void handle(HolidayCreatedEvent holiday_created_event)
        {
            this
               .create_entity(holiday_created_event)
               .set_holiday_created_event_previously_handled_flag()
               .add_to_repository()
               .commit();
        }

        private HolidayCreatedEventHandler create_entity( HolidayCreatedEvent holiday_created_event )
        {
            holiday_list_report_item = new HolidayListView
            {
                employee_id = holiday_created_event.employee_id,
                holiday_date = holiday_created_event.holiday_date
            };

            return this;
        }

        private HolidayCreatedEventHandler set_holiday_created_event_previously_handled_flag()
        {
            Guard.IsNotNull(holiday_list_report_item, "holiday_list_report_item");

            holiday_created_event_previously_handled = holiday_list_report_repository
                                                                        .Entities
                                                                        .Any( e =>
                                                                                e.employee_id == holiday_list_report_item.employee_id &&
                                                                                e.holiday_date == holiday_list_report_item.holiday_date
                                                                            );

            return this;
        }

        private HolidayCreatedEventHandler add_to_repository()
        {
            Guard.IsNotNull(holiday_list_report_item, "holiday_list_report_item");

            if (holiday_created_event_previously_handled == false)
            {
                holiday_list_report_repository.add(holiday_list_report_item);
            }

            return this;
        }

        private void commit()
        {
            if (holiday_created_event_previously_handled == false)
            {
                unit_of_work.Commit();
            }
        }

        public HolidayCreatedEventHandler( IUnitOfWork unit_of_work
                                         , IEntityRepository<HolidayListView> holiday_list_report_repository )
        {
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.holiday_list_report_repository = Guard.IsNotNull(holiday_list_report_repository, "holiday_list_report_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<HolidayListView> holiday_list_report_repository;

        private HolidayListView holiday_list_report_item ;
        private bool holiday_created_event_previously_handled;

    }
}
