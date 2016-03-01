using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Forename {

    public class A_forename_is_mandatory {       
         

        [TestClass]
        public class Forename_is_cleared_when_editing_an_employee
                        : MandatoryTextFieldSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture> {

            public Forename_is_cleared_when_editing_an_employee ()
                    : base((request, value) => request.forename = value) { }
        }

    }
}