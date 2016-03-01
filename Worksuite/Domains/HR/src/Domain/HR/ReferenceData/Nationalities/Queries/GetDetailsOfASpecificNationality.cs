using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries
{
    /// <summary>
    ///     Implements the interface 'IGetDetailsOfASpecificNationality'.
    ///     It will returned the specific nationality that is stored in the system.
    /// </summary>
    public class GetDetailsOfASpecificNationality
                        :   GetDetailsOfASpecificReferenceData< NationalityDetails, Nationality >,
                            IGetDetailsOfASpecificNationality
    {
        public GetDetailsOfASpecificNationality( IQueryRepository< Nationality > the_repository)
                        : base( the_repository ) {}
    }
}
