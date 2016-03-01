using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Othernames {

    [TestClass]
    public class An_othername_can_be_edited_via_the_employees_personal_details 
                    : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture, Employee> {

        protected override void set_expected_value
                                    ( UpdateEmployeePersonalDetailsRequest request ) {

            request.othername += "m";
        }

        protected override bool validate
                                    ( UpdateEmployeePersonalDetailsRequest request
                                    , Employee entity ) {

            return request.othername == entity.othername;
        }
    }
}
