using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit
{
    [TestClass]
    public class GetUpdateJobTitleRequest_will
                        : GetUpdateReferenceDataRequest_will<JobTitle,
                                                             UpdateJobTitleRequest,
                                                             GetUpdateJobTitleRequestResponse,
                                                             IGetUpdateJobTitleRequest
                                                            > { }
}