using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Configuration.Help.Feature.Update
{
    [TestClass]
    public class get_current_update
                 :ConfigurationSpecification
    {
        [TestMethod]
        public void get_last_location_url_in_edit_command()
        {
            var help = help_url_helper
                .add()
                .location_url("http://localhost:38901/")
                .entity;
            var response = command.execute();
            response.location_url.Should().Be(help.location_url);
        }

        protected override void test_setup()
        {
            base.test_setup();
            help_url_helper = DependencyResolver.resolve<HelpUrlHelper>();
            command = DependencyResolver.resolve<IGetUpdateHelpRequest>();
        }

        private HelpUrlHelper help_url_helper;
        private IGetUpdateHelpRequest command;
    }
}