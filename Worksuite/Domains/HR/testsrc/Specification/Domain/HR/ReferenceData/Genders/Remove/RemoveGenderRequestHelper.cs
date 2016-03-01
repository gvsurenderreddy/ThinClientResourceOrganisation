using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Remove {

    public class RemoveGenderRequestHelper 
                    : RemoveReferenceDataRequestBuilder<Gender,RemoveGenderRequest> {

        public RemoveGenderRequestHelper 
                        ( IEntityRepository<Gender> the_repository ) 
                : base 
                        ( the_repository ) {}
    }
}