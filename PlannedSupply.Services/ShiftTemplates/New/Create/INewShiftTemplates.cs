using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create
{
    public interface INewShiftTemplates
                        : IResponseCommand<NewShiftTemplatesRequest
                                           ,NewShiftTemplateResponse>  { }
}