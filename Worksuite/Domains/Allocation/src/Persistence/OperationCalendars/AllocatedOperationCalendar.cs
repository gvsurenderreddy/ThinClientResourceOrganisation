using System.Collections.Generic;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.Allocation.OperationCalendars {

    /// <summary>
    ///  OperationCalendar model for the allocation bounded context
    /// </summary>
    public class AllocatedOperationCalendar
                    : BaseEntity<int> {
        
        /// <summary>
        ///  All the shift calendars for the operation calendar
        /// </summary>
        public virtual ICollection<AllocatedShiftCalendar> shift_calendars {

            get { return ShiftCalendars ?? (ShiftCalendars = new HashSet<AllocatedShiftCalendar>()); }
            set { ShiftCalendars = value; }
        }

        private ICollection<AllocatedShiftCalendar> ShiftCalendars;
    }
}