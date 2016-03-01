using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates
{
    public class ShiftTemplate
                           : BaseEntity<int>
    {
        public virtual string shift_title { get; set; }
        public virtual int start_time_in_seconds_from_midnight { get; set; }
        public virtual int duration_in_seconds { get; set; }
        public virtual string colour { get; set; }
        public virtual BreakTemplate break_template { get; set; }
    }
}