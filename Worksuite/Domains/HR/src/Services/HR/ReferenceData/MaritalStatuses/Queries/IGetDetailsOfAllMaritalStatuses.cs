using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries
{

    /// <summary>
    ///     Get the full details of all marital statuses in the system
    /// </summary>
    public interface IGetDetailsOfAllMaritalStatuses
                        : IGetDetailsOfAllReferenceData<MaritalStatusDetails> { }

}