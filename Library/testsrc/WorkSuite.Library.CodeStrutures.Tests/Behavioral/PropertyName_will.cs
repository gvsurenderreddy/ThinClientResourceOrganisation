using System;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral {

    [TestClass]
    public class PropertyName_will {

        // done: return the name of the property returned by the expresion
        // to do: throw an excreption if the expression is null

        [TestMethod]
        public void return_the_name_of_the_property_returned_by_the_expresion() {
            Expression<Func<AModel, string>> sut = m => m.a_property;

            sut.property_name().Should().Be( "a_property" );
        }

        [TestMethod]
        public void throw_an_excreption_if_the_expression_is_null() {
            Expression<Func<AModel, string>> sut = null;

            Action act = () => sut.property_name();

            act.ShouldThrow<Exception>();
        }

        private class AModel {

            public string a_property { get; set; }
        }
    }

}