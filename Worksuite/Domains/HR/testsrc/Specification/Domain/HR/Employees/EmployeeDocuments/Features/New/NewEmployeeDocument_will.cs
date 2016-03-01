using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.New
{
    [TestClass]
    public class NewEmployeeDocument_will : CommandCommitedChangesSpecification<NewEmployeeDocumentRequest, NewEmployeeDocumentResponse, NewEmployeeDocumentFixture> { }

    [TestClass]
    public class WhenAShiftCalendarPatternIsCreated
                    : HRSpecification
    {
        [TestMethod]
        public void that_should_raise_employee_document_uploaded_event()
        {
            fixture.execute_command();

            fixture
                .get_employee_document_uploaded_event_for( fixture.request )
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created
                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<NewEmployeeDocumentFixture>();
        }

        private NewEmployeeDocumentFixture fixture;
    }
}