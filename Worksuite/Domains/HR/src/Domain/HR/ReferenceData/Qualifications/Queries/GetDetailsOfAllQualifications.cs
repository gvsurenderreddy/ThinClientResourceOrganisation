using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries
{
    /// <summary>
    ///     Implements the 'IGetDetailsOfAllQualifications' interface
    ///     It will return all qualifications that are stored in the system.
    /// </summary>
    public class GetDetailsOfAllQualifications
                    : GetDetailsOfAllReferenceData< Qualification, QualificationDetails >,
                        IGetDetailsOfAllQualifications
    {
        public GetDetailsOfAllQualifications( IQueryRepository< Qualification > the_repository )
                        :   base( the_repository )
        {
        }
    }
}