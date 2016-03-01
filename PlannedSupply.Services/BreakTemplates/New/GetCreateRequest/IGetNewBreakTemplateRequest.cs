using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.New.GetCreateRequest
{
    /// <summary>
    ///     Creates an add shift break template request and fills it out with any default values.
    ///
    ///     Default values:
    ///         Currently there are no default values for any of the add shift break template request fields.
    /// </summary>
    public interface IGetNewBreakTemplateRequest
                        : ICommand<NewBreakTemplateRequest> { }
}