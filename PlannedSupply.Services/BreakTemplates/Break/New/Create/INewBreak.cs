using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create
{
    /// <summary>
    ///     Creates a shift break and returns it's identity.
    ///
    ///     Validation:
    ///         'Starts_after' is a mandatory field and must be unique within a shift break template.
    /// </summary>
    public interface INewBreak
                        : IResponseCommand<NewBreakRequest,
                                           NewBreakResponse
                                          > { }
}