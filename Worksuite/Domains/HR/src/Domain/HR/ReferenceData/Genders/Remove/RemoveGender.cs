using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove {

    public class RemoveGender 
                    : RemoveReferenceData<Gender,RemoveGenderRequest,RemoveGenderResponse>
                    , IRemoveGender {

        public RemoveGender 
                     ( IUnitOfWork the_unit_of_work
                     , IEntityRepository<Gender> the_title_repository ) 
              : base
                     ( the_unit_of_work
                     , the_title_repository ) {}
    }
}