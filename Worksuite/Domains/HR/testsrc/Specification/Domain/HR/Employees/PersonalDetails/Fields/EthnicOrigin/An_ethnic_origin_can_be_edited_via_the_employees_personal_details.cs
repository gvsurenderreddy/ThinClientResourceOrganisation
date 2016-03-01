using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.EthnicOrigin
{
    [TestClass]
    public class An_ethnic_origin_can_be_edited_via_the_employees_personal_details
                        : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest,
                                                        UpdateEmployeePersonalDetailsResponse,
                                                        UpdateEmployeePersonalDetailsFixture,
                                                        Employee
                                                     >
    {
        protected override void set_expected_value(UpdateEmployeePersonalDetailsRequest request)
        {
            _ethnic_origin = _ethnic_origin_helper.add().entity;
            request.ethnic_origin_id = _ethnic_origin.id;
        }

        protected override bool validate(UpdateEmployeePersonalDetailsRequest request, Employee entity)
        {
            return entity.ethnicOrigin != null && entity.ethnicOrigin.id == _ethnic_origin.id;
        }

        protected override void test_setup()
        {
            base.test_setup();
            _ethnic_origin_helper = DependencyResolver.resolve<EthnicOriginHelper>();
        }

        private WorkSuite.HR.HR.ReferenceData.EthnicOrigin _ethnic_origin;
        private EthnicOriginHelper _ethnic_origin_helper;
    }
}