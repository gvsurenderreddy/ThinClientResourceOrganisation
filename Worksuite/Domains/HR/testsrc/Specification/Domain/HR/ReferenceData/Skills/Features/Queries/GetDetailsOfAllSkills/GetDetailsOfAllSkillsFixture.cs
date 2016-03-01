using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Queries.GetDetailsOfAllSkills
{
    public class GetDetailsOfAllSkillsFixture
                    :   GetDetailsOfAllReferenceDataFixture< Skill, SkillDetails, IGetDetailsOfAllSkills, SkillBuilder, FakeSkillRepository, SkillHelper >
    {
        public GetDetailsOfAllSkillsFixture(    SkillHelper the_helper,
                                                IGetDetailsOfAllSkills the_query
                                           )
                            : base( the_helper,
                                    the_query
                                  )
        {
        }
    }
}
