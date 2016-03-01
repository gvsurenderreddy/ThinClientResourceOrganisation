using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;


namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Features.Update
{
    [TestClass]
    public class GetCurrentUpdate:ConfigurationSpecification
    {
        [TestMethod]
        public void get_last_connection_string_in_edit_command()
        {
            var databaseSettings = database_setting_helper
                                         .add()
                                         .connection_string
                                         ("Data Source=localhost;Initial Catalog=WORKSuite5_Experimental;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework")
                                         .entity;

            var response = command.execute();

            response.connection_string.Should().Be( databaseSettings.connection_string );
        }
        protected override void test_setup()
        {
            base.test_setup();
            database_setting_helper = DependencyResolver.resolve<DatabaseSettingHelper>();
            command = DependencyResolver.resolve<IGetUpdateRequest>();
          

        }

        private DatabaseSettingHelper database_setting_helper;
        private IGetUpdateRequest command;
       
    }
}