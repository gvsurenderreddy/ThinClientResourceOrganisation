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
    public class A_shift_templates_should_be_restricted_to_the_maximum_number_of_characters
    {
        [TestClass]
        public class On_create
                             : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewShiftTemplatesRequest
                                                                                                   ,NewShiftTemplateResponse
                                                                                                   ,NewShiftTemplatesFixture>
        {
            public On_create()
                :base ((request,value) => request.shift_title=value) { }
        }

        [TestClass]
        public class On_update
            : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateShiftTemplateRequest
                                                                                 , UpdateShiftTemplateResponse
                                                                                 , UpdateShiftTemplateFixture>
        {
            public On_update()
                : base((request, value) => request.shift_title = value) {}
        }
    }
}