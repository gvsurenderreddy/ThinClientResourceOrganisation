using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.Duration
{
    public class duration_should_be_mandatory
    {
        [TestClass]
        public class On_create
                     : MandatoryDurationFieldSpecification < NewShiftTemplatesRequest
                                              , NewShiftTemplateResponse
                                              , NewShiftTemplatesFixture >
        {
              public On_create()
                  : base  ((request , duration_request) => request.duration = new DurationRequest() { hours = duration_request.hours,minutes = duration_request.minutes}) { }
        }

        [TestClass]
        public class On_Update
                     : MandatoryDurationFieldSpecification< UpdateShiftTemplateRequest
                                             ,UpdateShiftTemplateResponse
                                             ,UpdateShiftTemplateFixture>
        {
            public On_Update()
                : base((request, duration_request) => request.duration = new DurationRequest() { hours = duration_request.hours, minutes = duration_request.minutes}) { }
                      
        }

    }
}