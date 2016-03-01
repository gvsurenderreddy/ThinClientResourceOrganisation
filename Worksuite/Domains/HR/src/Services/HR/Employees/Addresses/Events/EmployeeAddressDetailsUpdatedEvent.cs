using WTS.WorkSuite.HR.HR.Employees.Addresses.New;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Events
{
    public class EmployeeAddressDetailsUpdatedEvent
                        : AddressIdentity
    {
        public string number_or_name { get; set; }

        public string line_one { get; set; }

        public string line_two { get; set; }

        public string line_three { get; set; }

        public string county { get; set; }

        public string country { get; set; }

        public string postcode { get; set; }

        public int priority { get; set; }
    }
}