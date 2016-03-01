namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    public class ResponseMessage {

        public string field_name { get; set; }
        public string message { get; set; }

    }


    public static class ResponseMessageHelpers {

        /// <summary>
        ///     Converts a string to a response messages setting the message
        /// property to be the string and the field name to be empty
        /// </summary>
        /// <param name="message">
        ///     The string that is to be converted
        /// </param>
        /// <returns>
        ///     The string represented as a response message
        /// </returns>
        public static ResponseMessage ToResponseMessage
                                        ( this string message ) {
            
            return message.ToResponseMessage( string.Empty );
        }

        /// <summary>
        ///     Converts a string to a response messages setting the message
        /// property to be the string and the field name to be empty
        /// </summary>
        /// <param name="message">
        ///     The string that is to be converted
        /// </param>
        /// <param name="field_name">
        ///     The name of the field retruned in the response message
        /// </param>
        /// <returns>
        ///     The string represented as a response message
        /// </returns>
        public static ResponseMessage ToResponseMessage
                                        ( this string message 
                                        , string field_name ) {
            
            return new ResponseMessage {
                field_name = field_name ,
                message = message ?? string.Empty,
            };
        }
    }
}