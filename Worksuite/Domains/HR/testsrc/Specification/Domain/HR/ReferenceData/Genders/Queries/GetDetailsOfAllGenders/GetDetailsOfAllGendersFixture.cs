using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Queries.GetDetailsOfAllGenders {

    public class GetDetailsOfAllGendersFixture
                    :   GetDetailsOfAllReferenceDataFixture<Gender,GenderDetails,IGetDetailsOfAllGenders,GenderBuilder,FakeGenderRepository,GenderHelper> {

        public GetDetailsOfAllGendersFixture 
                     ( GenderHelper the_helper
                     , IGetDetailsOfAllGenders the_query ) 
              : base 
                     ( the_helper
                     , the_query ) {}

    }


}