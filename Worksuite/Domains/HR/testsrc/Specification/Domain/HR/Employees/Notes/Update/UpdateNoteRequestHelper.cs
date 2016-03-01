using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Update
{
    internal class UpdateNoteRequestHelper
                            : IRequestHelper<UpdateRequest>
    {
        public UpdateRequest given_a_valid_request()
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

            return new UpdateRequest
            {
                employee_id = employee.id,
                note_id = note.id,
                note = "Something else",
            };
        }

        public UpdateNoteRequestHelper(EmployeeHelper the_employee_helper)
        {
            _employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
        }

        private EmployeeHelper _employee_helper;
    }
}