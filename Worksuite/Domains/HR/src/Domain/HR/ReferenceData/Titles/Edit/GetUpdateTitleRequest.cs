using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit {

    public class GetUpdateTitleRequest 
                    : GetUpdateReferenceDataRequest<Title,UpdateTitleRequest,GetUpdateTitleRequestResponse>
                    , IGetUpdateTitleRequest {

        public GetUpdateTitleRequest 
                     ( IEntityRepository<Title> the_repository ) 
              : base 
                     ( the_repository ) {}
    }
}