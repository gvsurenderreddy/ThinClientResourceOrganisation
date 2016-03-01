using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove
{
    /// <summary>
    ///     Removes the job title specified in the supplied request. It is not
    /// considered an error if the job title does not exist.
    /// </summary>
    public interface IRemoveJobTitle
                        : IRemoveReferenceData<RemoveJobTitleRequest,
                                               RemoveJobTitleResponse
                                              > { }
}