using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.GetCurrentDatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Features.GetCurrentDatabaseSetting
{
    [TestClass]
    public class currectly_maps_the_field:ConfigurationSpecification
    {

        [TestMethod]
        public void check_connection_string()
        {
            var database_setting = helper.add().entity;
            database_setting.connection_string = "Data Source=localhost;Initial Catalog=WORKSuite5_Experimental;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            var responce = query.execute();
            responce.has_errors.Should().BeFalse();
            responce.result.connection_string.Should().Be(database_setting.connection_string);
        }
        protected override void test_setup()
        {
            base.test_setup();
            helper = DependencyResolver.resolve<DatabaseSettingHelper>();
            query = DependencyResolver.resolve<IGetCurrentDatabaseSetting>();
        }

        private DatabaseSettingHelper helper;
        private IGetCurrentDatabaseSetting query;
    }
}