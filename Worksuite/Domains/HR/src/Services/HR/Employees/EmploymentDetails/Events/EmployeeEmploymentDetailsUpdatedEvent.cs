using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events
{
    /// <summary>
    ///     Event that is fired when an employee's employment
    /// details are updated.  It contains the state of the employment
    /// details after update has been successfully applied.
    /// </summary>
    public class EmployeeEmploymentDetailsUpdatedEvent
                    : EmployeeIdentity
    {
        public string employee_reference { get; set; }

        public int? job_title_id { get; set; }

        public string job_title_description { get; set; }

        public int? location_id { get; set; }

        public string location_description { get; set; }
    }
}