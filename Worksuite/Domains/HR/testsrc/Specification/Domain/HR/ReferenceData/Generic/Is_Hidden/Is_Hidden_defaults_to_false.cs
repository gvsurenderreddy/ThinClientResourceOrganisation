using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden {

    public abstract class Is_Hidden_defaults_to_false<R,Q,C>
                            : HRSpecification 
                    where R : CreateReferenceDataRequest
                    where Q : GetCreateReferenceDataRequestResponse<R>
                    where C : IGetCreateReferenceDataRequest<R,Q>  {


        [TestMethod]
        public void descirption_defaults_to_empty () {
            var command = DependencyResolver.resolve<C>();

            var request = command.create();

            request.result.is_hidden.Should().BeFalse();
        }
    }
}