using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.Colour
{
    public class colour_picker_defualt_value
    {
         [TestClass]
        public class OnCreate : RgbColourWhiteDefualtValueSpecification < NewShiftTemplatesRequest
                                                                      , NewShiftTemplateResponse
                                                                      , NewShiftTemplatesFixture>
        {
            
             public  OnCreate() 
                            : base((request,colour_request) => request.colour = colour_request) 
             { }
        }

       
     
        [TestClass]
        public class OnUpdate : RgbColourWhiteDefualtValueSpecification < UpdateShiftTemplateRequest
                                                                      , UpdateShiftTemplateResponse
                                                                      , UpdateShiftTemplateFixture>
        {
            public OnUpdate()
                : base((request, colour_request) => request.colour = colour_request)
            { }
        }
    }
}