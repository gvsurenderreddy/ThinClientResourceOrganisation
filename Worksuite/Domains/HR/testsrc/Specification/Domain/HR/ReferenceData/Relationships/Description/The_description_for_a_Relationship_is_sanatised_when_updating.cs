using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Description {

    [TestClass]
    public class The_description_for_a_Relationship_is_sanatised_when_updating
        : The_description_is_sanatised_when_updating<Relationship,UpdateRelationshipRequest,UpdateRelationshipResponse,IUpdateRelationship,UpdateRelationshipFixture> {}
}