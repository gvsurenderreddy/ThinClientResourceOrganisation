using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Service.Specification.Helpers.Specifications {


    [TestClass]
    public class Specification<TBS> 
                            where TBS : ITestBootstrap, new()
    {

        [TestInitialize]
        public void before_each_test()
        {
            TestBootstrapper.execute(test_boot_strap, TestContext);
        }

        public TestContext TestContext { get; set; }

        private readonly TBS test_boot_strap = new TBS();
    }

    public class TestBootstrapper
    {
        public static void execute(ITestBootstrap test_boot_strap, TestContext test_context)
        {
            //  todo: explain why we are doing this in this way because it is not entierly transparent.
            lock (guard)
            {
                if (!test_run_has_been_setup_and_domain_has_been_configured)
                {
                    test_boot_strap.setup_before_all_tests(test_context);
                    test_run_has_been_setup_and_domain_has_been_configured = true;
                }
            }
            test_boot_strap.setup_before_each_test(test_context);
        }

        public static bool test_run_has_been_setup_and_domain_has_been_configured = false;
        public static object guard = new object();
    }


    [TestClass]
    public abstract class Specification : ITestBootstrap
    {
        [TestInitialize]
        public void before_each_test ( ) 
        {
            TestBootstrapper.execute(this, TestContext);

            test_setup();
        }

        public TestContext TestContext { get; set; }

        public void setup_before_all_tests(object context)
        {
            configure_once_before_all_tests_are_run(DependencyResolver.kernel, m => TestContext);
        }

        public void setup_before_each_test(object context)
        {
            configure_once_before_each_test_is_run(DependencyResolver.kernel, m => TestContext);
        }

        protected abstract void configure_once_before_each_test_is_run
                                    (IKernel kernel
                                    , Func<IContext, object> scope);


        protected abstract void configure_once_before_all_tests_are_run
                                    (IKernel kernel
                                    , Func<IContext, object> scope);

        protected virtual void test_setup() { }
    }

    public interface ITestBootstrap
    {

        /// <summary>
        /// Classes that implement this method that should be run once per test run implement this interface.
        ///     Is executed once per testrun, descendent should implement any test run configuration
        /// in this method.
        /// </summary>
        /// <param name="context">Context object that will live for the lifetime of the test run</param>
        void setup_before_all_tests
              (object context);


        /// <summary>
        /// Classes that implement setup that shouldbe run once per test implement this interface and are then
        /// use to close a type on a generic specification.
        /// 
        ///     Descendents should implement any setup that they want applied before each test.  It is expected that this
        /// would be general setup that is applied to all test rather than test specific setup, test specific setup should
        /// be defined within the test itself so that anyone reading the test can fully understand it.
        /// </summary>
        /// <param name="context">Context object that will live for the lifetime of the test.</param>
        void setup_before_each_test
              (object context);
    }
}