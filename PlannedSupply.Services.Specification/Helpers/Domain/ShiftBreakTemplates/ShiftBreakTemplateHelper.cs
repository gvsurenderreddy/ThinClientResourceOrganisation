using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates
{
    public class BreakTemplateHelper
                    : EnityHelper<BreakTemplate,
                                    int,
                                    BreakTemplateBuilder,
                                    FakeBreakTemplateRepository
                                 >
    {
    }
}