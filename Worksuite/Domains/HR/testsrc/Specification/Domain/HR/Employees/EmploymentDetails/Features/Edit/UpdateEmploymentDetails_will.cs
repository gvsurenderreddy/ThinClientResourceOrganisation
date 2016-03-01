using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit
{
    [TestClass]
    public class UpdateEmploymentDetails_will
                        : CommandCommitedChangesSpecification<UpdateEmploymentDetailsRequest,
                                                                UpdateEmploymentDetailsResponse,
                                                                UpdateEmploymentDetailsFixture
                                                             > { }

    [TestClass]
    public class Get_update_employment_details_request_should
                        : HRSpecification
    {
        [TestMethod]
        public void employee_id_is_correctly_mapped()
        {
            update_employment_details_request.employee_id.Should().Be(employee.id);
        }

        [TestMethod]
        public void employee_reference_is_correctly_mapped()
        {
            update_employment_details_request.employeeReference.Should().Be(employee.employeeReference);
        }

        [TestMethod]
        public void employee_job_title_id_is_correctly_mapped()
        {
            update_employment_details_request.job_title_id.Should().Be(employee.job_title.id);
        }

        [TestMethod]
        public void employee_location_id_is_correctly_mapped()
        {
            update_employment_details_request.location_id.Should().Be(employee.location.id);
        }

        protected override void test_setup()
        {
            base.test_setup();

            var emplyee_helper = DependencyResolver.resolve<EmployeeHelper>();
            var get_update_employment_details_request = DependencyResolver.resolve<IGetUpdateEmploymentDetailsRequest>();
            job_title_helper = DependencyResolver.resolve<JobTitleHelper>();
            location_helper = DependencyResolver.resolve<LocationHelper>();

            var job_title = job_title_helper
                                .add()
                                .description("Software Engineer")
                                .entity;

            var location = location_helper
                                .add()
                                .description("Bowker Vale")
                                .entity
                                ;

            employee = emplyee_helper
                            .add()
                            .employeeReference("A reference")
                            .employee_job_title(job_title)
                            .employee_location(location)
                            .entity
                            ;

            update_employment_details_request = get_update_employment_details_request
                                                    .execute(new EmployeeEmploymentDetails
                                                    {
                                                        employee_id = employee.id,
                                                        employeeReference = employee.employeeReference,
                                                        job_description = job_title.description,
                                                        location_description = location.description
                                                    })
                                                    .result
                                                    ;
        }

        private UpdateEmploymentDetailsRequest update_employment_details_request;
        private Employee employee;
        private JobTitleHelper job_title_helper;
        private LocationHelper location_helper;
    }
}