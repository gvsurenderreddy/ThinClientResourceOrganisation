using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Queries.GetDetailsOfASpecificGender {

    public class GetDetailsOfASpecificGenderFixture 
                    : GetDetailsOfASpecificReferenceDataFixture<Gender,GenderDetails,IGetDetailsOfASpecificGender,GenderBuilder,GetDetailsOfASpecificGenderHelper> {

        public GetDetailsOfASpecificGenderFixture 
                       ( GetDetailsOfASpecificGenderHelper the_request_builder
                       , IGetDetailsOfASpecificGender the_query ) 
                : base
                       ( the_request_builder
                       , the_query ) {}
    }

}