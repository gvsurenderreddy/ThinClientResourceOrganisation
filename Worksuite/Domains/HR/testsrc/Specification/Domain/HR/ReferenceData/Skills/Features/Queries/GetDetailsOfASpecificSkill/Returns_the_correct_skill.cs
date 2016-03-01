using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Queries.GetDetailsOfASpecificSkill
{
    [TestClass]
    public class Returns_the_correct_skill
                        :   Returns_the_correct_entity< Skill, SkillBuilder, SkillDetails, GetDetailsOfASpecificSkillFixture > {}
}
