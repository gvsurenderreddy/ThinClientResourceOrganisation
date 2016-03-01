using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfAllNationalities' interface
    ///     It will return all skills that are stored in the system.
    /// </summary>
    public class GetDetailsOfAllNationalities
                        :   GetDetailsOfAllReferenceData< Nationality, NationalityDetails >,
                            IGetDetailsOfAllNationalities
    {
        public GetDetailsOfAllNationalities( IQueryRepository< Nationality > the_repository )
                        : base( the_repository ) {}
    }
}