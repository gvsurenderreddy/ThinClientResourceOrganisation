using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit
{
    public class UpdateSkillRequestHelper
                    :   UpdateReferenceDataRequestBuilder< Skill, UpdateSkillRequest >
    {
        public UpdateSkillRequestHelper( IEntityRepository< Skill > theSkillRepository )
                    :   base( theSkillRepository ) {}
    }
}
