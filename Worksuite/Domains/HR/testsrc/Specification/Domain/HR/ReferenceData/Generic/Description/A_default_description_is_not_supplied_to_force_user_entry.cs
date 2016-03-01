using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {

    public abstract class A_default_description_is_not_supplied_to_force_user_entry<R,Q,C>
                    : HRSpecification 
            where R : CreateReferenceDataRequest
            where Q : GetCreateReferenceDataRequestResponse<R>
            where C : IGetCreateReferenceDataRequest<R,Q>  {

        [TestMethod]
        public void descirption_defaults_to_empty () {
            C command;
            command = DependencyResolver.resolve<C>();

            var request = command.create();

            request.result.description.Should().BeEmpty();
        }
    }
}