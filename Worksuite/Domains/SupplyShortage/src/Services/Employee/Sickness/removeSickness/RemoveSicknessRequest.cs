using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness
{
    public class RemoveSicknessRequest : EmployeeIdentity
    {
        public DateTime sickness_date { get; set; }
    }
}
