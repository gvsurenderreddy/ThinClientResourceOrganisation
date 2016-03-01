using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.ById;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.GetById
{
    [TestClass]
    public class Correctly_maps_the_fields
                            : HRSpecification
    {
        [TestMethod]
        public void employee_reference()
        {
            JobTitle job_title = _job_title_helper
                                    .add()
                                    .entity
                                    ;

            Location location = _location_helper
                                    .add()
                                    .entity
                                    ;

            Employee employee = _emplyee_helper
                                    .add()
                                    .employee_job_title(job_title)
                                    .employee_location(location)
                                    .entity
                                    ;

            Response<EmployeeEmploymentDetails> response = _get_employment_details_by_id.execute(new EmployeeEmploymentDetails
            {
                employee_id = employee.id,
                employeeReference = employee.employeeReference,
                job_description = employee.job_title.description,
                location_description = location.description
            });

            Assert.IsTrue(response.result.employeeReference == employee.employeeReference);
        }

        [TestMethod]
        public void employee_job_description()
        {
            JobTitle job_title = _job_title_helper
                                    .add()
                                    .entity
                                    ;

            Location location = _location_helper
                                    .add()
                                    .entity
                                    ;

            Employee employee = _emplyee_helper
                                    .add()
                                    .employee_job_title(job_title)
                                    .employee_location(location)
                                    .entity
                                    ;

            Response<EmployeeEmploymentDetails> response = _get_employment_details_by_id.execute(new EmployeeEmploymentDetails
            {
                employee_id = employee.id,
                employeeReference = employee.employeeReference,
                job_description = employee.job_title.description,
                location_description = location.description
            });

            Assert.IsTrue(response.result.job_description == employee.job_title.description);
        }

        [TestMethod]
        public void employee_location_description()
        {
            JobTitle job_title = _job_title_helper
                                    .add()
                                    .entity
                                    ;

            Location location = _location_helper
                                    .add()
                                    .entity
                                    ;

            Employee employee = _emplyee_helper
                                    .add()
                                    .employee_job_title(job_title)
                                    .employee_location(location)
                                    .entity
                                    ;

            Response<EmployeeEmploymentDetails> response = _get_employment_details_by_id.execute(new EmployeeEmploymentDetails
            {
                employee_id = employee.id,
                employeeReference = employee.employeeReference,
                job_description = employee.job_title.description,
                location_description = location.description
            });

            Assert.IsTrue(response.result.location_description == employee.location.description);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_employment_details_by_id = DependencyResolver.resolve<IGetEmploymentDetailsById>();
            _emplyee_helper = DependencyResolver.resolve<EmployeeHelper>();
            _job_title_helper = DependencyResolver.resolve<JobTitleHelper>();
            _location_helper = DependencyResolver.resolve<LocationHelper>();
        }

        private IGetEmploymentDetailsById _get_employment_details_by_id;
        private EmployeeHelper _emplyee_helper;
        private JobTitleHelper _job_title_helper;
        private LocationHelper _location_helper;
    }
}