using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.New {

    /// <summary>
    ///     Creates a new title entry if the request is valid 
    /// </summary>
    public class CreateTitle 
                    : CreateReferenceData<Title,CreateTitleRequest,CreateTitleResponse>
                    , ICreateTitle {

        public CreateTitle 
                  ( IUnitOfWork the_unit_of_work
                  , Validator the_validator
                  , IEntityRepository<Title> the_repository ) 
            : base
                  ( the_unit_of_work
                  , the_validator
                  , the_repository ) {}
    }
}