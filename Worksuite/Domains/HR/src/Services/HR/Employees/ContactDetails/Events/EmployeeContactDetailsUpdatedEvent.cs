using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events
{
    public class EmployeeContactDetailsUpdatedEvent
                        : EmployeeIdentity
    {
        public string phone_number { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }

        public string other { get; set; }
    }
}