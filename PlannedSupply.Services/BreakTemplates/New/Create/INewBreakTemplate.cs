using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create
{
    public interface INewBreakTemplate
                        : IResponseCommand<NewBreakTemplateRequest,
                                            NewBreakTemplateResponse
                                          > { }
}