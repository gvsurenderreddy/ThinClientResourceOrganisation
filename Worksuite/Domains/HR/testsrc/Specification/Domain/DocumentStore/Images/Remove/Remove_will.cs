using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.Remove;
using WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images;
using WTS.WorkSuite.Service.Helpers.Specifications;
using WTS.WorkSuite.Service.Infrastructure;

namespace WTS.WorkSuite.Service.Domain.DocumentStore.Images.Remove
{

    [TestClass]
    public class Remove_will
                    : CommandCommitedChangesSpecification<ImageIdentity, RemoveImageResponse, RemoveFixture>
    {

        [TestMethod]
        public void remove_the_image()
        {
            fixture.execute_command();

            image_repository.Entities.Select(e => e.id == fixture.request.imageId).Should().BeEmpty();

        }

        [TestMethod]
        public void return_no_errors_if_the_entity_does_not_exist()
        {
            image_repository.clear();

            fixture.execute_command();

            fixture.response.has_errors.Should().BeFalse();

        }


        protected override void test_setup()
        {
            base.test_setup();
            image_repository = DependencyResolver.resolve<FakeImageRepository>();
        }

        private FakeImageRepository image_repository;

    }
}
