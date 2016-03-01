using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.ShiftDetails.ShiftTemplateSummary;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Fields.Colour
{
    [TestClass]
    public class OnGetUpdate
                    : PlannedSupplySpecification 
    {
        // done : create return in correct format and field
        // done : request should return correct colour
        // done : when sumbmit colour should be save 
        [TestMethod]
        public void create_return_in_correct_format_and_field()
        {
            var helper = shift_template_helper
               .add()
               .colour(new RgbColour(34, 34, 25))
               .entity;

            var response = get_update.execute(new ShiftTemplateIdentity()
            {
             shift_template_id = helper.id,
            });

            Assert.IsTrue(response.result.colour.R== helper.colour.rgb_colour_format().R);
            Assert.IsTrue(response.result.colour.G== helper.colour.rgb_colour_format().G);
            Assert.IsTrue(response.result.colour.B== helper.colour.rgb_colour_format().B);
        }

       
        [TestMethod]
        public void request_shoudld_return_correct_colour()
        {
            var helper = shift_template_helper
              .add()
              .colour(new RgbColour(34, 34, 25))
              .entity;
            var request = new RGBColourRequest() {R = 34, G = 34, B = 25};

            var response = get_update.execute(new ShiftTemplateDetails() 
            {
                shift_template_id = helper.id,
                colour=new RgbColour(Convert.ToByte(request.R),Convert.ToByte(34),Convert.ToByte(25))
            });

            Assert.IsTrue(response.result.colour.R == helper.colour.rgb_colour_format().R);
            Assert.IsTrue(response.result.colour.G == helper.colour.rgb_colour_format().G);
            Assert.IsTrue(response.result.colour.B == helper.colour.rgb_colour_format().B);
        }

        [TestMethod]
        public void update_should_save_changes()
        {
            var helper = shift_template_helper
              .add()
              .shift_title("test")
              .colour(new RgbColour(34, 34, 25))
              .start_time(new TimeRequest(){hours = "12",minutes = "12"})
              .duration(new DurationRequest(){hours = "12" ,minutes = "12"})
              .entity;

            var request = new UpdateShiftTemplateRequest()
            {
                shift_template_id = helper.id,
                shift_title = helper.shift_title,
                colour = helper.colour.to_rgb_colour_request_from_persistence_format(),
                start_time = helper.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                duration = helper.duration_in_seconds.to_duration_request()
            };
            command.execute(request);

            fake_unit_of_work.commit_was_called.Should().BeTrue();
        }


        protected override void test_setup()
        {
            base.test_setup();
            shift_template_helper = DependencyResolver.resolve<ShiftTemplatehelper>();
            get_update = DependencyResolver.resolve<IGetShiftTemplateUpdateRequest>();
            command = DependencyResolver.resolve<IUpdateShiftTemplate>();
            fake_unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private ShiftTemplatehelper shift_template_helper;
        private IGetShiftTemplateUpdateRequest get_update;
        private IUpdateShiftTemplate command;
        private FakeUnitOfWork fake_unit_of_work;

    }

    

   
}