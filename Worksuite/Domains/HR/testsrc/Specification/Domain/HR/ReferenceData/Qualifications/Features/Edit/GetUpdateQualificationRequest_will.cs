using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit
{
    [TestClass]
    public class GetUpdateQualificationRequest_will
                        : GetUpdateReferenceDataRequest_will<   Qualification,
                                                                UpdateQualificationRequest,
                                                                GetUpdateQualificationRequestResponse,
                                                                IGetUpdateQualificationRequest
                                                            > { }
}
