using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Fields.Description
{
    [TestClass]
    public class A_description_for_a_skill_is_mandatory_on_create
                            :   A_description_is_mandatory_on_create<Skill, CreateSkillRequest, CreateSkillResponse, ICreateSkill, NewSkillFixture> {}
}
