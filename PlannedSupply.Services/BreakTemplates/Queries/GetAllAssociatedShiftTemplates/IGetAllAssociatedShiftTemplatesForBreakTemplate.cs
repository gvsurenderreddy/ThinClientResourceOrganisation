using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllAssociatedShiftTemplates
{
    /// <summary>
    ///     Get all the shift templates that are associated with the specified shift break template.
    /// </summary>
    public interface IGetAllAssociatedShiftTemplatesForBreakTemplate
                            : IQuery<BreakTemplateIdentity,
                                     Response<IEnumerable<ShiftTemplateDetails>>
                                    > { }
}