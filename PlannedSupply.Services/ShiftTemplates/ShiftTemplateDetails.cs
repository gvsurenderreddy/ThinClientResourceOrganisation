using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates
{
    public class ShiftTemplateDetails
        : ShiftTemplateIdentity
    {

        public string shift_title { get; set; }
        public RgbColour colour { get; set; }
        public TimeRequest start_time { get; set; }
        public TimeRequest end_time { get; set; }
        public DurationRequest duration { get; set; }
        public string break_template_name { get; set; }
    }
}