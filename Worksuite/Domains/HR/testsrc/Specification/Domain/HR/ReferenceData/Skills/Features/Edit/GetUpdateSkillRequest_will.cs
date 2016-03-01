using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Skills.Features.Edit
{
    [TestClass]
    public class GetUpdateSkillRequest_will
                    :   GetUpdateReferenceDataRequest_will< Skill, UpdateSkillRequest, GetUpdateSkillRequestResponse, IGetUpdateSkillRequest > {}
}
