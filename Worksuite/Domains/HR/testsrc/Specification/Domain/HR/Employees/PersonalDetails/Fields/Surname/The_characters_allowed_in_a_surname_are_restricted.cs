using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Surname {

    public class The_characters_allowed_in_a_surname_are_restricted {

        [TestClass]
        public class verify_on_edit 
                        : IsAPersonsNameSpecification<UpdateEmployeePersonalDetailsRequest,UpdateEmployeePersonalDetailsResponse,UpdateEmployeePersonalDetailsFixture> {

            public verify_on_edit ( )
                    : base( (request, value) => request.surname = value, request => request.forename  ) {}
        }
    }
}