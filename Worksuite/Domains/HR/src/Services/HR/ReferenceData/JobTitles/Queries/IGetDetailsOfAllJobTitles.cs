using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries
{
    /// <summary>
    ///     Get the full details of all job titles in the system.
    /// </summary>
    public interface IGetDetailsOfAllJobTitles
                        : IGetDetailsOfAllReferenceData<JobTitleDetails> { }
}