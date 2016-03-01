using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New
{
    [TestClass]
    public class NewRelationship_will : CommandCommitedChangesSpecification<CreateRelationshipRequest, CreateRelationshipResponse, NewRelationshipFixture> { }
}