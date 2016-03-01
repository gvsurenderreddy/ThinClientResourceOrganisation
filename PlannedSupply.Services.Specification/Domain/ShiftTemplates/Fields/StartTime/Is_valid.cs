using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.StartTime
{
    public class Is_valid
    {
        [TestClass]
        public class OnCreate : TwentyFourHourClockTimeSpecification < NewShiftTemplatesRequest
                                                                     , NewShiftTemplateResponse
                                                                     , NewShiftTemplatesFixture>
        {
            public OnCreate(): base(
                (request, time_request) => request.start_time = time_request)
            {

            }
         }

        [TestClass]
        public class OnUpdate: TwentyFourHourClockTimeSpecification < UpdateShiftTemplateRequest
                                                                    , UpdateShiftTemplateResponse
                                                                    , UpdateShiftTemplateFixture>
        {
            public OnUpdate()
                : base((request, time_request) => request.start_time = time_request)
            {

            }
         }
    }
}