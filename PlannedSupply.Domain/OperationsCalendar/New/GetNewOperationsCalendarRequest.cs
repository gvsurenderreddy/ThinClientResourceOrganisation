using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.New
{
    public class GetNewOperationsCalendarRequest
                        : IGetNewOperationsCalendarRequest
    {
        public NewOperationsCalendarRequest execute()
        {
            return new NewOperationsCalendarRequest
            {
                calendar_name = string.Empty
            };
        }
    }
}