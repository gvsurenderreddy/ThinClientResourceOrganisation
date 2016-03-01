using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {

    /// <summary>
    ///     Test that leading and trailing white space characters are stripped from a text field
    /// before the details are saved to the underlying entity.
    /// </summary>
    /// <typeparam name="P">
    ///     The type of the request for the command being tested
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The type of the response for the command being tested
    /// </typeparam>
    /// <typeparam name="F">
    ///     The type of the fixture that allows the specification to apply its tests. This 
    /// has to be an <see cref="IsAResponseCommandVerifiedByAnEntitiesStateFixture{P,Q,E}"/> 
    /// because the specification needs to test against the values that the entity is set to.
    /// </typeparam>
    /// <typeparam name="E">
    ///     The entity that the request is applied to.
    /// </typeparam>
    public class TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<P, Q, F,E>
                            : HRResponseCommandSpecification<P, Q, F>
                    where Q : Response
                    where F : IsAResponseCommandVerifiedByAnEntitiesStateFixture<P,Q,E> {


        // done removes space
        // done removes tab
        // done removed carriage return
        // done removes new line


        [TestMethod]
        public void leading_spaces_are_stripped ( ) {
            leading_are_stripped( " " );
        }

        [TestMethod]
        public void trailing_spaces_are_stripped ( ) {
            trailing_are_stripped( " " );
        }


        [TestMethod]
        public void leading_tabs_are_stripped ( ) {
            leading_are_stripped( "\t" );
        }

        [TestMethod]
        public void trailing_tabs_are_stripped ( ) {
            trailing_are_stripped( "\t" );
        }


        [TestMethod]
        public void leading_carriage_returns_are_stripped ( ) {
            leading_are_stripped( "\r" );
        }

        [TestMethod]
        public void trailing_carriage_returns_are_stripped ( ) {
            trailing_are_stripped( "\r" );
        }


        [TestMethod]
        public void leading_new_lines_are_stripped ( ) {
            leading_are_stripped( "\n" );
        }

        [TestMethod]
        public void trailing_new_lines_are_stripped ( ) {
            trailing_are_stripped( "\n" );
        }


        /// <summary>
        ///     Allow the descendants to specify specialise the specification for
        /// the request and entity that will be exercised by the test.
        /// </summary>
        /// <param name="get_request_field_value_delegate">
        ///     Delegate that returns the value of the request field that is being 
        /// tested.
        /// </param>
        /// <param name="set_request_field_value_delegate">
        ///     Delegate that will set the value of the request field that is being 
        /// tested.
        /// </param>
        /// <param name="get_entity_field_value_delegate">
        ///     Delegate that returns the value of the entity property that is being 
        /// tested.
        /// </param>
        protected TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification
                    ( Func<P, string> get_request_field_value_delegate
                    , Action<string, P> set_request_field_value_delegate
                    , Func<E, string> get_entity_field_value_delegate ) {
            
            get_request_field_value = Guard.IsNotNull( get_request_field_value_delegate, "get_request_field_value_delegate" );
            set_request_field_value = Guard.IsNotNull( set_request_field_value_delegate, "set_request_field_value_delegate" );
            get_entity_field_value = Guard.IsNotNull( get_entity_field_value_delegate, "get_entity_field_value_delegate" );
            
        }


        protected void leading_are_stripped
                        ( string expected_to_be_stripped ) {

            // arrange - prefix a the request field with value you expect to be stripped
            var expected = get_request_field_value( fixture.request  );
            set_request_field_value( string.Concat( expected_to_be_stripped, expected ), fixture.request );

            // act
            fixture.execute_command( );

            // assert - check that the value written to the entity had the value stripped.
            get_entity_field_value( fixture.entity ).Should().Be( expected );
        }


        protected void trailing_are_stripped
                        ( string expected_to_be_stripped ) {

            // arrange - append a the request field with value you expect to be stripped
            var expected = get_request_field_value( fixture.request  );
            set_request_field_value( string.Concat( expected, expected_to_be_stripped ), fixture.request );

            // act
            fixture.execute_command( );

            // assert - check that the value written to the entity had the value stripped.
            get_entity_field_value( fixture.entity ).Should().Be( expected );
        }

        private readonly Func<P, string> get_request_field_value;
        private readonly Action<string, P> set_request_field_value;
        private readonly Func<E, string> get_entity_field_value;

    }
}
