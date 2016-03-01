using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit
{
    public class UpdateShiftTemplateRequest
                           : ShiftTemplateIdentity
    {
        public string shift_title { get; set; }
        public RGBColourRequest colour { get; set; }
        public TimeRequest start_time { get; set; }
        public DurationRequest duration { get; set; }
        public int break_template_id { get; set; }
    }
}