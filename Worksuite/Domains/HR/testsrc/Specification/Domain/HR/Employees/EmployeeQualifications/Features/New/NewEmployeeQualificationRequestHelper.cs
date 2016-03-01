using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.New
{
    public class NewEmployeeQualificationRequestHelper
                        : IRequestHelper<NewEmployeeQualificationRequest>
    {
        public NewEmployeeQualificationRequest given_a_valid_request()
        {
            var qualification = _qualification_helper
                                        .add()
                                        .description("qualification")
                                        .entity
                                        ;

            var employee = _employee_helper
                                .add()
                                .entity;

            return new NewEmployeeQualificationRequest
            {
                employee_id = employee.id,
                qualification_id = qualification.id
            };
        }

        public NewEmployeeQualificationRequestHelper(  EmployeeHelper the_employee_helper,
                                                        QualificationHelper the_qualification_helper
                                                     )
        {
            _employee_helper        = Guard.IsNotNull( the_employee_helper, "the_employee_helper" );
            _qualification_helper   = Guard.IsNotNull( the_qualification_helper, "the_qualification_helper" );
        }

        private EmployeeHelper _employee_helper;
        private QualificationHelper _qualification_helper;
    }
}