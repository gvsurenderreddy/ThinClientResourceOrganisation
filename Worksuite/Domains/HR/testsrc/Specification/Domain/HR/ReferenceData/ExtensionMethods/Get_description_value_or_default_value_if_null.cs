using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.ExtensionMethods
{
    [TestClass]
    public class Get_description_value_or_default_value_if_null
    {
        [TestMethod]
        public void when_there_is_no_reference_data_setup_in_reference_data_then_should_return_null_description()
        {
            var reference_data_description = ReferenceDataExtensionMethods.get_description_or_default_if_null(null);

            reference_data_description.Should().BeNull();
        }

        [TestMethod]
        public void when_there_is_a_reference_data_setup_in_reference_data_then_should_return_reference_data_description()
        {
            var title_helper = DependencyResolver.resolve<TitleHelper>();
            var reference_data = title_helper.add().entity;

            var reference_data_description = reference_data.get_description_or_default_if_null();

            reference_data_description.Should().Be(reference_data.description);
        }
    }
}