using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.New
{
    /// <summary>
    ///     Creates a new 'CreateSkillRequest' object
    /// </summary>
    public class GetCreateSkillRequest
                        :   GetCreateReferenceDataRequest<CreateSkillRequest, GetCreateSkillRequestResponse>,
                            IGetCreateSkillRequest {}
}
