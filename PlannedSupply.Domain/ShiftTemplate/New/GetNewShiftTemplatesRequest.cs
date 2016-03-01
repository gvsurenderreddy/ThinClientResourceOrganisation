using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.New
{
    public class GetNewShiftTemplatesRequest
                     : IGetNewShiftTemplatesRequest
    {
        public NewShiftTemplatesRequest execute()
        {
            return new NewShiftTemplatesRequest()
            {
                shift_title = string.Empty,
                start_time = new TimeRequest()
                {
                    hours = string.Empty,
                    minutes = string.Empty

                },
                duration = new DurationRequest()
                {
                    hours = string.Empty,
                    minutes = string.Empty
                },
                colour = new RGBColourRequest() { R = 255, G = 255, B = 255 }, //White: our default colour
                break_template_id = Null.Id
            };
        }
    }
}