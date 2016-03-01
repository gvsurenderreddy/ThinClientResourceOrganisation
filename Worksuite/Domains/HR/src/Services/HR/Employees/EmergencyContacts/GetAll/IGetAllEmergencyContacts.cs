using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetAll
{
    public interface IGetAllEmergencyContacts : IQuery<EmployeeIdentity, Response<IEnumerable<EmergencyContactDetails>>> { }
}