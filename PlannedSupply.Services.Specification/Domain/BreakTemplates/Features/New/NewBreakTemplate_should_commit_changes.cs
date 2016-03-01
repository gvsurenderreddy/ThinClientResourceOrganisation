using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New
{
    [TestClass]
    public class NewBreakTemplate_should_commit_changes
                    : CommandCommitedChangesSpecification<NewBreakTemplateRequest,
                                                            NewBreakTemplateResponse,
                                                            NewBreakTemplateFixture
                                                         > { }
}