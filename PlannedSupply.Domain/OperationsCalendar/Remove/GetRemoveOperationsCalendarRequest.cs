using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove
{
    public class GetRemoveOperationsCalendarRequest
                        : IGetRemoveOperationsCalendarRequest
    {
        public Response< RemoveOperationsCalendarRequest > execute( OperationsCalendarIdentity request )
        {
            var operations_calendar = _operations_calendar_entity_repository
                                                .Entities
                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                ;

            var remove_request_response = new Response< RemoveOperationsCalendarRequest >
            {
                result = new RemoveOperationsCalendarRequest
                {
                    operations_calendar_id  = operations_calendar.id,
                    calendar_name           = operations_calendar.calendar_name
                }
            };

            return remove_request_response;
        }

        public GetRemoveOperationsCalendarRequest( IEntityRepository< PlannedSupply.OperationsCalendars.OperationalCalendar > the_operations_calendar_entity_repository )
        {
            _operations_calendar_entity_repository = Guard.IsNotNull(   the_operations_calendar_entity_repository,
                                                                        "the_operations_calendar_entity_repository"
                                                                    );
        }

        private readonly IEntityRepository< PlannedSupply.OperationsCalendars.OperationalCalendar >
            _operations_calendar_entity_repository;
    }
}