using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral {

    [TestClass]
    public class ValueOrDefault_will {

        // done: returns the expression value 
        // done: returns the default value if the expression is null

        [TestMethod]
        public void returns_the_expression_value () {
            Func<string> expression = () => "Hello world";

            expression.value_or_default("A Default").Should().Be("Hello world");
        }

        [TestMethod]
        public void returns_the_default_value_if_the_expression_is_null () {
            Func<string> expression = null;

            expression.value_or_default( "A Default" ).Should().Be( "A Default" );
        }


        [TestMethod]
        public void returns_the_expression() {
            Func<AModel,string> expression = m => "Hello world";

            expression.value_or_default("A Default")( new AModel() ).Should().Be( "Hello world" );
        }

        [TestMethod]
        public void returns_the_default_value_expression_if_the_expression_is_null () {
            Func<AModel,string> expression = null;

            expression.value_or_default("A Default")( new AModel() ).Should().Be("A Default");
        }

        private class AModel {} 

    }
}