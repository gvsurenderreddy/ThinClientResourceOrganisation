using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries {

    /// <summary>
    ///     Implements the <see cref="IGetDetailsOfAllGenders"/> query.
    /// It will return all genders that are stored in the system.
    /// </summary>
    public class GetDetailsOfAllGenders
                    : GetDetailsOfAllReferenceData<Gender,GenderDetails>
                    , IGetDetailsOfAllGenders {

        public GetDetailsOfAllGenders 
                     ( IQueryRepository<Gender> the_repository ) 
              : base 
                     ( the_repository ) {}

    }
}