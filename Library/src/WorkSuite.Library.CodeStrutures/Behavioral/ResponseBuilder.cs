using System;
using System.Collections.Generic;
using System.Linq;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{

    /// <summary>
    ///     Builder that allows you to create a new <see cref="Response"/>
    /// </summary>
    /// <typeparam name="Q">
    ///     The type of response that needs to be built. I must be 
    /// a descendent of <see cref="Response"/>
    /// </typeparam>
    public class ResponseBuilder<Q>
            where Q : Response, new()
    {

        public ResponseBuilder<Q> add_errors
                                    (IEnumerable<ResponseMessage> errors_to_add)
        {

            if (errors_to_add == null) throw new ArgumentNullException("errors_to_add");

            Guard.IsNotNull(errors_to_add, "errors_to_add");

            foreach (var err in errors_to_add)
            {
                if (string.IsNullOrWhiteSpace(err.message))
                {
                    err.message = string.Empty;
                }

                add_error(err);
            }

            // set has errors to true if any errors were added
            has_errors = has_errors || errors_to_add.Any();
            return this;
        }

        public ResponseBuilder<Q> add_errors
                                    (IEnumerable<string> errors_to_add)
        {

            Guard.IsNotNull(errors_to_add, "errors_to_add");

            foreach (var err in errors_to_add)
            {
                add_error(err);
            }

            // set has errors to true if any errors were added
            has_errors = has_errors || errors_to_add.Any();
            return this;
        }

        public ResponseBuilder<Q> add_error
                                    (ResponseMessage error_to_add)
        {

            Guard.IsNotNull(error_to_add, "error_to_add");

            messages.Add(error_to_add);

            // set has errors to true if any errors were added
            has_errors = true;
            return this;
        }

        public ResponseBuilder<Q> add_error
                                    (string error_to_add)
        {

            Guard.IsNotNull(error_to_add, "error_to_add");

            messages.Add(new ResponseMessage { message = error_to_add });

            // set has errors to true if any errors were added
            has_errors = true;
            return this;
        }


        // add messages
        // add confirmation message 
        public ResponseBuilder<Q> add_messages
                                    (IEnumerable<ResponseMessage> messages_to_add)
        {

            Guard.IsNotNull(messages_to_add, "messages_to_add");

            foreach (var msg in messages_to_add)
            {
                if (string.IsNullOrWhiteSpace(msg.message))
                {
                    msg.message = string.Empty;
                }

                add_message(msg);
            }
            return this;
        }

        public ResponseBuilder<Q> add_messages
                                    (IEnumerable<string> messages_to_add)
        {

            Guard.IsNotNull(messages_to_add, "messages_to_add");

            foreach (var msg in messages_to_add)
            {
                add_message(msg);
            }
            return this;
        }

        // add confirmation message 
        public ResponseBuilder<Q> add_message
                                    (ResponseMessage message_to_add)
        {

            Guard.IsNotNull(message_to_add, "message_to_add");

            messages.Add(message_to_add);
            return this;
        }

        public ResponseBuilder<Q> add_message
                                    (string message_to_add)
        {

            Guard.IsNotNull(message_to_add, "message_to_add");

            messages.Add(new ResponseMessage { message = message_to_add });
            return this;
        }



        public bool has_errors { get; private set; }

        public bool has_any(Func<ResponseMessage, bool> checker)
        {
            var found = false;

            foreach (var msg in messages)
            {
                found = checker(msg);
                if (found)
                    break;
            }

            return found;
        }

        public virtual Q build()
        {


            return new Q
            {
                messages = messages,
                has_errors = has_errors,
            };
        }


        private readonly List<ResponseMessage> messages = new List<ResponseMessage>();
    }


    /// <summary>
    ///     Extends the <see cref="ResponseBuilder'1{Q}"/> to return a <see cref="Response'1{Q}"/>
    /// this is a response that contains a command's response as well any error messages etc.
    /// </summary>
    /// <typeparam name="R">
    ///     The command's response type, it should always be an entities identity.
    /// </typeparam>    
    /// <typeparam name="Q">
    ///     The type of response that needs to be built. I must be 
    /// a descendent of <see cref="Response"/>
    /// </typeparam>    
    public class ResponseBuilder<R, Q>
                   : ResponseBuilder<Q>
           where Q : Response<R>, new()
    {

        public void set_response
                        (R the_response)
        {

            Guard.IsNotNull(the_response, "the_response");

            response = the_response;
        }

        public override Q build()
        {

            Guard.IsNotNull(response, "response");

            var result = base.build();
            result.result = response;

            return result;
        }

        private R response;
    }
}