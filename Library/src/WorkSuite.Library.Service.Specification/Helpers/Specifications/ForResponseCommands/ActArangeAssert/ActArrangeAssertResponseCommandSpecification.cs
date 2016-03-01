using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.ActArangeAssert {

    /// <summary>
    ///     Specification that execute the act arrange assert pattern in the test method.
    /// Specification the descend form this just need to override the act, arrange and 
    /// assert methods.
    /// </summary>
    /// <typeparam name="P">
    ///     The type of the request that the execute method of the command expects.
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The type of the response that is returned from the execute method of the command.
    /// </typeparam>
    /// <typeparam name="F">
    ///     Fixture that will execute the command.
    /// </typeparam>
    public abstract class ActArrangeAssertResponseCommandSpecification<P,Q,F> 
                                    : ResponseCommandSpecification<P,Q,F>
                            where Q : Response 
                            where F : IsAResponseCommandFixture<P,Q> {

        [TestMethod]
        public void verify () {

            arrange();
            act();
            assert();

        }

        protected virtual void arrange () {}
        protected virtual void act () {
            
            fixture.execute_command();
        }
        protected virtual void assert () {}

    } 
}