using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Description {

    [TestClass]
    public class The_description_for_a_Relationship_is_sanatised_when_getting_an_update_request
            : The_description_is_sanatised_when_getting_an_update_request<Relationship,UpdateRelationshipRequest,GetUpdateRelationshipRequestResponse,IGetUpdateRelationshipRequest> {}


}