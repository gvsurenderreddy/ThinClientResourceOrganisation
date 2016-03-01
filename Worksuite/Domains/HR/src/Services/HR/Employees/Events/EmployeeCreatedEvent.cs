using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.Events
{
    /// <summary>
    ///     Event published when an employee is created in the system
    /// </summary>
    public sealed class EmployeeCreatedEvent
                                : EmployeeIdentity
    {
        public string employee_reference { get; set; }

        public string forename { get; set; }

        public string surname { get; set; }
    }
}