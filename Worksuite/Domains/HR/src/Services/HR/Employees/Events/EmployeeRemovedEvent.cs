using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.Events {

    /// <summary>
    ///     Event published when an employee is removed from the system
    /// </summary>
    public class EmployeeRemovedEvent
                    : EmployeeIdentity {}
}