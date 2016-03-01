using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Remove
{
    [TestClass]
    public class Remove_will
                    :   CommandCommitedChangesSpecification< RemoveSkillRequest, RemoveSkillResponse, RemoveSkillFixture > {}
}
