using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfAllMaritalStatuses' interface
    ///     It will return all MaritalStatuses that are stored in the system.
    /// </summary>
    public class GetDetailsOfAllMaritalStatuses
        : GetDetailsOfAllReferenceData<MaritalStatus, MaritalStatusDetails>,
            IGetDetailsOfAllMaritalStatuses
    {
        public GetDetailsOfAllMaritalStatuses(IQueryRepository<MaritalStatus> the_repository)
            : base(the_repository) { }
    }
}
