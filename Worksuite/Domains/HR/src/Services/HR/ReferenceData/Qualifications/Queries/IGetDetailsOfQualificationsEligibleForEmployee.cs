using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries
{
    /// <summary>
    ///     Get all the qualifications that are eligible for assigning to an employee.
    /// </summary>
    public interface IGetDetailsOfQualificationsEligibleForEmployee
                                : IQuery<   EmployeeIdentity,
                                            Response< IEnumerable< QualificationDetails > >
                                        > {}
}