using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New
{
    [TestClass]
    public class NewBreak_should_commit_changes
                        : CommandCommitedChangesSpecification<NewBreakRequest,
                                                              NewBreakResponse,
                                                              NewBreakFixture
                                                             > { }
}