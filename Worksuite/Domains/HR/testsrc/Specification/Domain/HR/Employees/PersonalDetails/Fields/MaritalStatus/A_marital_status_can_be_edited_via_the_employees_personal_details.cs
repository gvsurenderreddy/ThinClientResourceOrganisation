using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.MaritalStatus
{
    public class A_marital_status_can_be_edited_via_the_employees_personal_details
                        : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest,
                                                        UpdateEmployeePersonalDetailsResponse,
                                                        UpdateEmployeePersonalDetailsFixture,
                                                        Employee
                                                     >
    {
        protected override void set_expected_value
                                    (UpdateEmployeePersonalDetailsRequest request)
        {
            _marital_status = _marital_status_helper.add().entity;
            request.marital_status_id = _marital_status.id;
        }

        protected override bool validate
                                    (UpdateEmployeePersonalDetailsRequest request
                                    , Employee entity)
        {
            return entity.maritalStatus != null && entity.maritalStatus.id == _marital_status.id;
        }

        protected override void test_setup()
        {
            base.test_setup();
            _marital_status_helper = DependencyResolver.resolve<MaritalStatusHelper>();
        }

        private WorkSuite.HR.HR.ReferenceData.MaritalStatus _marital_status;
        private MaritalStatusHelper _marital_status_helper;
    }
}