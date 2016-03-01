using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Notes.GetAll;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.GetAll
{
    [TestClass]
    public class Correctly_maps_the_fields : HRSpecification
    {
        [TestMethod]
        public void maps_the_employees_notes()
        {
            var notes = note_builder.Notes("A description").entity;
            var employee = add_employee()
                              .forename("Fred")
                              .note(notes)
                              .entity
                              ;

         var response =  query.execute(new EmployeeIdentity {employee_id = employee.id}).result.First();
         Assert.AreEqual(response.note,notes.Notes);
        }

        [TestMethod]
        public void maps_the_employees_notes_id()
        {
            var notes = note_builder.Notes("A description").entity;
            var employee = add_employee()
                              .forename("Fred")
                              .note(notes)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();
            Assert.AreEqual(response.note_id, notes.id);
        }

        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAllNotes>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
            note_builder = new NoteBuilder(new Note());
         
        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        private NoteBuilder note_builder;
        protected IGetAllNotes query;
        protected IEntityRepository<Employee> repository;
    }
}