using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit
{
    public class GetUpdateOperationsCalendarRequest
                        : IGetUpdateOperationsCalendarRequest
    {
        public Response< UpdateOperationsCalendarRequest > execute( OperationsCalendarIdentity request )
        {
            PlannedSupply.OperationsCalendars.OperationalCalendar operational_calendar = _operations_calendar_entity_repository
                                                                                                .Entities
                                                                                                .Single( oc => oc.id == request.operations_calendar_id )
                                                                                                ;

            return new Response< UpdateOperationsCalendarRequest >
                                    {
                                        result = new UpdateOperationsCalendarRequest
                                                            {
                                                                operations_calendar_id  = operational_calendar.id,
                                                                calendar_name           = operational_calendar.calendar_name
                                                            }
                                    };
        }

        public GetUpdateOperationsCalendarRequest( IEntityRepository< PlannedSupply.OperationsCalendars.OperationalCalendar > the_operations_calendar_entity_repository )
        {
            _operations_calendar_entity_repository = Guard.IsNotNull(   the_operations_calendar_entity_repository,
                                                                        "the_operations_calendar_entity_repository"
                                                                    );
        }

        private readonly IEntityRepository< PlannedSupply.OperationsCalendars.OperationalCalendar > 
            _operations_calendar_entity_repository;

    }
}