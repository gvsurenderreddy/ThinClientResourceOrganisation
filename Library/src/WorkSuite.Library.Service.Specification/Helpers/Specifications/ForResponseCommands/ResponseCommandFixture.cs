using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands {

    public abstract class ResponseCommandFixture<P,Q,C> 
                            : IsAResponseCommandFixture<P, Q> 
                    where Q : Response 
                    where C : ICommand<P,Q> {


        /// <summary>
        ///     The request is used as the argument for the command 
        /// and the response is set to what is returned from executing the command.        
        /// </summary>
        public virtual void execute_command ( ) {

            response = command.execute( request );
        }

        public P request { get; private set; }
        public Q response { get; private set; }

        protected ResponseCommandFixture 
                    ( C the_command 
                    , IRequestHelper<P> the_request_builder ) {
            
            command = the_command;
            request = the_request_builder.given_a_valid_request(  );
        }

        private readonly C command;
    }
}