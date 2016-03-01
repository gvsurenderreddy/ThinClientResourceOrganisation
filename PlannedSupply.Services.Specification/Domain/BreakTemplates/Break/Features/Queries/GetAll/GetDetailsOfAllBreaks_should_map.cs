using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Queries.GetAll
{
    [TestClass]
    public class GetDetailsOfAllBreaks_should_map
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void the_field_off_set_in_seconds()
        {
            var breakk = _fixture
                                .add_break()
                                .off_set_in_seconds(240)
                                .duration_in_seconds(300)
                                .is_paid(true)
                                .entity
                                ;

            _fixture
                .execute_command()
                ;

            _fixture
                .response
                .Match(

                    has_value:
                        response =>
                        {
                            var expected_off_set = breakk.offset_from_start_time_in_seconds.to_duration_request();
                            var actual_off_set = response.First().off_set;

                            Assert.AreEqual(expected_off_set.hours, actual_off_set.hours);
                            Assert.AreEqual(expected_off_set.minutes, actual_off_set.minutes);
                        },

                    nothing:
                        Assert.Fail

                );
        }

        [TestMethod]
        public void the_field_duration_in_seconds()
        {
            var breakk = _fixture
                                .add_break()
                                .off_set_in_seconds(6000)
                                .duration_in_seconds(1800)
                                .is_paid(false)
                                .entity
                                ;

            _fixture
                .execute_command()
                ;

            _fixture
                .response
                .Match(

                    has_value:
                        response =>
                        {
                            var expected_duration = breakk.duration_in_seconds.to_duration_request();
                            var actual_duration = response.First().duration;

                            Assert.AreEqual(expected_duration.hours, actual_duration.hours);
                            Assert.AreEqual(expected_duration.minutes, actual_duration.minutes);
                        },

                    nothing:
                        Assert.Fail

                );
        }

        [TestMethod]
        public void the_field_is_paid()
        {
            var breakk = _fixture
                                .add_break()
                                .off_set_in_seconds(5400)
                                .duration_in_seconds(300)
                                .is_paid(true)
                                .entity
                                ;

            _fixture
                .execute_command()
                ;

            _fixture
                .response
                .Match(

                    has_value:
                        response => response.First().is_paid.Should().BeTrue(),

                    nothing:
                        () => Assert.Fail()

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            _fixture = DependencyResolver.resolve<GetDetailsOfAllBreaksFixture>();
        }

        private GetDetailsOfAllBreaksFixture _fixture;
    }
}