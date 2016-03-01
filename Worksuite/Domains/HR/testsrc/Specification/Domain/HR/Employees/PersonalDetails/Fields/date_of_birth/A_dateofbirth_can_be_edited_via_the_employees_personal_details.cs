using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.date_of_birth {

    [TestClass]
    public class A_dateofbirth_can_be_edited_via_the_employees_personal_details 
                    : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture, Employee> {

        protected override void set_expected_value
                                    ( UpdateEmployeePersonalDetailsRequest request ) {

            request.date_of_birth.year = "1989";
            request.date_of_birth.month = "8";
            request.date_of_birth.day = "4";
        }

        protected override bool validate
                                    ( UpdateEmployeePersonalDetailsRequest request
                                    , Employee entity ) {

            return request.date_of_birth.year == entity.dateofbirth.Value.Year.ToString() 
                && request.date_of_birth.month == entity.dateofbirth.Value.Month.ToString() 
                && request.date_of_birth.day == entity.dateofbirth.Value.Day.ToString();
        }
    }
}
