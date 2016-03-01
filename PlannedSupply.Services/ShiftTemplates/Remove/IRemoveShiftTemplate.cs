using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove
{
    public interface  IRemoveShiftTemplate
                    : IResponseCommand<ShiftTemplateIdentity,RemoveShiftTemplateResponse> { }
}