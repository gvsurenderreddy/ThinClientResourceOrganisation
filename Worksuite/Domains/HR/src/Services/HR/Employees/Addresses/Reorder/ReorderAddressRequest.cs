using WTS.WorkSuite.HR.HR.Employees.Addresses.New;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder
{
    public class ReorderAddressRequest : AddressIdentity
    {
        public int priority { get; set; }
    }
}
