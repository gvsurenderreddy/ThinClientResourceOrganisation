using System.Collections.Generic;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries
{
    /// <summary>
    ///     Get all the relationships that are eligible for the specified Emergency Contact
    /// </summary>
    public interface IGetDetailsOfRelationshipsEligibleForEmergencyContact :
        IQuery<EmergencyContactIdentity, Response<IEnumerable<RelationshipDetails>>>
    {

    }
}