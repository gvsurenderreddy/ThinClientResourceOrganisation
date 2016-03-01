using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest
{
    /// <summary>
    ///     Creates the shift break request and fills it out with any default values.
    /// </summary>
    public interface IGetNewBreakRequest
                        : ICommand<BreakIdentity,
                                   NewBreakRequest
                                  > { }
}