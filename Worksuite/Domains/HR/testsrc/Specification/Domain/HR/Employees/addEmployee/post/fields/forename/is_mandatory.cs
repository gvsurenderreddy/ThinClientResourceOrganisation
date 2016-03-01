using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.forename
{
    [TestClass]
    public class EmployeeForename_is_mandatory : MandatoryTextFieldSpecification<HRTestBootstrap, AddEmployeeRequestHandler_fixture>
    {
        public EmployeeForename_is_mandatory()
            : base(
                    set_request_field: (f, value) => f.request.forename = value,
                    act: f => f.execute_command(),
                    error_was_identified: f => Assert.IsTrue(f.response.has_status<AddEmployeeServiceStatuses.EmployeeForenameIsMandatory>())
            )
        {
        }
    }
}
