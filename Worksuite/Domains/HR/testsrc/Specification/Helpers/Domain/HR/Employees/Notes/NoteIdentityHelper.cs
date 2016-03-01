using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes
{
    public class NoteIdentityHelper
    {
        public NoteIdentity get_identity()
        {
            return new NoteIdentity
            {
                employee_id = _employee.id,
                note_id = _note.id
            };
        }

        public NoteIdentityHelper()
        {
            _employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            _note_builder = DependencyResolver.resolve<NoteBuilder>();

            var employee_builder = _employee_helper.add();

            employee_builder
                .note(_note_builder.Notes("Some notes").entity)
                ;

            _employee = employee_builder.entity;

            _note = _employee
                        .Note
                        .Single()
                        ;
        }

        private Employee _employee;
        private EmployeeHelper _employee_helper;
        private Note _note;
        private NoteBuilder _note_builder;
    }
}