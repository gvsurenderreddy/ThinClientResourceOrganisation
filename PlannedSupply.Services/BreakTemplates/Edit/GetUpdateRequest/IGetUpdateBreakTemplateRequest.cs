using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Gets an update shift break template request.
    /// </summary>
    public interface IGetUpdateBreakTemplateRequest
                        : ICommand<BreakTemplateIdentity,
                                    Response<UpdateBreakTemplateRequest>
                                  > { }
}