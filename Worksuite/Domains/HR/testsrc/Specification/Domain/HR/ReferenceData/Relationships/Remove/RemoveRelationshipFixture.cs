using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Remove {

    public class RemoveRelationshipFixture
                    : RemoveRefereceDataFixture<RemoveRelationshipRequest,RemoveRelationshipResponse,IRemoveRelationship> {

        public RemoveRelationshipFixture 
                       ( IRemoveRelationship the_command
                       , IRequestHelper<RemoveRelationshipRequest> the_request_builder ) 
                : base ( the_command
                       , the_request_builder ) {}

    }

}