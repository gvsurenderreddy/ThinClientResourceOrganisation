using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.HR.Employees.Notes.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Remove
{
    [TestClass]
    public class RemoveNote_will : HRSpecification
    {
        [TestMethod]
        public void note_is_deleted()
        {
            var note = builder.Notes("A description").entity;
            var employee = emp_helper
                           .add()
                           .note(note)
                           .entity
                            ;

            var response = command.execute(new NoteIdentity { employee_id = employee.id, note_id = note.id });
        }

        protected override void test_setup()
        {
            builder = new NoteBuilder(new Note());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();
            command = DependencyResolver.resolve<IRemove>();
        }

        private IRemove command;
        private EmployeeHelper emp_helper;
        private NoteBuilder builder;
    }

    [TestClass]
    public class Remove_employee_note_details
                        : HRSpecification
    {
        [TestMethod]
        public void should_raise_an_employee_note_removed_event()
        {
            fixture.execute_command();

            fixture
                .get_last_note_removed_event_for(fixture.remove_request)
                .Match(

                    has_value:
                        removed_event => { },

                    nothing:
                        () => Assert.Fail("An EmployeeNoteRemoveEvent was not published")

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<RemoveNoteFixture>();
        }

        private RemoveNoteFixture fixture;
    }
}