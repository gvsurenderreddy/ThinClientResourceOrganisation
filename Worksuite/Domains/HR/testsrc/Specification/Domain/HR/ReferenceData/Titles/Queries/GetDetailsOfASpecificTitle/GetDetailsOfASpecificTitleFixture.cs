using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Queries.GetDetailsOfASpecificTitle {

    public class GetDetailsOfASpecificTitleFixture 
                    : GetDetailsOfASpecificReferenceDataFixture<Title,TitleDetails,IGetDetailsOfASpecificTitle,TitleBuilder,GetDetailsOfASpecificTitleHelper> {

        public GetDetailsOfASpecificTitleFixture 
                       ( GetDetailsOfASpecificTitleHelper the_request_builder
                       , IGetDetailsOfASpecificTitle the_query ) 
                : base
                       ( the_request_builder
                       , the_query ) {}
    }

}