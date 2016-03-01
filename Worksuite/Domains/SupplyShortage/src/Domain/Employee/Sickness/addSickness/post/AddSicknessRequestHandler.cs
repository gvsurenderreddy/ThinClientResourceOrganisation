using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post
{
    public class AddSicknessRequestHandler : IAddSicknessRequestHandler
    {
        public AddSicknessResponse execute(AddSicknessRequest request)
        {
            return this
               .set_request(request)
               .initialize_response_builder()
               .validate_date_not_null()
               .sanitise_date()
               .get_employee()
               .set_response()
               .publish_event()
               .build_response()
               ;
        }
        private AddSicknessRequestHandler set_request(AddSicknessRequest request)
        {
            Guard.IsNotNull(request, "request");

            this.request = request;

            return this;
        }

        private AddSicknessRequestHandler initialize_response_builder()
        {
            response_builder.set_response(new SicknessIdentity
            {
                employee_id = Null.Id
            });

            return this;
        }

        private AddSicknessRequestHandler get_employee()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            employee_supply_shortage = employee_supply_shortage_repository
                                        .Entities.SingleOrDefault(e => e.employee_id == request.employee_id);

            return this;
        }

        private AddSicknessRequestHandler validate_date_not_null()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            if (string.IsNullOrWhiteSpace(request.sickness_date.day)
               || string.IsNullOrWhiteSpace(request.sickness_date.month)
               || string.IsNullOrWhiteSpace(request.sickness_date.year)
               )
            {
                response_builder.add_status(new AddSicknessRequestHandlerStatuses.InvalidSicknessDate());
            }

            return this;
        }

        private AddSicknessRequestHandler sanitise_date()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            gregorian_calendar_sanitisation
                    .execute(request.sickness_date)
                    .Match(
                        is_valid:
                            valid_sickness_date =>
                            {
                                request.sickness_date.year = valid_sickness_date.year.ToString();
                                request.sickness_date.month = valid_sickness_date.month.ToString();
                                request.sickness_date.day = valid_sickness_date.day.ToString();
                            },

                        is_not_valid:
                            error =>
                            {
                                if (error == null) return;

                                response_builder.add_status(new AddSicknessRequestHandlerStatuses.InvalidSicknessDate());
                            });

            return this;
        }

        private AddSicknessRequestHandler set_response()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            Guard.IsNotNull(employee_supply_shortage.employee_id, "employee_supply_shortage.employee_id");
            Guard.IsNotNull(gregorian_calendar_sanitisation.date_request, "sanitised_date");

            response_builder.set_response(new SicknessIdentity
            {
                employee_id = employee_supply_shortage.employee_id,
                sickness_date = gregorian_calendar_sanitisation.date_request.to_date_time()
            });

            return this;
        }

        public AddSicknessRequestHandler publish_event()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            sickness_event_publisher.publish(new SicknessCreatedEvent
            {
                employee_id = employee_supply_shortage.employee_id,
                sickness_date = gregorian_calendar_sanitisation.date_request.to_date_time()
            });

            return this;
        }

        private AddSicknessResponse build_response()
        {
            return response_builder.build();
        }


        public AddSicknessRequestHandler(ServiceStatusResponseBuilder<SicknessIdentity, AddSicknessResponse> response_builder
                                       , IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository
                                       , GregorianCalendarSanitisation gregorian_calendar_sanitisation
                                       , IEventPublisher<SicknessCreatedEvent> sickness_event_publisher)
        {
            this.response_builder = Guard.IsNotNull(response_builder, "response_builder");
            this.employee_supply_shortage_repository = Guard.IsNotNull(employee_supply_shortage_repository, "employee_supply_shortage_repository");
            this.gregorian_calendar_sanitisation = Guard.IsNotNull(gregorian_calendar_sanitisation, "gregorian_calendar_sanitisation");
            this.sickness_event_publisher = Guard.IsNotNull(sickness_event_publisher, "sickness_event_publisher");
        }

        private readonly ServiceStatusResponseBuilder<SicknessIdentity, AddSicknessResponse> response_builder;
        private readonly IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private readonly GregorianCalendarSanitisation gregorian_calendar_sanitisation;
        private readonly IEventPublisher<SicknessCreatedEvent> sickness_event_publisher;

        private AddSicknessRequest request;
        private EmployeeSupplyShortage employee_supply_shortage;
    }
}