using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.Query
{
    /// <summary>
    ///     HR query domains representation of an employee
    /// </summary>
    public class EmployeeView : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }
        public virtual string forename { get; set; }
        public virtual string surname { get; set; }
        public virtual string employee_reference { get; set; }
        public virtual int job_title_id { get; set; }
        public virtual string job_title { get; set; }
        public virtual int location_id { get; set; }
        public virtual string location { get; set; }
    }
}
