using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.Remove
{
    public class RemoveEmployeeDetails : EmployeeIdentity
    {
        public int title_id { get; set; }
        public string forename { get; set; }
        public string othername { get; set; }
        public string surname { get; set; }
        public int gender_id { get; set; }
        public string birth_place { get; set; }
        public string dateofbirth { get; set; }
    }
}
