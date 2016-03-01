using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.ShiftDetails;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplates.GetAll
{
    public class GetAllShiftTemplateResponse
                    : Response<IEnumerable<ShiftTemplateDetails>> { }
}