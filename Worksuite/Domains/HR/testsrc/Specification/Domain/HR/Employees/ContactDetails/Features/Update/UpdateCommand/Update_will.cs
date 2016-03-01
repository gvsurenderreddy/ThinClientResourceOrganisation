using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.UpdateCommand
{
    [TestClass]
    public class Update_will
                    : CommandCommitedChangesSpecification<UpdateRequest, UpdateResponse, UpdateFixture> { }

    [TestClass]
    public class Update_employee_contact_details_will_publish_an_employee_contact_details_updated_event
                    : HRResponseCommandSpecification<UpdateRequest, UpdateResponse, UpdateFixture>
    {
        [TestMethod]
        public void will_raise_an_employee_contact_details_updated_event()
        {
            fixture.execute_command();

            fixture
                .get_last_contact_details_updated_event_for(fixture.entity)
                .Match(

                    has_value:
                        updated_event => Assert.IsTrue(true),   // event was created

                    nothing:
                        Assert.Fail // event was not created
                );
        }
    }
}