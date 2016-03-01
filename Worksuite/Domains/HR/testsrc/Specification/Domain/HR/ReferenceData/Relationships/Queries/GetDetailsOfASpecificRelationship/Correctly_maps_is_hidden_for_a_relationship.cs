using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Queries.GetDetailsOfASpecificRelationship
{
    [TestClass]
    public class Correctly_maps_is_hidden_for_a_gender
                    : Correctly_maps_is_hidden<Relationship, RelationshipBuilder, RelationshipDetails, GetDetailsOfASpecificRelationshipFixture> { }
}