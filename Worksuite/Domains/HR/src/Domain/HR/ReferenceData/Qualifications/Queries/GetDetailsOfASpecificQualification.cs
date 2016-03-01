using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfASpecificQualification' interface
    ///     It will return a specific qualification that is stored in the system.
    /// </summary>
    public class GetDetailsOfASpecificQualification
                        : GetDetailsOfASpecificReferenceData< QualificationDetails, Qualification >,
                            IGetDetailsOfASpecificQualification
    {
        public GetDetailsOfASpecificQualification( IQueryRepository< Qualification > the_repository )
                        :   base( the_repository ) {}
    }
}