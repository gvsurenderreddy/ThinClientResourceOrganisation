using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.PlannedSupply.HR.Employee
{
    public class EmployeePlannedSupply : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }
    }
}
