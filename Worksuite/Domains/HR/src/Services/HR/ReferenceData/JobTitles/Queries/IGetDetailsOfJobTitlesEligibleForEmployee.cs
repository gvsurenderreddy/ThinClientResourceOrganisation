using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries
{
    /// <summary>
    ///     Get all the job titles that are eligible for the specified employee, the criteria is:
    ///  the entry that the employee is currently assigned to the employee regardless of its
    ///  hidden status, the not specified element (so that is can be cleared), and then
    /// all the reference data entries that are not hidden.
    /// </summary>
    /// <remarks>
    ///     This does not handle mandatory fields, that is the same query with out the
    /// not specified element but this is a more complex scenario that we have not run into yet.
    /// </remarks>
    public interface IGetDetailsOfJobTitlesEligibleForEmployee
                        : IGetDetailsOfReferencDataEligibleForEmployee<JobTitleDetails> { }
}