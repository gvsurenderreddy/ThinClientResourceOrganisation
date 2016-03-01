using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New
{
    public class NewOperationsCalendarRequestHelper
                        : IRequestHelper< NewOperationsCalendarRequest >
    {
        public NewOperationsCalendarRequest given_a_valid_request()
        {
            return new NewOperationsCalendarRequest
            {
                calendar_name = "Low seasons demand"
            };
        }
    }
}