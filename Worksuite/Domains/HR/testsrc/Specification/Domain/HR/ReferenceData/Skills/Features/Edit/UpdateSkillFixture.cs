using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit
{
    public class UpdateSkillFixture
                       : UpdateRefereceDataFixture< Skill, UpdateSkillRequest, UpdateSkillResponse, IUpdateSkill >
    {
        public UpdateSkillFixture(  IUpdateSkill theUpdateSkillCommand,
                                    IRequestHelper< UpdateSkillRequest > theUpdateSkillRequestBuilder,
                                    IEntityRepository< Skill > theSkillRepository
                                 )
                    :   base(   theUpdateSkillCommand,
                                theUpdateSkillRequestBuilder,
                                theSkillRepository
                            ) {}
    }
}
