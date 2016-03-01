using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest
{
    public interface IGetUpdateBreakRequest
                        : IQuery<BreakIdentity,
                                 Response<UpdateBreakRequest>
                                > { }
}