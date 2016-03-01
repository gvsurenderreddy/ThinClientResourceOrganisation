using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.events
{
   public sealed class SicknessCreatedEvent : EmployeeIdentity
    {
       public DateTime sickness_date { get; set; }
    }
}
