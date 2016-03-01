using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Remove
{
    public class RemoveSkillFixture
                    : RemoveRefereceDataFixture< RemoveSkillRequest, RemoveSkillResponse, IRemoveSkill >
    {
        public RemoveSkillFixture(  IRemoveSkill theRemoveSkillCommand,
                                    IRequestHelper< RemoveSkillRequest > theRemoveSkillRequestBuilder
                                 )
                    :   base(   theRemoveSkillCommand,
                                theRemoveSkillRequestBuilder
                            ) {}
    }
}
