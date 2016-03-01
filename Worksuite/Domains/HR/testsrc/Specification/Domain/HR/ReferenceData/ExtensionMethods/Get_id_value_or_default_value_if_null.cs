using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.ExtensionMethods
{
    [TestClass]
    public class Get_id_value_or_default_value_if_null
    {
        [TestMethod]
        public void when_there_is_no_reference_data_setup_in_reference_data_then_should_return_null_id()
        {
            var reference_data_id = ReferenceDataExtensionMethods.get_id_or_default_if_null(null);

            reference_data_id.Should().Be(null);
        }

        [TestMethod]
        public void when_there_is_a_reference_data_setup_in_reference_data_then_should_return_reference_data_id()
        {
            var title_helper = DependencyResolver.resolve<TitleHelper>();
            var reference_data = title_helper.add().entity;

            var reference_data_id = reference_data.get_id_or_default_if_null();

            reference_data_id.Should().Be(reference_data.id);
        }
    }
}