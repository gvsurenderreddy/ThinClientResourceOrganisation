using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR
{
    public class EmployeeDocument: BaseEntity<int>
    {
        public virtual string name { get; set; }
        public virtual int document_id { get; set; }
        public virtual string description { get; set; }
        public virtual string md5_hash { get; set; }
        public virtual string content_type { get; set; }
    }
}