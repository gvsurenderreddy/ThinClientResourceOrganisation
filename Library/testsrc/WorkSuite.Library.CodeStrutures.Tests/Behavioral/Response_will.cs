using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral
{
    [TestClass]
    public class Response_will
    {
        private readonly ResponseBuilder<TestResponseResult, TestResponse> response_builder
            = new ResponseBuilder<TestResponseResult, TestResponse>();

        [TestMethod]
        public void add_errors_has_empty_enumeration_as_input_and_will_not_change_state_of_has_errors()
        {
            IEnumerable<ResponseMessage> val = new List<ResponseMessage>();
            response_builder.add_errors(val);
           Assert.IsFalse(response_builder.has_errors);
        }

        [TestMethod]
        public void add_errors_have_validation_errors_enumeration_as_input_and_will_change_state_of_has_errors()
        {
           var val = new List<ResponseMessage>();
            val.Add(new ResponseMessage{field_name = "fld",message = "Test"});
            response_builder.add_errors(val);
            Assert.IsTrue(response_builder.has_errors);
        }

        [TestMethod]
        public void add_errors_does_not_change_the_state_of_has_errors_on_passing_of_empty_enumeration()
        {
            var val = new List<ResponseMessage>();
            val.Add(new ResponseMessage { field_name = "fld", message = "Test" });
            response_builder.add_errors(val);

            Assert.IsTrue(response_builder.has_errors);

            IEnumerable<ResponseMessage> valNew = new List<ResponseMessage>();
            response_builder.add_errors(valNew);

            Assert.IsTrue(response_builder.has_errors);
        }

        [TestMethod]
        public void add_error_set_the_state_of_has_errors_to_true () {
            // Given I have a response builder with no errors
            Assert.IsFalse( response_builder.has_errors, "Sanity Check: has_errors must be false for this test to proves anything." );
            
            // When I add an error to the response builder            
            response_builder.add_error( new ResponseMessage { field_name = "", message = "Test Success" });

            // Then the response builder will report that there are now errors
            Assert.IsTrue( response_builder.has_errors );
        }

        [TestMethod]
        public void add_messages_does_not_set_has_error()
        {
            var val = new List<ResponseMessage>();
            val.Add(new ResponseMessage { field_name = "", message = "Test Success" });
            response_builder.add_messages(val);

            Assert.IsFalse(response_builder.has_errors);
        }

        [TestMethod]
        public void add_message_does_not_clear_has_error() {
            // Given the response builder already has an error
            response_builder.add_errors( new List<ResponseMessage> { 
                new ResponseMessage { field_name = "", message = "Error messages" }
            });
            Assert.IsTrue( response_builder.has_errors, "Sanity Check: the response builder is not set to have an error when it should be for the test to be valid." );


            // When I add a  message
            response_builder.add_message(new ResponseMessage { field_name = "", message = "Error messages" });


            // Then I the response builder still indicates that it has errors.
            Assert.IsTrue( response_builder.has_errors );
        }

        [TestMethod]
        public void add_message_does_not_set_has_error ()
        {
            var val = new ResponseMessage { field_name = "", message = "Test Success" };
            
            response_builder.add_message(val);

            Assert.IsFalse(response_builder.has_errors);
        }


        [TestMethod]
        public void set_response_using_response_object()
        {
            response_builder.set_response(new TestResponseResult {});

        }
    }

    [TestClass]
    public class Response_simple_message_will
    {
        private readonly ResponseBuilder<TestResponseResult, TestResponse> response_builder
            = new ResponseBuilder<TestResponseResult, TestResponse>();

        [TestMethod]
        public void add_errors_has_empty_enumeration_as_input_and_will_not_change_state_of_has_errors()
        {
            IEnumerable<string> val = new List<string>();
            response_builder.add_errors(val);
            Assert.IsFalse(response_builder.has_errors);
        }

        [TestMethod]
        public void add_errors_have_validation_errors_enumeration_as_input_and_will_change_state_of_has_errors()
        {
            var val = new List<string>();
            val.Add( "Test" );
            response_builder.add_errors(val);
            Assert.IsTrue(response_builder.has_errors);
        }

        [TestMethod]
        public void add_errors_does_not_change_the_state_of_has_errors_on_passing_of_empty_enumeration()
        {
            var val = new List<string>();
            val.Add("Test");
            response_builder.add_errors(val);

            Assert.IsTrue(response_builder.has_errors);

            IEnumerable<string> valNew = new List<string>();
            response_builder.add_errors(valNew);

            Assert.IsTrue(response_builder.has_errors);
        }

        [TestMethod]
        public void add_error_set_the_state_of_has_errors_to_true()
        {
            // Given I have a response builder with no errors
            Assert.IsFalse(response_builder.has_errors, "Sanity Check: has_errors must be false for this test to proves anything.");

            // When I add an error to the response builder            
            response_builder.add_error("Test Success");

            // Then the response builder will report that there are now errors
            Assert.IsTrue(response_builder.has_errors);
        }

        [TestMethod]
        public void add_messages_does_not_set_has_error()
        {
            var val = new List<string>();
            val.Add( "Test Success");
            response_builder.add_messages(val);

            Assert.IsFalse(response_builder.has_errors);
        }

        [TestMethod]
        public void add_message_does_not_clear_has_error()
        {
            // Given the response builder already has an error
            response_builder.add_errors(new List<string> { "Error messages" });
            Assert.IsTrue(response_builder.has_errors, "Sanity Check: the response builder is not set to have an error when it should be for the test to be valid.");


            // When I add a  message
            response_builder.add_message("Error messages");


            // Then I the response builder still indicates that it has errors.
            Assert.IsTrue(response_builder.has_errors);
        }

        [TestMethod]
        public void add_message_does_not_set_has_error()
        {
            response_builder.add_message("Test Success");

            Assert.IsFalse(response_builder.has_errors);
        }

        [TestMethod]
        public void set_response_using_response_object()
        {
            response_builder.set_response(new TestResponseResult { });

        }
    }

    internal class TestResponseResult {}
    internal class TestResponse :Response<TestResponseResult> {}
}