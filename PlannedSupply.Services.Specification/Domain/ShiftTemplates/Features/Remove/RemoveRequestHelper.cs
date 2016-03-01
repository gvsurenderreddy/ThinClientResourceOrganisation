using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Remove
{
    public class RemoveRequestHelper
                     : IRequestHelper<ShiftTemplateIdentity>
    {
        public ShiftTemplateIdentity given_a_valid_request()
        {
            var break_template = break_template_helper
                                    .add()
                                    .template_name("6:00 - 16:00 breakk template")
                                    .entity
                                    ;            

            var shift_template = new PlannedSupply.ShiftTemplates.ShiftTemplate
            {
                shift_title = "6:00-16:00",
                start_time_in_seconds_from_midnight = 43800,
                duration_in_seconds = 5100,
                colour = "23,34,56",
                break_template = break_template
            };
           fake_repository.add(shift_template);
           return new ShiftTemplateIdentity()
            {
                shift_template_id = shift_template.id
            };
        }

        public RemoveRequestHelper(FakeShiftTemplateRepository the_fake_repository,
                                   BreakTemplateHelper the_break_template_helper
                                  )
        {
            fake_repository = Guard.IsNotNull(the_fake_repository, "the_fake_repository");
            break_template_helper = Guard.IsNotNull(the_break_template_helper, "the_break_template_helper");
        }

        private readonly FakeShiftTemplateRepository fake_repository;
        private readonly BreakTemplateHelper break_template_helper;
    }
}