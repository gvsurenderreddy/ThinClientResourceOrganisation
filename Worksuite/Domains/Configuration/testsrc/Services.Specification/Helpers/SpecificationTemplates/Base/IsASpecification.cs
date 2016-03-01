using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Specification.Helpers.Framework.Specification {


    // to do: rename to ASpecification

    /// <summary>
    ///     Base class for all specifications set the scope for the 
    /// dependency injection to be for each test (i.e TestContext)
    /// </summary>
    /// <remaks>
    ///     This is needed because in VS2012 once we reached about sixteen 
    /// hundred tests the MSTest test runner was re-using threads which 
    /// was the scope that we were using for unit testing.  This was causing
    /// spurious errors in 
    /// </remaks>
    [TestClass]
    public abstract class IsASpecification {

        [TestInitialize]
        public void before_each_test ( ) {
            DependencyResolver.set_scope( TestContext );

            test_setup();
        }

        /// <summary>
        ///     Called before each test is executed after the generic 
        /// initialization has been performed.
        /// </summary>
        /// <remarks>
        ///     This should be used instead of a method ascribed with
        /// the TestInitialise attribute as all specifications need to 
        /// have this specifications test initialization method run first
        /// </remarks>
        protected virtual void test_setup () { }

        /// <summary>
        ///     Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

    }

}