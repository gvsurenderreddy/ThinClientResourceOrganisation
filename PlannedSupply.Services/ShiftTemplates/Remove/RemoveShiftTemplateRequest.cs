using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove
{
    public class RemoveShiftTemplateRequest
                     : ShiftTemplateIdentity
    {
        public string shift_title { get; set; }
        public TimeRequest start_time { get; set; }
        public DurationRequest duration_in_seconds { get; set; }
        public RGBColourRequest colour { get; set; }
    }
}