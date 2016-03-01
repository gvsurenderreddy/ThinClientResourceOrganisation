using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Update {

    [TestClass]
    public class Update_will 
                    : CommandCommitedChangesSpecification<UpdateRequest, UpdateResponse, UpdateFixture> {}

    [TestClass]
    public class update_emergency_contact_details
                    : HRResponseCommandSpecification<UpdateRequest
                                                    ,UpdateResponse
                                                    ,UpdateFixture>
    {

        [TestMethod]
        public void should_raise_an_emergence_contact_details_update_event()
        {
            fixture.execute_command();

          fixture
          .get_last_emergency_contact_updated_event_for(fixture.entity)
          .Match(

              has_value:
                  created_event => Assert.IsTrue(true),

              nothing:
                  Assert.Fail 

          );

        }
    }
}