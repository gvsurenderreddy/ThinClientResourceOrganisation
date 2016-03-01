using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {

        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<  Relationship,
                                                                                                            CreateRelationshipRequest,
                                                                                                            CreateRelationshipResponse,
                                                                                                            ICreateRelationship,
                                                                                                            NewRelationshipFixture
                                                                                                         > { }


        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  Relationship,
                                                                                                            UpdateRelationshipRequest,
                                                                                                            UpdateRelationshipResponse,
                                                                                                            IUpdateRelationship,
                                                                                                            UpdateRelationshipFixture
                                                                                                         > { }
    }
}