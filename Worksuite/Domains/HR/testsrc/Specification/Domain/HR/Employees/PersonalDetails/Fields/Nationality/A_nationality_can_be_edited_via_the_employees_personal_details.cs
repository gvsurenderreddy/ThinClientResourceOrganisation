using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Nationality
{
    [TestClass]
    public class A_nationality_can_be_edited_via_the_employees_personal_details
                        : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest,
                                                        UpdateEmployeePersonalDetailsResponse,
                                                        UpdateEmployeePersonalDetailsFixture,
                                                        Employee
                                                     >
    {
        protected override void set_expected_value(UpdateEmployeePersonalDetailsRequest request)
        {
            nationality = nationality_helper.add().entity;
            request.nationality_id = nationality.id;
        }

        protected override bool validate(UpdateEmployeePersonalDetailsRequest request, Employee entity)
        {
            return entity.nationality != null && entity.nationality.id == nationality.id;
        }

        protected override void test_setup()
        {
            base.test_setup();
            nationality_helper = DependencyResolver.resolve<NationalityHelper>();
        }

        private WorkSuite.HR.HR.ReferenceData.Nationality nationality;
        private NationalityHelper nationality_helper;
    }
}