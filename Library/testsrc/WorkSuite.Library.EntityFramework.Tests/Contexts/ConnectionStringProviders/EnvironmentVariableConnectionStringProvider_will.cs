using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.EntityFramework.Contexts.ConnectionStringProviders;

namespace WorkSuite.Library.EntityFramework.Tests.Contexts.ConnectionStringProviders {

    [TestClass]
    public class EnvironmentVariableConnectionStringProvider_will {

        // done: implement IConnectionStringProvider
        // done: return the value of the specified environment variable
        // done: return an empty string if the environment variable does not exist

        [TestMethod]
        public void implement_IConnectionStringProvider ( ) {            

            new EnvironmentVariableConnectionStringProvider( "" ).Should().BeAssignableTo<IConnectionStringProvider>(  );
        }

        [TestMethod]
        public void return_the_value_of_the_specified_environment_variable ( ) {
            Environment.SetEnvironmentVariable("provider_test","A value" );
            var provider = new EnvironmentVariableConnectionStringProvider("provider_test");

            provider.connection_string.Should( ).Be( Environment.GetEnvironmentVariable( "provider_test" ) );                                    
        }

        [TestMethod]
        public void return_an_empty_string_if_the_environment_variable_does_not_exist () {
            var provider = new EnvironmentVariableConnectionStringProvider("ficticious_variable");

            provider.connection_string.Should(  ).BeEmpty(  );
        }

    }

}