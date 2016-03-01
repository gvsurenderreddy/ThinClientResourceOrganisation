using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.SupplyShortage.Employees
{
    public class EmployeeSupplyShortage : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }
    }
}
