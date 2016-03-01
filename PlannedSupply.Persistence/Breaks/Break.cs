using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.PlannedSupply.Breaks
{
    public class Break : BaseEntity<int>
    {
        /// <summary>
        ///     The offset in second from the start time.
        /// </summary>
        public virtual int offset_from_start_time_in_seconds { get; set; }

        /// <summary>
        ///     The duration in seconds.
        /// </summary>
        public virtual int duration_in_seconds { get; set; }

        /// <summary>
        ///     The is to indicate whether the break is paid or un-paid.
        /// </summary>
        public virtual bool is_paid { get; set; }
    }
}