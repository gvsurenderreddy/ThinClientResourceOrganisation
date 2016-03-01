using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Response object returned by the <see cref="IGetUpdateJobTitleRequest"/>.  This is our
    /// standard response object with the UpdateRequest as it's response property.
    /// </summary>
    public class GetUpdateJobTitleRequestResponse
                        : GetUpdateReferenceDataRequestResponse<UpdateJobTitleRequest> { }
}