using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.employee_reference
{
    [TestClass]
    public class EmployeeReference_does_not_exceed_default_max_characters 
                : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<HRTestBootstrap, AddEmployeeRequestHandler_fixture>
    {
        public EmployeeReference_does_not_exceed_default_max_characters()
            : base(
                    set_request_field: (f, value) => f.request.employee_reference = value,
                    act: f => f.execute_command(),
                    error_was_identified: f => Assert.IsTrue(f.response.has_status<AddEmployeeServiceStatuses.EmployeeReferenceExceedsMaxCharacters>())
            )
        {
        }
    }
}
