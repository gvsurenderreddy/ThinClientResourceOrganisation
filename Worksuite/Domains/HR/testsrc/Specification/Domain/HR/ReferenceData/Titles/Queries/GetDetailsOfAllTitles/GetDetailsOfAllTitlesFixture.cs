using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Queries.GetDetailsOfAllTitles {

    public class GetDetailsOfAllTitlesFixture
                    : GetDetailsOfAllReferenceDataFixture<Title,TitleDetails,IGetDetailsOfAllTitles,TitleBuilder,FakeTitleRepository,TitleHelper> {


        public GetDetailsOfAllTitlesFixture 
                    ( TitleHelper the_helper
                    , IGetDetailsOfAllTitles the_query ) 
             : base 
                    ( the_helper
                    , the_query ) {}
    }
}