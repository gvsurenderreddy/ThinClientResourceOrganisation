using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.StartTime
{
    [TestClass]
    public class A_start_time_should_be_mandatory

    {
        [TestClass]
        public class On_create
                        : MandatoryTimeFieldSpecification < NewShiftTemplatesRequest
                                            , NewShiftTemplateResponse
                                            , NewShiftTemplatesFixture>
        {
            public On_create()
                : base((request, time_request) => request.start_time = new TimeRequest()
                {hours = time_request.hours, minutes = time_request.minutes})
            {
            }
        }

        [TestClass]
        public class On_update
                        : MandatoryTimeFieldSpecification<UpdateShiftTemplateRequest
                                                         , UpdateShiftTemplateResponse
                                                         , UpdateShiftTemplateFixture>
        {
            public On_update()
                : base((request, time_request) => request.start_time = new TimeRequest()
                {hours = time_request.hours, minutes = time_request.minutes})
            {
            }
        }
    }
}