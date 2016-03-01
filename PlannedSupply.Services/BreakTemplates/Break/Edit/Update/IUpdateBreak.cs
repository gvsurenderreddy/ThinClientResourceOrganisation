using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update
{
    public interface IUpdateBreak
                        : IResponseCommand<UpdateBreakRequest,
                                           UpdateBreakResponse
                                          > { }
}