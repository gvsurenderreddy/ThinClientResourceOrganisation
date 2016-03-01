using System.Collections.Generic;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    /// <summary>
    ///     The standard response object that is returned by every 
    /// command or query.
    /// </summary>
    public class Response {

        public bool has_errors { get; set; }
        public IEnumerable<ResponseMessage> messages { get; set; }
        
    }


    /// <summary>
    ///     Standard response object that is returned by every command or query
    /// </summary>
    /// <typeparam name="Q">
    ///     The response type for the command.
    /// </typeparam>
    public class Response<Q> : Response {

        // to do: rename to result
        public Q result { get; set; }
        
    }

}