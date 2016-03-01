using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfASpecificMaritalStatus' interface
    ///     It will return a specific MaritalStatus that is stored in the system.
    /// </summary>
    public class GetDetailsOfASpecificMaritalStatus
                        : GetDetailsOfASpecificReferenceData<MaritalStatusDetails, MaritalStatus>,
                            IGetDetailsOfASpecificMaritalStatus
    {
        public GetDetailsOfASpecificMaritalStatus(IQueryRepository<MaritalStatus> the_repository)
            : base(the_repository) { }
    }
}
