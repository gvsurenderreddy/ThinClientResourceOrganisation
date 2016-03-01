using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.New
{
    [TestClass]
    public class NewNote_will
                    : CommandCommitedChangesSpecification<NewNoteRequest, NewNoteResponse, NewNoteFixture> { }

    [TestClass]
    public class Create_employee_note_details
                        : HRResponseCommandSpecification<NewNoteRequest,
                            NewNoteResponse,
                            NewNoteFixture
                            >
    {
        [TestMethod]
        public void should_raise_an_employee_note_created_event()
        {
            fixture.execute_command();

            fixture
                .get_last_note_created_event_for(fixture.entity)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created.

                    nothing:
                        Assert.Fail // event was not created.

                );
        }
    }
}