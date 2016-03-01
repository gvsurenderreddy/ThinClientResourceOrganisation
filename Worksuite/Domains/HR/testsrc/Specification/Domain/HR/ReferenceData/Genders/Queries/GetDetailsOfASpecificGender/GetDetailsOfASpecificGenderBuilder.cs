using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Queries.GetDetailsOfASpecificGender {

    public class GetDetailsOfASpecificGenderHelper
                    : GetDetailsOfASpecificReferenceDataRequestHelper<Gender,GenderBuilder>{

        public GetDetailsOfASpecificGenderHelper 
                       ( IEntityRepository<Gender> the_repository
                       , GenderBuilder the_builder ) 
                : base 
                       ( the_repository
                       , the_builder ) {}
    }

}