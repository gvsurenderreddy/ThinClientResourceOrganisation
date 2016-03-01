using System;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Domain.Specification
{
    public abstract class AFieldSpecification<TBS, F> : Specification<TBS>
                                            where TBS : ITestBootstrap, new()
    {
        protected AFieldSpecification(Action<F, string> set_request_field
                                    , Action<F> act
                                    , Action<F> assert)
        {
            this.set_request_field = set_request_field;
            this.act = act;
            this.assert = assert;
        }


        protected void verify_for(string value)
        {
            var fixture = DependencyResolver.resolve<F>();

            set_request_field(fixture, value);

            act(fixture);

            assert(fixture);
        }

        

        protected readonly Action<F, string> set_request_field;
        protected readonly Action<F> act;
        protected readonly Action<F> assert;
    }
}
