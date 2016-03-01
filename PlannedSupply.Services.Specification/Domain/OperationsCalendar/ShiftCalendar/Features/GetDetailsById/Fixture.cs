using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.GetDetailsById;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.GetDetailsById
{
    public class GetShiftCalendarDetailsByIdFixture
    {


        public ShiftCalendarIdentity request { get; private set; }
        public GetShiftCalendarDetailsByIdResponse response { get; private set; }

        public void execute_query()
        {
            response = query.execute(request);
        }

        public void set_shift_calendar_name_from_incoming_request(string seed_name)
        {
            var shift_calendar = operational_calendar_repository.Entities
                                            .Single(oc => oc.id == request.operations_calendar_id)
                                            .ShiftCalendars
                                            .Single(sc=>sc.id == request.shift_calendar_id);

            shift_calendar.calendar_name = seed_name;
        }

        public GetShiftCalendarDetailsByIdFixture(IGetShiftCalendarDetailsById the_query, 
                                                    IRequestHelper<ShiftCalendarIdentity> the_request_builder,
                                                    IQueryRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_repository) 
        {
            query = Guard.IsNotNull(the_query, "the_query");
            request = Guard.IsNotNull(the_request_builder, "the_request_builder").given_a_valid_request( );

            operational_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
        }


        private readonly IGetShiftCalendarDetailsById query;

        private readonly IQueryRepository<OperationsCalendars.OperationalCalendar> operational_calendar_repository;
        
    }
}
