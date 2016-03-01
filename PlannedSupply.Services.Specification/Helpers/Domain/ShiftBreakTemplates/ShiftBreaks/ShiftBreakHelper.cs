using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.Breaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks
{
    public class BreakHelper
                    : EnityHelper<Break,
                                  int,
                                  BreakBuilder,
                                  FakeBreakRepository
                                 >
    {
    }
}