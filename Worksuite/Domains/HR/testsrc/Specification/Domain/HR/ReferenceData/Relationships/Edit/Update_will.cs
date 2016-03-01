using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit {

    [TestClass]
    public class Update_will 
                    : CommandCommitedChangesSpecification<UpdateRelationshipRequest, UpdateRelationshipResponse, UpdateRelationshipFixture> {}

    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Relationship,
                                                                        UpdateRelationshipRequest,
                                                                        UpdateRelationshipResponse,
                                                                        IUpdateRelationship,
                                                                        RelationshipUpdatedEvent,
                                                                        UpdateRelationshipEventFixture>
    {

    }

}