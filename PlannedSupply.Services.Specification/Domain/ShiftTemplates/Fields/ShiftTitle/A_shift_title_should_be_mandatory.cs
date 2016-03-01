using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.ShiftTitle
{

    public class A_shift_title_should_be_mandatory
    {
        [TestClass]
        public class On_create
            : MandatoryTextFieldSpecification<NewShiftTemplatesRequest
                , NewShiftTemplateResponse
                , NewShiftTemplatesFixture>
        {
            public On_create()
                : base((request, value) => request.shift_title = value)
            {
            }


        }

        [TestClass]
        public class On_update
            : MandatoryTextFieldSpecification<UpdateShiftTemplateRequest
                , UpdateShiftTemplateResponse
                , UpdateShiftTemplateFixture>
        {
            public On_update()
                : base((request, value) => request.shift_title = value) { }
        }
    }
}