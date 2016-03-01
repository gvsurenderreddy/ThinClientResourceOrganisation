using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public abstract class FieldIsMappedCorrectlySpecification< P, Q, F, E >
                                    : PlannedSupplyResponseCommandSpecification< P, Q, F >
                            where Q : Response
                            where F : IsAResponseCommandVerifiedByAnEntitiesStateFixture< P, Q, E >
    {
        [TestMethod]
        public void verfiy()
        {
            fixture.execute_command();

            validate( fixture.request, fixture.entity ).Should().BeTrue();
        }

        protected abstract bool validate( P request, E entity );
    }
}