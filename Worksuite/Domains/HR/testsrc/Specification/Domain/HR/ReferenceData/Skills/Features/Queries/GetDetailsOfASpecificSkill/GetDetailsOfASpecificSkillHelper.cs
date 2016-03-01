using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Queries.GetDetailsOfASpecificSkill
{
    public class GetDetailsOfASpecificSkillHelper
                        :   GetDetailsOfASpecificReferenceDataRequestHelper< Skill, SkillBuilder >
    {
        public GetDetailsOfASpecificSkillHelper(   IEntityRepository< Skill > theSkillRepository,
                                                    SkillBuilder theSkillBuilder
                                                )
                           :    base(   theSkillRepository,
                                        theSkillBuilder
                                    ) {}
    }
}
