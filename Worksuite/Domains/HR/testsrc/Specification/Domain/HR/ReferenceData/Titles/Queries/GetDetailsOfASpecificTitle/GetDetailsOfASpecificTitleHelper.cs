using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Queries.GetDetailsOfASpecificTitle {

    public class GetDetailsOfASpecificTitleHelper
                    : GetDetailsOfASpecificReferenceDataRequestHelper<Title,TitleBuilder>{

        public GetDetailsOfASpecificTitleHelper 
                       ( IEntityRepository<Title> the_repository
                       , TitleBuilder the_builder ) 
                : base 
                       ( the_repository
                       , the_builder ) {}
    }

}