using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.GetUpdateRequest;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit
{
    public class GetUpdateSkillRequest
                        :   GetUpdateReferenceDataRequest< Skill, UpdateSkillRequest, GetUpdateSkillRequestResponse >,
                            IGetUpdateSkillRequest
    {
        public GetUpdateSkillRequest (IEntityRepository< Skill > the_repository )
                        :   base( the_repository ) {}
    }
}
