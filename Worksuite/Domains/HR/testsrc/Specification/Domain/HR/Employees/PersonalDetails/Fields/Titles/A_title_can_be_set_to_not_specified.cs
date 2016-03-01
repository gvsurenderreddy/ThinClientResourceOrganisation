using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Titles {

    [TestClass]
    public class A_title_can_be_set_to_not_specified
                    : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture, Employee> {


        protected override void set_expected_value ( UpdateEmployeePersonalDetailsRequest request ) {

            request.title_id = NotSpecified.Id;
        }

        protected override bool validate ( UpdateEmployeePersonalDetailsRequest request, Employee entity ) {
                
            return entity.title == null;
        }

    }

}