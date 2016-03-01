using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllEligibleForShiftTemplate
{
    /// <summary>
    ///     Get all the break templates that are eligible for the specified shift template, the criteria is:
    ///  the entry that the break template is currently assigned to the shift template regardless of its
    ///  hidden status, the not specified element (so that is can be cleared), and then
    /// all the reference data entries that are not hidden.
    /// </summary>
    public interface IGetDetailsOfBreakTemplatesEligibleForShiftTemplate
                            : IQuery<ShiftTemplateIdentity,
                                     Response<IEnumerable<BreakTemplateDetails>>
                                    > { }
}