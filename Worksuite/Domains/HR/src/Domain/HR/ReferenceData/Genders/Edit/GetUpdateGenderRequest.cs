using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit {

    public class GetUpdateGenderRequest 
                    : GetUpdateReferenceDataRequest<Gender,UpdateGenderRequest,GetUpdateGenderRequestResponse>
                    , IGetUpdateGenderRequest {

        public GetUpdateGenderRequest 
                     ( IEntityRepository<Gender> the_repository ) 
              : base 
                     ( the_repository ) {}
    }
}