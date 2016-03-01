using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeQualifications
{
    public class EmployeeQualificationBuilder
                        : IEntityBuilder<EmployeeQualification>
    {
        public EmployeeQualification entity { get { return _employee_qualification; } }

        public EmployeeQualificationBuilder( EmployeeQualification the_employee_qualification )
        {
            Guard.IsNotNull( the_employee_qualification, "the_employee_qualification" );

            var employee_qualification_identity_provider = new IntIdentityProvider< EmployeeQualification >();

            _employee_qualification = new EmployeeQualification
            {
                id              = employee_qualification_identity_provider.next(),
                qualification   = the_employee_qualification.qualification
            };

        }

        public EmployeeQualificationBuilder qualification(Qualification value)
        {
            _employee_qualification.qualification = value;

            return this;
        }

        private readonly EmployeeQualification _employee_qualification;
    }
}