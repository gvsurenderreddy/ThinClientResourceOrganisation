using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Remove
{
    public class RemoveFixture
        : ResponseCommandFixture<ShiftTemplateIdentity
                                ,RemoveShiftTemplateResponse
                                ,IRemoveShiftTemplate>
    {
        public RemoveFixture
                    (IRemoveShiftTemplate the_command
                   , IRequestHelper<ShiftTemplateIdentity> the_request_builder) 
            : base(the_command, the_request_builder) { }
    }
}