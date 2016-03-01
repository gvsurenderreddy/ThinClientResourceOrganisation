using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Queries.GetAll
{
    /// <summary>
    ///     Get details of all shift breaks of a shift break template.
    /// </summary>
    public interface IGetDetailsOfAllBreaks
                        : IQuery<BreakTemplateIdentity,
                                 Response<IEnumerable<BreakDetails>>
                                > { }
}