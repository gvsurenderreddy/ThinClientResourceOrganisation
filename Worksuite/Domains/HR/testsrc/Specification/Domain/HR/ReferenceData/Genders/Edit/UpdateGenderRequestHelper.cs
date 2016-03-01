using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit {

    public class UpdateGenderRequestHelper 
                    : UpdateReferenceDataRequestBuilder<Gender,UpdateGenderRequest> {

        public UpdateGenderRequestHelper 
                        ( IEntityRepository<Gender> the_repository ) 
                : base 
                        ( the_repository ) {}
    }
}