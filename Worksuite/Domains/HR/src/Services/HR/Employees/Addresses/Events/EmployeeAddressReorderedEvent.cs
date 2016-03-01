using WTS.WorkSuite.HR.HR.Employees.Addresses.New;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Events
{
    /// <summary>
    ///     This is an abstract class that has all the common
    ///     properties for an Employee address reorder event
    /// </summary>
    public abstract class EmployeeAddressReorderedEvent
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

    /// <summary>
    ///     This is a specific implementation for auto reorder event, derived from employee address reordered event.
    /// </summary>
    public class EmployeeAddressAutoReorderedEvent
                        : EmployeeAddressReorderedEvent { }

    /// <summary>
    ///     This is a specific implementation for manual reorder event, derived from employee address reordered event.
    /// </summary>
    public class EmployeeAddressManualReorderedEvent
                        : EmployeeAddressReorderedEvent { }
}