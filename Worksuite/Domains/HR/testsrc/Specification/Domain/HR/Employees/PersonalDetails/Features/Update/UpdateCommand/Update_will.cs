using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand {


    public class update_personal_details_will {

        [TestClass]
        public class Update_employee_personal_details_will_commit_changes 
                        : CommandCommitedChangesSpecification<UpdateEmployeePersonalDetailsRequest,UpdateEmployeePersonalDetailsResponse,UpdateEmployeePersonalDetailsFixture> { }

        [TestClass]
        public class Update_employee_personal_details_will_publish_an_employee_personal_details_updated_event 
                        : HRResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture> {

            [TestMethod]
            public void will_raise_an_employee_created_event () {
            
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for( fixture.entity )
                    .Match( 

                        has_value:
                            created_event => Assert.IsTrue ( true ), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }
        }        
    }
}