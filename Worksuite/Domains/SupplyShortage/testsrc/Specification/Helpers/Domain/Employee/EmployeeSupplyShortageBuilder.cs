using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee
{
    public class EmployeeSupplyShortageBuilder : IEntityBuilder<EmployeeSupplyShortage>
    {
        public EmployeeSupplyShortageBuilder( EmployeeSupplyShortage employee_supply_shortage )
        {
            this.employee_supply_shortage = Guard.IsNotNull( employee_supply_shortage, "employee_supply_shortage" );
        }

        public EmployeeSupplyShortageBuilder set_employee_id( int employee_id )
        {
            Guard.IsNotNull( employee_supply_shortage, "employee_supply_shortage" );

            employee_supply_shortage.employee_id = employee_id;

            return this;
        }

        public EmployeeSupplyShortage entity { get { return employee_supply_shortage; } }

        private readonly EmployeeSupplyShortage employee_supply_shortage;

    }
}
