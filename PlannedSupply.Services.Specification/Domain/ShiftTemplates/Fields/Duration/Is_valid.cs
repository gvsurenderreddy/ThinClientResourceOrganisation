using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.Duration
{
    public class Is_valid
    {
        [TestClass]
        public class OnCreate : DurationInHoursAndMinutesSpecification < NewShiftTemplatesRequest
                                                                       , NewShiftTemplateResponse
                                                                       , NewShiftTemplatesFixture>
        {
           

            public OnCreate() 
                         : base((request,duration_request) => request.duration = duration_request) { }
        }

        [TestClass]
        public class OnUpdate : DurationInHoursAndMinutesSpecification < UpdateShiftTemplateRequest
                                                                       , UpdateShiftTemplateResponse
                                                                       , UpdateShiftTemplateFixture>
        {
           
            public OnUpdate() : base((request,duration_request) => request.duration =duration_request)  { }
        }
    }
}