﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Description {

    [TestClass]
    public class A_description_for_a_Relationship_can_not_be_duplicated_is_validated_on_update
                    : A_description_can_not_be_duplicated_is_validated_on_update<Relationship,UpdateRelationshipRequest, UpdateRelationshipResponse,IUpdateRelationship,UpdateRelationshipFixture> {}

}