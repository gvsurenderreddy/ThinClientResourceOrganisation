using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral {

    [TestClass]
    public class AsResponseMessage_wiil {


        // done: set the message part of a response message to be the string
        // done: set the field part of a response message to be an empty string
        // done: set the message part of a response message to be an empty string applied to a null 

        [TestMethod]
        public void set_the_message_part_of_a_response_message_to_be_the_string ( ) {

            a_string.ToResponseMessage().message.Should().Be( a_string );
        }

        [TestMethod]
        public void set_the_field_part_of_a_response_message_to_be_an_empty_string ( ) {
            
            a_string.ToResponseMessage().field_name.Should().BeEmpty( );
        }

        [TestMethod]
        public void allow_you_to_specify_the_field_name ( ) {
            
            a_string.ToResponseMessage( a_field_name ).field_name.Should().Be( a_field_name );
        }

        [TestMethod]
        public void set_the_message_part_of_a_response_message_to_be_an_empty_string_when_applied_to_a_null_value ( ) {
            string null_string = null;

            null_string.ToResponseMessage(  ).message.Should(  ).BeEmpty(  );
        }

        const string a_string = "a string";
        const string a_field_name = "a_field_name";
    }

}