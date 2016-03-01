using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.GetCreateRequest
{
    /// <summary>
    ///     Response object returned by the <see cref="IGetCreateJobTitleRequest"/>.  This is our
    /// standard response object with the CreateRequest as it's response property
    /// </summary>
    public class GetCreateJobTitleRequestResponse
                    : GetCreateReferenceDataRequestResponse<CreateJobTitleRequest> { }
}