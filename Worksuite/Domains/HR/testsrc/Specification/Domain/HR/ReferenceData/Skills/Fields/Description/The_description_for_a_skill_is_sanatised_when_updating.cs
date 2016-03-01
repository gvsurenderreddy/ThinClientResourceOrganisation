using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Fields.Description
{
    [TestClass]
    public class The_description_for_a_skill_is_sanatised_when_updating
                        :   The_description_is_sanatised_when_updating< Skill, UpdateSkillRequest, UpdateSkillResponse, IUpdateSkill, UpdateSkillFixture > {}
}
