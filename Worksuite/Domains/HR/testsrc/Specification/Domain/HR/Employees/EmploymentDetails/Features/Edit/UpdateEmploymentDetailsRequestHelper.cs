using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit
{
    public class UpdateEmploymentDetailsRequestHelper
                        : IRequestHelper<UpdateEmploymentDetailsRequest>
    {
        public UpdateEmploymentDetailsRequest given_a_valid_request()
        {
            var job_title = _job_title_helper
                                .add()
                                .description("Business Analyst")
                                .entity
                                ;

            var location = _location_helper
                                .add()
                                .description("Bowker Vale")
                                .entity
                                ;

            var employee = _employee_helper
                                    .add()
                                    .employeeReference("ABC321")
                                    .employee_job_title(job_title)
                                    .employee_location(location)
                                    .entity
                                    ;

            return new UpdateEmploymentDetailsRequest
            {
                employee_id = employee.id,
                employeeReference = employee.employeeReference,
                job_title_id = job_title.id,
                location_id = location.id
            };
        }

        public UpdateEmploymentDetailsRequestHelper(EmployeeHelper the_employee_helper,
                                                    JobTitleHelper the_job_title_helper,
                                                    LocationHelper the_location_helper
                                                   )
        {
            _employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
            _job_title_helper = Guard.IsNotNull(the_job_title_helper, "the_job_title_helper");
            _location_helper = Guard.IsNotNull(the_location_helper, "the_location_helper");
        }

        private readonly EmployeeHelper _employee_helper;
        private readonly JobTitleHelper _job_title_helper;
        private readonly LocationHelper _location_helper;
    }
}