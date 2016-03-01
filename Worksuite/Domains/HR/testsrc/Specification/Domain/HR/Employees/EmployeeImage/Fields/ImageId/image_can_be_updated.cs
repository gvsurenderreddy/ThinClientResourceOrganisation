using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeImage.Features.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeImage.Fields.ImageId
{
    [TestClass]
    public class image_can_be_updated
                    : FieldIsUpdatedSpecification<UpdateRequest, UpdateResponse, UpdateFixture, Employee>
    {

        protected override void set_expected_value
                                    (UpdateRequest request)
        {

            request.image_id += 20;
        }

        protected override bool validate
                                    (UpdateRequest request
                                    , Employee entity)
        {

            return request.image_id == entity.image_id;
        }
    }
}