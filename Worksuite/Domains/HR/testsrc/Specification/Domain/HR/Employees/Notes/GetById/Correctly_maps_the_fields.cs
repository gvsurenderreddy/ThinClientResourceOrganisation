using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.GetById;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.GetById
{
    [TestClass]
    public class Correctly_maps_the_fields : HRSpecification
    {
        [TestMethod]
        public void note_fields_are_mapped()
        {
            var note = builder.Notes("A description");
            var employee = emp_helper
                           .add().note(note.entity)
                           .entity;

            var response = query.execute(new NoteIdentity { employee_id = employee.id, note_id = note.entity.id });

            Assert.IsTrue(response.result.note == builder.entity.Notes);
        }


        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetNoteById>();

            builder = new NoteBuilder(new Note());


            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

        }

        private IGetNoteById query;
        private NoteBuilder builder;
        private EmployeeHelper emp_helper;

    }
}