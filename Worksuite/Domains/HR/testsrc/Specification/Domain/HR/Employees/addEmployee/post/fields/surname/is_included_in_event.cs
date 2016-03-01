using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.surname
{
    [TestClass]
    public class EmployeeSurname_is_included_in_event : CommandPublishedEventSpecification<HRTestBootstrap, AddEmployeeRequestHandler_fixture>
    {
        public EmployeeSurname_is_included_in_event()
            : base(
                arrange: fixture => { },
                execute: fixture => fixture.execute_command(),
                event_was_published: fixture => fixture.get_employee_created_event_for(fixture.entity)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(created_event.surname == fixture.entity.surname),

                    nothing:
                        Assert.Fail // event was not created
                ))
        { }
    }
}
