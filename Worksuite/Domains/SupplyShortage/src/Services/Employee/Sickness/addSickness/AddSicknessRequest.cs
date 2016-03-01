using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness
{
    public class AddSicknessRequest : EmployeeIdentity
    {
        public DateRequest sickness_date { get; set; }
    }
}
