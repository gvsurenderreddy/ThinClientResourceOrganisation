using WorkSuite.Library.Service.Specification.Helpers.Entity;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates
{
    public class ShiftTemplatehelper
                     : EnityHelper<WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate
                                   ,int
                                   ,ShiftTemplateBuilder
                                   ,FakeShiftTemplateRepository> { }
}