using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness
{
    public class SicknessIdentity : EmployeeIdentity
    {
        public DateTime? sickness_date { get; set; }
    }
}

