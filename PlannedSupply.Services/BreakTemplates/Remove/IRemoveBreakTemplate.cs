using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove
{
    public interface IRemoveBreakTemplate
                            : ICommand<BreakTemplateIdentity,
                                        RemoveBreakTemplateResponse
                                      > { }
}