using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit
{
    [TestClass]
    public class Update_break_fixture_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_break_entity()
        {
            Breaks.Break the_break = _fixture.entity;
            Assert.IsTrue(the_break.id != 0);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _fixture = DependencyResolver.resolve<UpdateBreakFixture>();
        }

        private UpdateBreakFixture _fixture;
    }
}