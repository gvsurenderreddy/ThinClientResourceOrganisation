using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness
{
    public class RemoveSicknessRequestHandler : IRemoveSicknessRequestHandler
    {
        public RemoveSicknessResponse execute(RemoveSicknessRequest request)
        {
            return this.set_request(request)
                 .initialize_response_builder()
                 .get_employee()
                 //Do implementation to check for date.
                 .set_response()
                 .publish_event()
                 .build_response()
                 ;
        }

        private RemoveSicknessRequestHandler set_request(RemoveSicknessRequest request)
        {
            Guard.IsNotNull(request, "request");

            this.request = request;

            return this;
        }

        private RemoveSicknessRequestHandler initialize_response_builder()
        {
            response_builder.set_response(new SicknessIdentity
            {
                employee_id = request.employee_id,
                sickness_date = request.sickness_date
            });

            return this;
        }

        private RemoveSicknessRequestHandler get_employee()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            employee_supply_shortage = employee_supply_shortage_repository
                                        .Entities.SingleOrDefault(e => e.employee_id == request.employee_id);

            return this;
        }

        private RemoveSicknessRequestHandler set_response()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            Guard.IsNotNull(employee_supply_shortage.employee_id, "employee_supply_shortage.employee_id");

            response_builder.build();

            return this;
        }

        public RemoveSicknessRequestHandler publish_event()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            remove_sickness_event_publisher.publish(new SicknessRemovedEvent
            {
                employee_id = employee_supply_shortage.employee_id,
                sickness_date = request.sickness_date
            });

            return this;
        }

        private RemoveSicknessResponse build_response()
        {
            return response_builder.build();
        }

        public RemoveSicknessRequestHandler(IEventPublisher<SicknessRemovedEvent> remove_sickness_event_publisher
             , IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository
            , ServiceStatusResponseBuilder<SicknessIdentity, RemoveSicknessResponse> response_builder
           )
        {
            this.response_builder = Guard.IsNotNull(response_builder, "response_builder");
            this.remove_sickness_event_publisher = Guard.IsNotNull(remove_sickness_event_publisher, "remove_sickness_event_publisher");
            this.employee_supply_shortage_repository = Guard.IsNotNull(employee_supply_shortage_repository, "employee_supply_shortage_repository");

        }
        private readonly ServiceStatusResponseBuilder<SicknessIdentity, RemoveSicknessResponse> response_builder;
        private readonly IEventPublisher<SicknessRemovedEvent> remove_sickness_event_publisher;
        private readonly IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private RemoveSicknessRequest request;
        private EmployeeSupplyShortage employee_supply_shortage;

    }
}
