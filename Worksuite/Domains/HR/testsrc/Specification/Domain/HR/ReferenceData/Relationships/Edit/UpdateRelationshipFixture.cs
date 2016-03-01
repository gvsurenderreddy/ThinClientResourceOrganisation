using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit {

    public class UpdateRelationshipFixture 
                    : UpdateRefereceDataFixture<Relationship, UpdateRelationshipRequest,UpdateRelationshipResponse,IUpdateRelationship> {

        public UpdateRelationshipFixture 
                       ( IUpdateRelationship the_command
                       , IRequestHelper<UpdateRelationshipRequest> the_request_builder
                       , IEntityRepository<Relationship> the_repository ) 
                : base ( the_command
                       , the_request_builder
                       , the_repository ) {}

    }  
}