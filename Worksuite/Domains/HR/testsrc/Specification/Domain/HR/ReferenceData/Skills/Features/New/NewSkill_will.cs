using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.New
{
    [TestClass]
    public class NewSkill_will
                        :   CommandCommitedChangesSpecification<CreateSkillRequest, CreateSkillResponse, NewSkillFixture> {}
}
