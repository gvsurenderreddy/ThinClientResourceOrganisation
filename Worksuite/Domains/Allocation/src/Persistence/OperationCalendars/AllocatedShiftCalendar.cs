using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.Allocation.OperationCalendars {

    /// <summary>
    ///  Shift calendar persistence model for the allocation bounded context
    /// </summary>
    public class AllocatedShiftCalendar 
                    : BaseEntity<int> {

        public virtual string calendar_name { get; set; }
    }
}