using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Remove
{
    public class RemoveSkillRequestHelper
                    :   RemoveReferenceDataRequestBuilder< Skill, RemoveSkillRequest >
    {
        public RemoveSkillRequestHelper( IEntityRepository< Skill > theSkillRepository )
                    :   base( theSkillRepository ) {}
    }
}
