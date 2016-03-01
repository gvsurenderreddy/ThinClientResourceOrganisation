using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Queries.GetAll
{
    [TestClass]
    public class GetDetailsOfAllBreaks_should_order
                    : PlannedSupplySpecification
    {
        [TestMethod]
        public void the_list_of_all_breaks_by_off_set()
        {
            var break_240 = fixture
                                    .add_break()
                                    .off_set_in_seconds(240)
                                    .entity
                                    ;

            var break_120 = fixture
                                     .add_break()
                                     .off_set_in_seconds(120)
                                     .entity
                                     ;

            var break_360 = fixture
                                    .add_break()
                                    .off_set_in_seconds(360)
                                    .entity
                                    ;

            fixture
                .execute_command()
                ;

            fixture
                .response
                .Match(

                    has_value:
                        response =>
                        {
                            var first_break_in_the_list = response[0];
                            var second_break_in_the_list = response[1];
                            var third_break_in_the_list = response[2];

                            first_break_in_the_list.off_set.hours.Should().Be(break_120.offset_from_start_time_in_seconds.to_duration_request().hours);
                            first_break_in_the_list.off_set.minutes.Should().Be(break_120.offset_from_start_time_in_seconds.to_duration_request().minutes);

                            second_break_in_the_list.off_set.hours.Should().Be(break_240.offset_from_start_time_in_seconds.to_duration_request().hours);
                            second_break_in_the_list.off_set.minutes.Should().Be(break_240.offset_from_start_time_in_seconds.to_duration_request().minutes);

                            third_break_in_the_list.off_set.hours.Should().Be(break_360.offset_from_start_time_in_seconds.to_duration_request().hours);
                            third_break_in_the_list.off_set.minutes.Should().Be(break_360.offset_from_start_time_in_seconds.to_duration_request().minutes);
                        },

                    nothing:
                        Assert.Fail

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetDetailsOfAllBreaksFixture>();
        }

        private GetDetailsOfAllBreaksFixture fixture;
    }
}