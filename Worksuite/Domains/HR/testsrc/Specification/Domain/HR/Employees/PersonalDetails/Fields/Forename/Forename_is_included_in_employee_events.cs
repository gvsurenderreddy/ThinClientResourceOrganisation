using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Forename {

    public class Forename_is_included_in_employee_events {


        [TestClass]
        public class employee_personal_details_updated_event
                        : HRResponseCommandSpecification <UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse,UpdateEmployeePersonalDetailsFixture> {

            [TestMethod]
            public void Forename_is_included_in_the_employee_personal_details_updated_event () {
                
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for( fixture.entity )
                    .Match(
                        
                        has_value:
                            updated_event => updated_event.forename.Should().Be( fixture.entity.forename ),

                        nothing:
                            () => { Assert.Fail(); }

                    );
            }
        }
    }
}