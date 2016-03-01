using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Surname {


    public class Surname_is_included_in_employee_events {

        [TestClass]
        public class employee_personal_details_updated_event
                        : HRResponseCommandSpecification <UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse,UpdateEmployeePersonalDetailsFixture> {

            [TestMethod]
            public void Surname_is_included_in_the_employee_personal_details_updated_event () {
                
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for( fixture.entity )
                    .Match(

                        has_value:
                            update_event => { update_event.surname.Should().Be( fixture.entity.surname ); },

                        nothing:
                            () => { Assert.Fail( "event was not created" ); }
                    );
            }
        }
    }
}