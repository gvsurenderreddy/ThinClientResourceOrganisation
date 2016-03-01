using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries {

    /// <summary>
    ///     Get all the entires that are eligible for the specified employee, the criteria is:
    ///  the entry that the employee is currently assigned to the employee regardless of its 
    ///  hidden status, the not specified element (so that is can be cleared), and then
    /// all the reference data entries that are not hidden.
    /// </summary>
    /// <remarks>
    ///     This does not handle non-mandatory fields, that is the same query with out the
    /// not specified element but this is a more complex scenario that we have not run into yet.
    /// </remarks>
    public interface IGetDetailsOfReferencDataEligibleForEmployee<D> 
                       :  IQuery<EmployeeIdentity,Response<IEnumerable<D>>>
               where D : ReferenceDataDetails { }

}