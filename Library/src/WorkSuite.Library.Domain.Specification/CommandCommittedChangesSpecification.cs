using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Domain.Specification
{

    public abstract class CommandCommitedChangesSpecification<TBS, F> : Specification<TBS>
        where TBS : ITestBootstrap, new()
    {
        protected CommandCommitedChangesSpecification(Action<F> arrange
                                                    , Action<F> execute
                                                    , Action<F> commit_was_called)
        {
            this.arrange = arrange;
            this.execute = execute;
            this.commit_was_called = commit_was_called;
        }

        [TestMethod]
        public void verify()
        {
            fixture = DependencyResolver.resolve<F>();

            arrange(fixture);

            execute(fixture);

            commit_was_called(fixture);
        }

        private readonly Action<F> arrange;
        private readonly Action<F> execute;
        private readonly Action<F> commit_was_called;

        private F fixture;
    }
}
