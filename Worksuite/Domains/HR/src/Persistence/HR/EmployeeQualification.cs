using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;

namespace WTS.WorkSuite.HR.HR
{
    public class EmployeeQualification
                        : BaseEntity<int>
    {
        public virtual Qualification qualification { get; set; }
    }
}