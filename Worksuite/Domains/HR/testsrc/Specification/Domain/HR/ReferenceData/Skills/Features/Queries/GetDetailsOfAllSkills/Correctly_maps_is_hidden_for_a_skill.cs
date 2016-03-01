using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Queries.GetDetailsOfAllSkills
{
    [TestClass]
    public class Correctly_maps_is_hidden_for_a_skill
                    :   Correctly_maps_is_hidden< Skill , SkillBuilder, SkillDetails, GetDetailsOfAllSkillsFixture> {}
}
