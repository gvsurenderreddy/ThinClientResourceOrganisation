using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit {


    public class UpdateEmployeePersonalDetailsRequest 
                    : EmployeeIdentity {

        public int title_id { get; set; }
        public string forename { get; set; }
        public string othername { get; set; }        
        public string surname { get; set; }
        public int gender_id { get; set; }
        public int marital_status_id { get; set; }
        public DateRequest date_of_birth {  get; set; }
        public int nationality_id { get; set; }
        public string birth_place { get; set; }
        public int ethnic_origin_id { get; set; }
    }
}