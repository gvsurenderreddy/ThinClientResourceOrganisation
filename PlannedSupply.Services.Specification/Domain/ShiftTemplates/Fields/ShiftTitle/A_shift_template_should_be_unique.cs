using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.ShiftTitle
{
    public class A_shift_template_should_be_unique
    {
        [TestClass]
        public class On_create
                      : UniqueTextFieldSpecification<NewShiftTemplatesRequest
                                                    ,NewShiftTemplateResponse
                                                    ,NewShiftTemplatesFixture>
        {
            protected override void create_entity_with_value(string the_value)
            {
                //fixture.execute_command();
                var helper = DependencyResolver.resolve<ShiftTemplatehelper>();

                helper
                    .add()
                    .shift_title(the_value);

            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.shift_title = the_value;
            }

            protected override string value
            {
                get { return "6:00-16:00"; }
            }
        }
       
        [TestClass]
        public class On_update
                             :UniqueTextFieldSpecification<UpdateShiftTemplateRequest
                                                          ,UpdateShiftTemplateResponse
                                                          ,UpdateShiftTemplateFixture>
        {
            [TestMethod]
            public void when_update_shift_template_then_should_return_an_shift_template_entity()
            {
                PlannedSupply.ShiftTemplates.ShiftTemplate shift_template = fixture.entity;
                Assert.IsTrue(shift_template.id !=0);
            }

            protected override void create_entity_with_value(string the_value)
            {
                var helper=DependencyResolver.resolve<ShiftTemplatehelper>();

                helper
                    .add()
                    .shift_title(the_value);
            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.shift_title = the_value;
            }

            protected override string value
            {
                get { return "6:00-16:00"; }
            }
        }
    }

    }
