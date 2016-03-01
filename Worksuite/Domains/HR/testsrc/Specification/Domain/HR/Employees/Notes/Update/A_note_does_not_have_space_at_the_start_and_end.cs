using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetById;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.HR.HR.Employees.Notes.GetById;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Update
{
    [TestClass]
    public class A_note_does_not_have_space_at_the_start_and_end : HRSpecification
    {
        [TestMethod]
        public void A_note_does_not_have_space_at_the_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdate>();
            var query = DependencyResolver.resolve<IGetNoteById>();

            var response = command.execute(new UpdateRequest
            {
                note = "   note     ",
                note_id = note.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new NoteIdentity
            {
                note_id = response.result.note_id,
                employee_id = response.result.employee_id
            });


            Assert.AreEqual("note", address_updated.result.note);
        }

        private void setup_employee_note()
        {
            note = builder.Notes("A description").entity;
            employee = emp_helper
                           .add().note(note)
                           .entity;
        }

        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAddressById>();
            command = DependencyResolver.resolve<IUpdate>();
            builder = new NoteBuilder(new Note());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

            setup_employee_note();
        }

        private IGetAddressById query;

        private IUpdate command;

        private NoteBuilder builder;
        private EmployeeHelper emp_helper;

        private Employee employee;
        private Note note;
    }
}