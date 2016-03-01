using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.ShiftDetails.ShiftTemplateSummary
{
    public interface IGetShiftTemplateUpdateRequest
                       : IQuery<ShiftTemplateIdentity, Response <UpdateShiftTemplateRequest>> { } 
}