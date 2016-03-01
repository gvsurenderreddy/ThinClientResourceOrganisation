using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Primitives.Sanitisation.StringSanitiser {

    [TestClass]
    public class normalise_for_presentation_will {

        // done: trim trailing whitespace
        // done: trim leading whitespace
        // done: return an empty string if just whitespace
        // to do: return an empty string if null

        [TestMethod]
        public void trim_trailing_whitespace ( ) {

             (a_value + white_space).normalise_for_presentation().Should().Be( a_value  );
        }

        [TestMethod]
        public void trim_leading_whitespace ( ) {

             (white_space + a_value).normalise_for_presentation().Should().Be( a_value  );
        }


        [TestMethod]
        public void return_an_empty_string_if_just_whitespace ( ) {

             white_space.normalise_for_presentation().Should().Be( String.Empty );
        }

        [TestMethod]
        public void return_an_empty_string_if_null ( ) {
            string sut = null;

            sut.normalise_for_presentation().Should().Be( String.Empty );
        }


        const string a_value = "a value";
        const string white_space = "\t \n";


    }

}