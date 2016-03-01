using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Creates an update job title request and fills it out with
    /// the values of the job title that is to be edited. This returns
    /// our standard response object with the request being the
    /// response property of that object.
    ///
    ///     If the job title does not exits then an null object is returned
    /// and the response is set to have errors.
    ///
    /// </summary>
    public interface IGetUpdateJobTitleRequest
                        : IGetUpdateReferenceDataRequest<UpdateJobTitleRequest, GetUpdateJobTitleRequestResponse> { }
}