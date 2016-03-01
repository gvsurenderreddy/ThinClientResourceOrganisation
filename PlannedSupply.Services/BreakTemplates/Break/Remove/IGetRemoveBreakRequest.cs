using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove
{
    public interface IGetRemoveBreakRequest
                        : IQuery<BreakIdentity,
                                   Response<RemoveBreakRequest>
                                  > { }
}