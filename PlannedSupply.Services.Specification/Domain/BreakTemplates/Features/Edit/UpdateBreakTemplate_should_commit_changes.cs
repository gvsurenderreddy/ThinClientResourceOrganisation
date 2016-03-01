using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit
{
    [TestClass]
    public class UpdateBreakTemplate_should_commit_changes
                        : CommandCommitedChangesSpecification<UpdateBreakTemplateRequest,
                                                                UpdateBreakTemplateResponse,
                                                                UpdateBreakTeamplateFixture
                                                             > { }
}