using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.PlaceOfBirth
{
    public class A_place_of_birth_has_a_maximum_number_of_charactes {

        [TestClass]
        public class verify_on_edit
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification
                            <UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture> {

            public verify_on_edit() : base((request, value) => request.birth_place = value) {}
        }
    }
}
