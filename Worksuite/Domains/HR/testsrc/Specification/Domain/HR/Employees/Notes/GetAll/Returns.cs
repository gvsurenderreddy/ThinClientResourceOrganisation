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
    public class Returns : HRSpecification
    {
        [TestMethod]
        public void return_all_notes()
        {

            var notes_1 = note_builder.Notes("A description").entity;
           
            var employee = add_employee().note(notes_1).entity;
           
            var responce = query.execute(new EmployeeIdentity {employee_id = employee.id}).result;
            Assert.IsTrue(responce.Count() == 1);
        }

        [TestMethod]
        public void return_an_empty_set_when_there_are_no_notes()
        {
            var employee = add_employee().entity;
            Assert.IsTrue(!query.execute(new EmployeeIdentity { employee_id = employee.id }).result.Any());
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