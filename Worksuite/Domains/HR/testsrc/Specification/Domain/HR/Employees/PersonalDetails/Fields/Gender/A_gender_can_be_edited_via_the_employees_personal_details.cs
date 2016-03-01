using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Gender
{
    [TestClass]
    public class A_gender_can_be_edited_via_the_employees_personal_details
                        : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest,
                                                        UpdateEmployeePersonalDetailsResponse,
                                                        UpdateEmployeePersonalDetailsFixture,
                                                        Employee
                                                     >
    {
        protected override void set_expected_value
                                    (UpdateEmployeePersonalDetailsRequest request)
        {
            _gender = _gender_helper.add().entity;
            request.gender_id = _gender.id;
        }

        protected override bool validate
                                    (UpdateEmployeePersonalDetailsRequest request
                                    , Employee entity)
        {
            return entity.gender != null && entity.gender.id == _gender.id;
        }

        protected override void test_setup()
        {
            base.test_setup();
            _gender_helper = DependencyResolver.resolve<GenderHelper>();
        }

        private WorkSuite.HR.HR.ReferenceData.Gender _gender;
        private GenderHelper _gender_helper;
    }
}