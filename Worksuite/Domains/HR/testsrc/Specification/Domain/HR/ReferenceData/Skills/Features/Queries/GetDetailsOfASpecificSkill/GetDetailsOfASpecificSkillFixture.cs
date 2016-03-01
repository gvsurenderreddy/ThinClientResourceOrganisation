using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Queries.GetDetailsOfASpecificSkill
{
    public class GetDetailsOfASpecificSkillFixture
                    : GetDetailsOfASpecificReferenceDataFixture< Skill, SkillDetails, IGetDetailsOfASpecificSkill, SkillBuilder, GetDetailsOfASpecificSkillHelper >
    {
        public GetDetailsOfASpecificSkillFixture(   GetDetailsOfASpecificSkillHelper theSkillRequestBuilder,
                                                    IGetDetailsOfASpecificSkill theSpecificSkillDetailsQuery
                                                )
                        :   base(   theSkillRequestBuilder,
                                    theSpecificSkillDetailsQuery
                                ) {}
    }
}
