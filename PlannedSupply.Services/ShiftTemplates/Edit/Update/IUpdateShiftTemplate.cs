using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update
{
    public interface IUpdateShiftTemplate
                          : IResponseCommand <UpdateShiftTemplateRequest
                                             ,UpdateShiftTemplateResponse> { }
}