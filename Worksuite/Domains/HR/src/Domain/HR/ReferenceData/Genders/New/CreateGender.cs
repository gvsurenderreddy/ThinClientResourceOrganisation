using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.New {

    /// <summary>
    ///     Creates a new gender entry if the request is valid 
    /// </summary>
    public class CreateGender 
                    : CreateReferenceData<Gender,CreateGenderRequest,CreateGenderResponse>
                    , ICreateGender {

        public CreateGender 
                  ( IUnitOfWork the_unit_of_work
                  , Validator the_validator
                  , IEntityRepository<Gender> the_repository ) 
            : base
                  ( the_unit_of_work
                  , the_validator
                  , the_repository ) {}
    }
}