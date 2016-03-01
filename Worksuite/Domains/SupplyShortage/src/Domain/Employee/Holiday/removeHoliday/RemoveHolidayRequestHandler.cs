using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday
{
    public class RemoveHolidayRequestHandler : IRemoveHolidayRequestHandler
    {
        public RemoveHolidayResponse execute(RemoveHolidayRequest request)
        {
            return this.set_request(request)
                .initialize_response_builder()
                .get_employee()
                .set_response()
                .publish_event()
                .build_response()
                ;
        }

        private RemoveHolidayRequestHandler set_request(RemoveHolidayRequest request)
        {
            Guard.IsNotNull(request, "request");

            this.request = request;

            return this;
        }

        private RemoveHolidayRequestHandler initialize_response_builder()
        {
            response_builder.set_response(new HolidayIdentity
            {
                employee_id = request.employee_id,
                holiday_date = request.holiday_date
            });

            return this;
        }

        private RemoveHolidayRequestHandler get_employee()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            employee_supply_shortage = employee_supply_shortage_repository
                                        .Entities.SingleOrDefault(e => e.employee_id == request.employee_id);

            return this;
        }

        private RemoveHolidayRequestHandler set_response()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            Guard.IsNotNull(employee_supply_shortage.employee_id, "employee_supply_shortage.employee_id");

            response_builder.build();

            return this;
        }

        public RemoveHolidayRequestHandler publish_event()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            remove_holiday_event_publisher.publish(new HolidayRemovedEvent
            {
                employee_id = employee_supply_shortage.employee_id,
                holiday_date = request.holiday_date
            });

            return this;
        }

        private RemoveHolidayResponse build_response()
        {
            return response_builder.build();
        }

        public RemoveHolidayRequestHandler(IEventPublisher<HolidayRemovedEvent> remove_holiday_event_publisher
             , IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository
            , ServiceStatusResponseBuilder<HolidayIdentity, RemoveHolidayResponse> response_builder
           )
        {
            this.response_builder = Guard.IsNotNull(response_builder, "response_builder");
            this.remove_holiday_event_publisher = Guard.IsNotNull(remove_holiday_event_publisher, "remove_holiday_event_publisher");
            this.employee_supply_shortage_repository = Guard.IsNotNull(employee_supply_shortage_repository, "employee_supply_shortage_repository");

        }
        private readonly ServiceStatusResponseBuilder<HolidayIdentity, RemoveHolidayResponse> response_builder;
        private readonly IEventPublisher<HolidayRemovedEvent> remove_holiday_event_publisher;
        private readonly IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private RemoveHolidayRequest request;
        private EmployeeSupplyShortage employee_supply_shortage;
    }
}
