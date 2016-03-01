using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Feature.Update
{
    //[TestClass]
    public class update_will_commite 
             :ConfigurationSpecification 
    {
        [TestMethod]
        public void command_commited_changes()
        {
            var static_content = static_content_helper
                .add()
                .location_url("https://www.google.co.uk")
                .entity;

            var request = new UpdateStaticContentRequest
            {
                location_url = static_content.location_url,
            };

            var response = command.execute(request);
            FakeUnitOfWork.commit_was_called.Should().BeTrue();

        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateStaticContents>();
            static_content_helper = DependencyResolver.resolve<StaticContentHelper>();
            FakeUnitOfWork = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private StaticContentHelper static_content_helper;
        private FakeUnitOfWork FakeUnitOfWork;
        private IUpdateStaticContents command;
    }
}