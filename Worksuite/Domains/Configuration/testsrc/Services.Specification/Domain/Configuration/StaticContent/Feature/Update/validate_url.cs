using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Feature.Update
{
   [TestClass]
    public class validate_url
                          :ConfigurationSpecification
    {
        [TestMethod]
        public void check_url_is_exist_or_not()
        {
            const string expected_url = "https://www.google.co.uk/";
            var request = new UpdateStaticContentRequest()
            {
                location_url = expected_url
            };
          
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            response.messages.Should().Contain(m => m.message == ErrorMessages.error_04_0016);
            
        }

        protected override void test_setup()
        {
            base.test_setup();
            _checkUrl = DependencyResolver.resolve<ValidationUrl>();
            command = DependencyResolver.resolve<IUpdateStaticContents>();
            _checkUrl.status=UrlExistenceTestResponse.UrlEstablished;
        }

        private IUpdateStaticContents command;
        private ValidationUrl _checkUrl;
    }
}