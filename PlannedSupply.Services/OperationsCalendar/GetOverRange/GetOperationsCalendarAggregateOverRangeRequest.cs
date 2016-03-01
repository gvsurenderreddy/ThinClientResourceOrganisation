using System;
using WTS.WorkSuite.Library.DomainTypes;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange
{
    public class GetOperationsCalendarAggregateOverRangeRequest : OperationsCalendarIdentity
    {
        public DateTime start_date { get; set; }

        public ShiftCalendarRange range_type { get; set; }

        public GetOperationsCalendarAggregateOverRangeRequest()
        {
            start_date = DateTime.Now.Date;
        }
    }
}
