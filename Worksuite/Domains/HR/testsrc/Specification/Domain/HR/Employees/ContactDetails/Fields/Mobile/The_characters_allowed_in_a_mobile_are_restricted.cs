using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Fields.Mobile
{
    public class The_characters_allowed_in_a_mobile_are_restricted
    {

        [TestClass]
        public class verify_on_edit
            : IsAMobileSpecification<UpdateRequest, UpdateResponse, EmployeeIdentity, UpdateFixture>
        {

            public verify_on_edit()
                : base((request, value) => request.mobile = value, request => request.mobile) { }
        }

    }
}
