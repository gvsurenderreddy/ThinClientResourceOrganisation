using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates
{
    public class ShiftTemplateIdentityHelper
    {
        public ShiftTemplateIdentity get_identity()
        {
            return new ShiftTemplateIdentity
            {
                shift_template_id = _shift_template.id
            };
        }

        public ShiftTemplateIdentityHelper()
        {
            _shift_template_helper = DependencyResolver.resolve<ShiftTemplatehelper>();

            _shift_template = _shift_template_helper
                                        .add()
                                        .shift_title("06:00 - 18:00 shift")
                                        .start_time(new TimeRequest() { hours = "5", minutes = "30" })
                                        .duration(new DurationRequest() { hours = "1", minutes = "15" })
                                        .colour(new RgbColour(25, 24, 28))
                                        .entity
                                        ;
        }

        private ShiftTemplatehelper _shift_template_helper;
        private WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate _shift_template;
    }
}