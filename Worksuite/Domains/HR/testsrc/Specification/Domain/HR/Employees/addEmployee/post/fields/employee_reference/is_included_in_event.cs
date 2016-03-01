using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.employee_reference
{
    [TestClass]
    public class EmployeeReference_is_included_in_event : CommandPublishedEventSpecification<HRTestBootstrap, AddEmployeeRequestHandler_fixture>
    {
        public EmployeeReference_is_included_in_event()
            : base(
                arrange: fixture => { },
                execute: fixture => fixture.execute_command(),
                event_was_published: fixture => fixture.get_employee_created_event_for(fixture.entity)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(created_event.employee_reference == fixture.entity.employeeReference),

                    nothing:
                        Assert.Fail // event was not created
                ))
        { }
    }
}
