using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates {

    [TestClass]
    public class ASpecification<B>
                    where B : TestBootstrapper, new() {


        [TestInitialize]
        public void before_each_test () {
            bootstrapper.setup( m => TestContext );
            test_setup();
        }

        [TestCleanup]
        public void after_each_test () {
            bootstrapper.teardown( TestContext );
        }
        
        /// <summary>
        ///     Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///     Called before each test allows setup to be done before
        /// a test is executed.
        /// </summary>
        protected virtual void test_setup() {}

        protected B bootstrapper = new B();

    }


}