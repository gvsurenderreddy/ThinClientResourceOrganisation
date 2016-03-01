using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Mapper;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetAll
{
    public class GetAllOperationsCalendars
                        : IGetAllOperationsCalendars
    {
        public GetAllOperationsCalendarsResponse execute()
        {
            var all_operations_calendars = _operations_calendar_query_repository
                                                            .Entities
                                                            .OrderBy(oc => oc.calendar_name)
                                                            .ToList()
                                                            .Select(_operations_calendar_details_mapper.Map.Compile())
                                                            ;

            var response = new GetAllOperationsCalendarsResponse
            {
                messages = null,
                has_errors = false,
                result = all_operations_calendars
            };

            return response;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAllOperationsCalendars" /> class.
        /// </summary>
        /// <param name="the_operations_calendar_query_repository">The the_operations_calendar_query_repository.</param>
        public GetAllOperationsCalendars(IQueryRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_query_repository,
                                                IOperationalCalendarSummaryMapper the_operations_calendar_details_mapper
                                              )
        {
            _operations_calendar_query_repository = Guard.IsNotNull(the_operations_calendar_query_repository,
                                                                        "the_operations_calendar_query_repository"
                                                                     );
            _operations_calendar_details_mapper = Guard.IsNotNull(the_operations_calendar_details_mapper,
                                                                        "the_operations_calendar_details_mapper"
                                                                     );
        }

        private readonly IQueryRepository<OperationsCalendars.OperationalCalendar> _operations_calendar_query_repository;
        private readonly IOperationalCalendarSummaryMapper _operations_calendar_details_mapper;
    }
}