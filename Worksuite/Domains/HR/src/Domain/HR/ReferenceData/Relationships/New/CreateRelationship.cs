using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New
{
    /// <summary>
    ///     Creates a new relationship entry if the request is valid 
    /// </summary>
    public class CreateRelationship
                    : CreateReferenceData<Relationship, CreateRelationshipRequest, CreateRelationshipResponse>
                    , ICreateRelationship
    {

        public CreateRelationship
                  (IUnitOfWork the_unit_of_work
                  , Validator the_validator
                  , IEntityRepository<Relationship> the_repository)
            : base
                  (the_unit_of_work
                  , the_validator
                  , the_repository) { }
    }
}