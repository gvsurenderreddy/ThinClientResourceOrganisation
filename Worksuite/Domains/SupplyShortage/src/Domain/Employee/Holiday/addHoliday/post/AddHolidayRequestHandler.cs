using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post
{
    public class AddHolidayRequestHandler : IAddHolidayRequestHandler
    {
        public AddHolidayResponse execute( AddHolidayRequest request )
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

        private AddHolidayRequestHandler set_request( AddHolidayRequest request )
        {
            Guard.IsNotNull(request, "request");

            this.request = request;

            return this;
        }

        private AddHolidayRequestHandler initialize_response_builder()
        {
            response_builder.set_response( new HolidayIdentity
            {
                employee_id = Null.Id
            } );

            return this;
        }

        private AddHolidayRequestHandler get_employee()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            employee_supply_shortage = employee_supply_shortage_repository.Entities.SingleOrDefault(e => e.employee_id == request.employee_id);

            return this;
        }

        private AddHolidayRequestHandler validate_date_not_null()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            // PA: Entry on tech debt board to raise the fact that the sanitisation allows null dates and even though internally there is an error state
            // raised these are still treated as valid. To address this we will address nullability in advance:

            if (  string.IsNullOrWhiteSpace(request.holiday_date.day)
               || string.IsNullOrWhiteSpace(request.holiday_date.month)
               || string.IsNullOrWhiteSpace(request.holiday_date.year)
               )
            {
                response_builder.add_status(new AddHolidayRequestHandlerStatuses.InvalidHolidayDate());
            }

            return this;
        }


        private AddHolidayRequestHandler sanitise_date()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            gregorian_calendar_sanitisation
                    .execute(request.holiday_date)
                    .Match(
                        is_valid:
                            valid_holiday_date =>
                            {
                                request.holiday_date.year = valid_holiday_date.year.ToString();
                                request.holiday_date.month = valid_holiday_date.month.ToString();
                                request.holiday_date.day = valid_holiday_date.day.ToString();
                            },

                        is_not_valid:
                            error =>
                            {
                                if (error == null) return;

                                response_builder.add_status(new AddHolidayRequestHandlerStatuses.InvalidHolidayDate());
                            });

            return this;
        }

        private AddHolidayRequestHandler set_response()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            Guard.IsNotNull(employee_supply_shortage.employee_id, "employee_supply_shortage.employee_id");
            Guard.IsNotNull(gregorian_calendar_sanitisation.date_request, "sanitised_date");

            response_builder.set_response(new HolidayIdentity
            {
                employee_id = employee_supply_shortage.employee_id,
                holiday_date = gregorian_calendar_sanitisation.date_request.to_date_time()
            });

            return this;
        }

        public AddHolidayRequestHandler publish_event()
        {
            if (response_builder.has_errors)
            {
                return this;
            }

            holiday_event_publisher.publish(new HolidayCreatedEvent
            {
                employee_id = employee_supply_shortage.employee_id,
                holiday_date = gregorian_calendar_sanitisation.date_request.to_date_time()
            });

            return this;
        }

        private AddHolidayResponse build_response()
        {
            return response_builder.build();
        }


        public AddHolidayRequestHandler( ServiceStatusResponseBuilder<HolidayIdentity, AddHolidayResponse> response_builder
                                       , IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository
                                       , GregorianCalendarSanitisation gregorian_calendar_sanitisation 
                                       , IEventPublisher<HolidayCreatedEvent> holiday_event_publisher )
        {
            this.response_builder = Guard.IsNotNull(response_builder, "response_builder");
            this.employee_supply_shortage_repository = Guard.IsNotNull(employee_supply_shortage_repository, "employee_supply_shortage_repository");
            this.gregorian_calendar_sanitisation = Guard.IsNotNull(gregorian_calendar_sanitisation, "gregorian_calendar_sanitisation");
            this.holiday_event_publisher = Guard.IsNotNull(holiday_event_publisher, "holiday_event_publisher");
        }

        private readonly ServiceStatusResponseBuilder<HolidayIdentity, AddHolidayResponse> response_builder;
        private readonly IQueryRepository<EmployeeSupplyShortage> employee_supply_shortage_repository;
        private readonly GregorianCalendarSanitisation gregorian_calendar_sanitisation;
        private readonly IEventPublisher<HolidayCreatedEvent> holiday_event_publisher;

        private AddHolidayRequest request;
        private EmployeeSupplyShortage employee_supply_shortage;
    }
}
