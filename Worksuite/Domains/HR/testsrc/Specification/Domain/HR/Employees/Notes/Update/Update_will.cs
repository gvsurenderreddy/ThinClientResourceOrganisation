using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Update
{
    [TestClass]
    public class Update_will : HRSpecification
    {
        [TestMethod]
        public void update_was_called()
        {
            var req = new UpdateRequest
            {
                note = note.Notes,
                employee_id = employee.id,
                note_id = note.id,
            };

            var response = command.execute(req);
        }

        [TestMethod]
        public void update_without_any_errors()
        {
            var req = new UpdateRequest
            {
                note = note.Notes,
                employee_id = employee.id,
                note_id = note.id,
            };

            var response = command.execute(req);
            Assert.IsFalse(response.has_errors);
        }

        protected override void test_setup()
        {
            base.test_setup();

            command = DependencyResolver.resolve<IUpdate>();
            builder = new NoteBuilder(new Note());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

            setup_employee_note();
        }

        private void setup_employee_note()
        {
            note = builder.Notes("A description").entity;
            employee = emp_helper
                           .add().note(note)
                           .entity;
        }

        private IUpdate command;

        private NoteBuilder builder;
        private EmployeeHelper emp_helper;

        private Employee employee;
        private Note note;
    }

    [TestClass]
    public class Update_employee_note_details
                        : HRResponseCommandSpecification<UpdateRequest, UpdateResponse, UpdateNoteFixture>
    {
        [TestMethod]
        public void should_raise_an_employee_note_updated_event()
        {
            fixture.execute_command();

            fixture
                .get_last_note_updated_event_for(fixture.entity)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created

                );
        }
    }
}