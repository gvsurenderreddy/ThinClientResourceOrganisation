using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.surname
{
    [TestClass]
    public class EmployeeSurname_is_a_valid_persons_name : IsAPersonsNameSpecification<HRTestBootstrap, AddEmployeeRequestHandler_fixture>
    {
        public EmployeeSurname_is_a_valid_persons_name()
            : base(
                    set_request_field: (f, value) => f.request.surname = value,
                    act: f => f.execute_command(),
                    error_was_identified: f => Assert.IsTrue(f.response.has_status<AddEmployeeServiceStatuses.EmployeeSurnameHasInvalidCharacters>()),
                    no_errors_identified: f => Assert.IsTrue(f.response.has_errors() == false)
            )
        {
        }
    }
}
