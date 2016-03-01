
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.Remove
{
    public class RemoveEmployeeRequest : EmployeeIdentity
    {
        public string title { get; set; }

        public string forename { get; set; }

        public string othername { get; set; }

        public string surname { get; set; }

        public string gender { get; set; }

        public string birth_place { get; set; }

        public string dateofbirth { get; set; }

        public string employeeReference { get; set; }
    }
}
