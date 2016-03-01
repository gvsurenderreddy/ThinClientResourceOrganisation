using WTS.WorkSuite.HR.HR.ReferenceData;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR
{
    public class EmployeeSkill : BaseEntity<int>
    {
        public virtual Skill skill { get; set; }
        public virtual int priority { get; set; }
    }
}