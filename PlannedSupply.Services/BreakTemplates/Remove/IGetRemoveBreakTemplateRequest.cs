using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove
{
    public interface IGetRemoveBreakTemplateRequest
                            : ICommand<BreakTemplateIdentity,
                                        Response<RemoveBreakTemplateRequest>> { }
}