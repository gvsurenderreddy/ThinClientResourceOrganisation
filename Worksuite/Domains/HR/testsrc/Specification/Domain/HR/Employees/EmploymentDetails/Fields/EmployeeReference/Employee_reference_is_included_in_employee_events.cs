using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Fields.EmployeeReference {


    public class Employee_reference_is_included_in_employee_events {


        [TestClass]
        public class employee_employment_details_updated_event
                        : HRResponseCommandSpecification< UpdateEmploymentDetailsRequest, UpdateEmploymentDetailsResponse, UpdateEmploymentDetailsFixture > {

            [TestMethod]
            public void Employee_reference_is_included_in_the_employee_updated_event () {
                fixture.execute_command();

                fixture
                    .get_last_employee_employment_details_updated_event_for( fixture.entity )
                    .Match( 

                        has_value:
                            update_event => update_event.employee_reference.Should(  ).Be( fixture.entity.employeeReference ),

                        nothing:
                            () => { Assert.Fail( "event was not created"); }                                                 
                    );
            }
        }
    }
}