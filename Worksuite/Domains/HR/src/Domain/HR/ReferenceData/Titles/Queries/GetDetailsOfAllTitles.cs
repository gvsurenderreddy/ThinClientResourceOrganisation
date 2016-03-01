using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries {

    public class GetDetailsOfAllTitles 
                    : GetDetailsOfAllReferenceData<Title,TitleDetails>
                    , IGetDetailsOfAllTitles {

        public GetDetailsOfAllTitles 
                    ( IQueryRepository<Title> the_repository ) 
             : base
                    ( the_repository ) {}

    }
}