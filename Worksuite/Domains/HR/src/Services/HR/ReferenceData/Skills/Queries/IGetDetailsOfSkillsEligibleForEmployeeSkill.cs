using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries
{
    /// <summary>
    ///     Get all the skills that are eligible for assigning to an employee
    /// </summary>
    public interface IGetDetailsOfSkillsEligibleForEmployee : IQuery<EmployeeIdentity, Response<IEnumerable<SkillDetails>>>
    {

    }
}