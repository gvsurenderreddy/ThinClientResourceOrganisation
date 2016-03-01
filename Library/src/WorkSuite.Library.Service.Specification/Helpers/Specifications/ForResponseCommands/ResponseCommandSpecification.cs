using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands {


    /// <summary>
    ///     Specifications that execute against command that can be verified
    /// against the response from a command.
    /// </summary>
    /// <typeparam name="P">
    ///     The request expected from the command
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The response expected from the command
    /// </typeparam>
    /// <typeparam name="F">
    ///     The fixture for the specification. It must be a <see cref="IsAResponseCommandFixture{P,Q}" />
    /// </typeparam>
    public abstract class ResponseCommandSpecification<P,Q,F>
                            : Specification
                    where Q : Response
                    where F : IsAResponseCommandFixture<P,Q> {


        protected override void test_setup ( ) {
            fixture = DependencyResolver.resolve<F>(  );            
        }        

        protected F fixture { get; private set; }
    }
}