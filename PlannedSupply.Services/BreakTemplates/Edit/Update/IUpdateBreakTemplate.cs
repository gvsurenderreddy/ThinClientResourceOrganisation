using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update
{
    public interface IUpdateBreakTemplate
                            : IResponseCommand<UpdateBreakTemplateRequest,
                                                UpdateBreakTemplateResponse
                                              > { }
}