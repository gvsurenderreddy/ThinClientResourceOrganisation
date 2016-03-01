using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Domain.Specification
{

    public abstract class CommandPublishedEventSpecification<TBS, F> : Specification<TBS>
        where TBS : ITestBootstrap, new()
    {
        protected CommandPublishedEventSpecification(Action<F> arrange
                                                    , Action<F> execute
                                                    , Action<F> event_was_published)
        {
            this.arrange = arrange;
            this.execute = execute;
            this.event_was_published = event_was_published;
        }



        [TestMethod]
        public void verify()
        {
            fixture = DependencyResolver.resolve<F>();

            arrange(fixture);

            execute(fixture);

            event_was_published(fixture);
        }

        private readonly Action<F> arrange;
        private readonly Action<F> execute;
        private readonly Action<F> event_was_published;

        private F fixture;
    }
}
