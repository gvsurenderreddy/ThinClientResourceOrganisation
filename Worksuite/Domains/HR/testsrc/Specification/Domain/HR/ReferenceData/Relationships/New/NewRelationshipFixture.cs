using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New {

    public class NewRelationshipFixture
                    : NewReferenceDataFixture<Relationship, CreateRelationshipRequest, CreateRelationshipResponse, ICreateRelationship> {

        public NewRelationshipFixture 
                       ( ICreateRelationship the_command
                       , IRequestHelper<CreateRelationshipRequest> the_request_builder
                       , IEntityRepository<Relationship> the_repository ) 
                : base ( the_command
                       , the_request_builder
                       , the_repository ) {}

    }
}