using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Notes.GetById;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.New
{

    [TestClass]
    public class A_note_does_not_have_space_at_the_start_and_end : HRSpecification
    {
        private EmployeeHelper helper;

        [TestMethod]
        public void A_note_does_not_have_space_at_the_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<INewNote>();
            var query = DependencyResolver.resolve<IGetNoteById>();
            var employee = helper.add().entity;
            var responce_old = command.execute(new NewNoteRequest
            {
                note = "     test         ",
                employee_id = employee.id
            });

            var responce = query.execute(new NoteIdentity
            {
                note_id = responce_old.result.note_id,
                employee_id = responce_old.result.employee_id
            });


            Assert.AreEqual(responce.result.note, "test");
        }

        protected override void test_setup()
        {
            helper = DependencyResolver.resolve<EmployeeHelper>();
        }
    }
}