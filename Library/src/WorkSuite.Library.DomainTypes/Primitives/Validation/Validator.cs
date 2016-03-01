using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation {

    /// <summary>
    ///     Provides access to the verifiers and a list of all errors
    /// that have been identified.
    /// </summary>
    public class Validator  {

        // to do: add an expression base version for type safe
        //        retrieval of user names.

        /// <summary>
        ///     Provides a field verifier.  All validation errors will be recorded 
        /// against the field.
        /// </summary>
        /// <param name="field_name">
        ///     Name of the field to be validated
        /// </param>
        /// <returns>
        ///     A field verifier.
        /// </returns>
        public FieldVerifier field 
                                ( string field_name ) {

            return new FieldVerifier( field_name, errors_ );
        }

        /// <summary>
        ///     List of the validation errors that have been raised
        /// </summary>
        public IEnumerable<ResponseMessage> errors {
            get {
                return errors_;
            }
        }

        /// <summary>
        ///     Adds an error to the errors.
        /// </summary>
        /// <param name="error_message">
        ///     Error messages for the error. 
        /// </param>
        /// <returns>
        ///     The validator as this is a fluent interface member
        /// </returns>
        public Validator  add_error 
                            ( string error_message ) {

            errors_.Add( new ResponseMessage { message = error_message });
            return this;
        }
        

        /// <summary>
        ///     Checks that specified premise holds and records a validation error if 
        /// it does not.
        /// </summary>
        /// <param name="premise">
        ///     The premise that is expected to be true
        /// </param>
        /// <param name="error_message">
        ///     The error message that is recorded if the premise is false
        /// </param>
        /// <returns>
        ///     The validator as this is a fluent interface member
        /// </returns>
        public Validator  premise_holds
                            ( bool premise
                            , string error_message ) {

            if ( !premise ) {
                add_error( error_message );
            }

            return this;
        }

        private readonly List<ResponseMessage> errors_ = new List<ResponseMessage>();

    }
}