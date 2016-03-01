using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral.IEnumerableExtensions {

    [TestClass]
    public class has_entires_will {

        // done: call yes if there are elements in the enumerable
        // done: pass the enumreable as an argument into yes
        // done: call no if there are no elements in the enumerable
        // done: call no if the enumerable is null 

        [TestMethod]
        public void call_yes_if_there_are_elements_in_the_enumerable () {

            var sut = new List<string>() {"test"};
            bool? found_entries = null;

            sut.has_entries(
                yes: entries => found_entries = true,
                no: () => found_entries = false                
            );

            found_entries.Should().BeTrue();
        }


        [TestMethod]
        public void pass_the_enumreable_as_an_argument_into_yes () {

            var sut = new List<string>() {"test"};

            sut.has_entries(
                yes: entries => entries.Should().BeEquivalentTo( sut ),
                no: Assert.Fail                
            );
        }

        [TestMethod]
        public void call_no_if_there_are_no_elements_in_the_enumerable () {

            var sut = new List<string>();
            bool? found_entries = null;

            sut.has_entries(
                yes: entries => found_entries = true,
                no: () => found_entries = false                
            );

            found_entries.Should().BeFalse();
        }

        [TestMethod]
        public void call_no_if_the_enumerable_is_null  () {
            var sut = new List<string>();
            bool? found_entries = null;

            sut.has_entries(
                yes: entries => found_entries = true,
                no: () => found_entries = false                
            );

            found_entries.Should().BeFalse();
        }
         
    }
}