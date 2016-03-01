using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries {

    public class GetDetailsOfASpecificGender 
                    : GetDetailsOfASpecificReferenceData<GenderDetails,Gender> 
                    , IGetDetailsOfASpecificGender {

        public GetDetailsOfASpecificGender 
                    ( IQueryRepository<Gender> the_repository ) 
             : base
                    ( the_repository ) {}
    }
}