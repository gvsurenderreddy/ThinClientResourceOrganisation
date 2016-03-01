using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails
{

    public class EmployeePersonalDetails : EmployeeIdentity
    {
        public string title { get; set; }
        public string forename { get; set; }
        public string othername { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public string date_of_birth { get; set; }
        public string nationality { get; set; }
        public string birth_place { get; set; }
        public string ethnic_origin { get; set; }
    }

}