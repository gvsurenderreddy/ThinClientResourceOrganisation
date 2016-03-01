using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries {

    /// <summary>
    ///     Get the details of a specific title
    /// </summary>
    public class GetDetailsOfASpecificTitle
                    : GetDetailsOfASpecificReferenceData<TitleDetails, Title>
                    , IGetDetailsOfASpecificTitle {

        public GetDetailsOfASpecificTitle 
                    ( IQueryRepository<Title> the_repository )
             : base
                    ( the_repository ) {}
        
    }
}