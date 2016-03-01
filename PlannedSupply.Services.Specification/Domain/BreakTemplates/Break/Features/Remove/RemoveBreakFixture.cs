using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Remove
{
    public class RemoveBreakFixture
                    : ResponseCommandFixture<BreakIdentity,
                                             RemoveBreakResponse,
                                             IRemoveBreak
                                            >
    {
        public RemoveBreakFixture(IRemoveBreak the_remove_break_command,
                                       IRequestHelper<BreakIdentity> the_break_request_helper
                                      )
            : base(the_remove_break_command,
                   the_break_request_helper
                  ) { }
    }
}