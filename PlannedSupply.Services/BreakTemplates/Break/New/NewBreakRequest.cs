using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New
{
    /// <summary>
    ///     The request accepted by the new break command.
    /// </summary>
    public class NewBreakRequest : BreakIdentity
    {
        public DurationRequest off_set { get; set; }

        public DurationRequest duration { get; set; }

        public bool is_paid { get; set; }
    }
}