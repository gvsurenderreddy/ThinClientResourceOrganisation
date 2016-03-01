using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.New
{
    public class NewNoteRequestHelper : IRequestHelper<NewNoteRequest>
    {
        public NewNoteRequestHelper(EmployeeHelper the_helper)
        {
            helper = Guard.IsNotNull(the_helper, "the_helper");
        }

        public NewNoteRequest given_a_valid_request()
        {
            //Create an Employee
            var employee = helper.add().entity;

            return new NewNoteRequest
            {
                note = "test note",
                employee_id = employee.id,
            };
        }
        private EmployeeHelper helper;
    }
}