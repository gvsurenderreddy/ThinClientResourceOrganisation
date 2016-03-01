using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create
{
    /// <summary>
    ///     Creates a new job title from the supplied request and returns the identity
    /// of the new job title in the response object. If the request was not valid the errors
    /// are reported in the response object and a null identity is returned.
    /// </summary>
    public interface ICreateJobTitle
                        : ICreateReferenceData<CreateJobTitleRequest,
                                               CreateJobTitleResponse
                                              > { }
}