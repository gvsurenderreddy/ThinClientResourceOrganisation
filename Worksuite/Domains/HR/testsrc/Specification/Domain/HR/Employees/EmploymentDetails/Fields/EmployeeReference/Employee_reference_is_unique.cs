using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Fields.EmployeeReference {


    public class Employee_reference_is_unique {

        [TestClass]
        public class employee_reference_unique_constraint_is_enforced_on_update 
                            : UniqueTextFieldSpecification< UpdateEmploymentDetailsRequest,
                                                            UpdateEmploymentDetailsResponse,
                                                            UpdateEmploymentDetailsFixture
                                                          > {


            protected override void create_entity_with_value
                                        ( string value ) {
                               
                // create an employee with passed in employee reference
                fixture
                    .create_employee()
                    .employeeReference( value )
                    ;
            }

            protected override void set_request_value
                                        ( string value ) {

                fixture.request.employeeReference = value;
            }

            protected override string value {
                get { return "ABC123"; }
            }

        }
    }
}
