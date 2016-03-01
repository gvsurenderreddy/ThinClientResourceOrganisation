using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Remove
{
    [TestClass]
    public class RemoveBreak_should
                        : CommandCommitedChangesSpecification<BreakIdentity,
                                                              RemoveBreakResponse,
                                                              RemoveBreakFixture
                                                             > { }
}