using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Fields.Phone_number
{
    [TestClass]
    public class A_phone_can_be_edited_via_the_employees_contact_details
                    : FieldIsUpdatedSpecification<UpdateRequest, UpdateResponse, UpdateFixture, Employee>
    {
        protected override void set_expected_value
                                    (UpdateRequest request)
        {
            request.phone += "2";
        }

        protected override bool validate
                                    (UpdateRequest request
                                    , Employee entity)
        {
            return request.phone == entity.phone_number;
        }
    }
}