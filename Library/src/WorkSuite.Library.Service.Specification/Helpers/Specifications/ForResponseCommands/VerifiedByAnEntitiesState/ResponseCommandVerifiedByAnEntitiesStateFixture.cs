using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState {

    public abstract class ResponseCommandVerifiedByAnEntitiesStateFixture<P,Q,C,E> 
                            : ResponseCommandFixture<P,Q,C>
                            , IsAResponseCommandVerifiedByAnEntitiesStateFixture<P,Q,E>
                    where Q : Response 
                    where C : ICommand<P, Q> {


        /// <summary>
        ///     The entity that the command modified or creates.
        /// </summary>
        public abstract E entity { get; }


        protected ResponseCommandVerifiedByAnEntitiesStateFixture 
            ( C the_command 
            , IRequestHelper<P> the_request_builder ) 
            : base
            ( the_command 
            , the_request_builder ) { }

    }

}