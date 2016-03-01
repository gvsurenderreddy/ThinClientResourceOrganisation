using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.Help.Fields.location_url
{
    [TestClass]
    public class location_url_has_white_space_stripped 
                 :ConfigurationSpecification
    {
        [TestMethod]
        public void location_url_does_not_have_white_space_at_start_and_end_on_update()
        {
            _fakeUrlExist.response_status = UrlExistenceTestResponse.UrlEstablished;
            var request = new UpdateHelpRequest()
            {
                location_url= "  https://www.google.co.uk/  "
            };
            var response = command.execute(request);
            Help_url_helper.entities.Last().location_url.Should().Be(request.location_url.Trim());
            response.has_errors.Should().BeFalse();
        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateHelp>();
            Help_url_helper = DependencyResolver.resolve<HelpUrlHelper>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            
        }

        private HelpUrlHelper Help_url_helper;
        private IUpdateHelp command;
        private FakeUrlExistTest _fakeUrlExist;
    }
}