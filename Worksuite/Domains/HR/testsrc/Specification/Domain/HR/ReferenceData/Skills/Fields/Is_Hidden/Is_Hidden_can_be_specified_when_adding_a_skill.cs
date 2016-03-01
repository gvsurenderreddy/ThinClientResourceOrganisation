using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_skill
        :   Is_Hidden_can_be_specified_when_adding_a_new_entry<Skill, CreateSkillRequest, CreateSkillResponse, ICreateSkill, NewSkillFixture> {}
}
