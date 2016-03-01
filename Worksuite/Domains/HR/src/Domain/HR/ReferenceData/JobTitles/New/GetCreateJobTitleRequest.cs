using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New
{
    /// <summary>
    ///     Creates a new CreateJobTitleRequest
    /// </summary>
    public class GetCreateJobTitleRequest
                    : GetCreateReferenceDataRequest<CreateJobTitleRequest, GetCreateJobTitleRequestResponse>
                    , IGetCreateJobTitleRequest { }
}