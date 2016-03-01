using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit {

    [TestClass]
    public class GetUpdateRelationshipRequest_will
                    : GetUpdateReferenceDataRequest_will<Relationship,UpdateRelationshipRequest,GetUpdateRelationshipRequestResponse,IGetUpdateRelationshipRequest> {  }

}