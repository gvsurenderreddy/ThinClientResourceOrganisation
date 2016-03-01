using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Remove
{
    public class RemoveNoteRequestHelper
                    : IRequestHelper<NoteIdentity>
    {
        public NoteIdentity given_a_valid_request()
        {
            //Create an Employee
            var employee = _employee_helper.add().entity;

            var note = new Note
            {
                id = 1,
                Notes = "Some notes"
            };

            employee
                .Note
                .Add(note)
                ;

            return new NoteIdentity
            {
                employee_id = employee.id,
                note_id = note.id,
            };
        }

        public RemoveNoteRequestHelper(EmployeeHelper the_employee_helper)
        {
            _employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
        }

        private EmployeeHelper _employee_helper;
    }
}