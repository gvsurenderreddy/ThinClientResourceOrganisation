using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break
{
    /// <summary>
    ///     The full details of a shift break.
    /// </summary>
    public class BreakDetails
                    : BreakIdentity
    {
        /// <summary>
        ///     The shift break's 'Starts after' field. E.g: hour 03 and minutes 45.
        /// </summary>
        public DurationRequest off_set { get; set; }

        /// <summary>
        ///     The shift break's 'Duration' field. E.g: hour 01 and minutes 15.
        /// </summary>
        public DurationRequest duration { get; set; }

        /// <summary>
        ///     The shift break's 'is_paid' field to indicate whether it is paid or unpaid break.
        /// </summary>
        public bool is_paid { get; set; }

        /// <summary>
        ///     The shift break order, order by 'off_set_in_seconds'.
        /// </summary>
        public int order { get; set; }
    }
}