using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeImage.Features.Edit
{
    [TestClass]
    public class Update_will
                    : CommandCommitedChangesSpecification<UpdateRequest, UpdateResponse, UpdateFixture> { }

    [TestClass]
    public class Update_employee_picture_details
                        : HRResponseCommandSpecification<UpdateRequest, UpdateResponse, UpdateFixture>
    {
        [TestMethod]
        public void should_raise_an_employee_image_details_updated_event()
        {
            fixture.execute_command();

            fixture
                .get_last_image_details_updated_event_for(fixture.entity)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created
                );
        }
    }
}