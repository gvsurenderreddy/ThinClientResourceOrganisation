using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit
{
    [TestClass]
    public class UpdateBreak_should_Commit_changes
                        : CommandCommitedChangesSpecification<UpdateBreakRequest,
                                                              UpdateBreakResponse,
                                                              UpdateBreakFixture
                                                             > { }
}