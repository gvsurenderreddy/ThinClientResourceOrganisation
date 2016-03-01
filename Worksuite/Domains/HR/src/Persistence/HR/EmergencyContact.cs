using WTS.WorkSuite.HR.HR.ReferenceData;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR
{
    public class EmergencyContact : BaseEntity<int>
    {
        public virtual string name { get; set; }
        public virtual Relationship relationship { get; set; }
        public virtual string primary_phone_number { get; set; }
        public virtual string other_phone_number { get; set; }
        public virtual int priority { get; set; }
    }
}