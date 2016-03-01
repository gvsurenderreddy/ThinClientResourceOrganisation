using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post
{
    [TestClass]
    public class AddEmployeeRequestHandler_will_commit_changes : CommandCommitedChangesSpecification<HRTestBootstrap, AddEmployeeRequestHandler_fixture>
    {
        public AddEmployeeRequestHandler_will_commit_changes()
            : base(
                arrange: fixture => { },
                execute: fixture => fixture.execute_command(),
                commit_was_called: fixture => Assert.IsTrue(fixture.changes_were_committed)
                )
        {

        }
    }

    [TestClass]
    public class AddEmployeeRequestHandler_will_publish_event : CommandPublishedEventSpecification<HRTestBootstrap
                                                                                                , AddEmployeeRequestHandler_fixture>
    {
        public AddEmployeeRequestHandler_will_publish_event()
            : base(
                arrange: fixture => { },
                execute: fixture => fixture.execute_command(),
                event_was_published: fixture => fixture.get_employee_created_event_for(fixture.entity)
                                                        .Match(

                                                            has_value:
                                                                created_event => Assert.IsTrue(true), // event was created

                                                            nothing:
                                                                Assert.Fail // event was not created
                                                        )) 
        { }
    }
}