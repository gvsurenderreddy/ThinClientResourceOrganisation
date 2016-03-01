using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    /// <summary>
    ///     Verifies that a command has committed changes 
    /// </summary>
    /// <typeparam name="P">
    ///     Request type
    /// </typeparam>
    /// <typeparam name="Q">
    ///     Response type
    /// </typeparam>
    /// <typeparam name="F">
    ///     Fixture that matched the supplied response and request types
    /// </typeparam>
    public abstract class CommandCommitedChangesSpecification< P, Q, F >
                            : PlannedSupplyResponseCommandSpecification< P, Q, F >
                    where Q : Response
                    where F : IsAResponseCommandFixture< P, Q >
    {
        [TestMethod]
        public void verfiy()
        {

            fixture.execute_command();

            unit_of_work.commit_was_called.Should().BeTrue();
        }

        protected override void test_setup()
        {
            base.test_setup();

            unit_of_work = DependencyResolver.resolve< FakeUnitOfWork >();
        }

        private FakeUnitOfWork unit_of_work;
    }
}