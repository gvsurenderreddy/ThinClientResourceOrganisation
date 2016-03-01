using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Remove {

    [TestClass]
    public class Remove_will 
                    : CommandCommitedChangesSpecification<RemoveRelationshipRequest,RemoveRelationshipResponse, RemoveRelationshipFixture> {}

}