using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR
{
    public class Note : BaseEntity<int>
    {
        public virtual string Notes { get; set; }
    }
}