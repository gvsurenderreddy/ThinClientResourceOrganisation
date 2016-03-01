using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class CheckClashingBreakBetweenPeersSpecification<P, Q, F>
                                      : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IsAResponseCommandFixture<P, Q>
    {
        //preceding
        [TestMethod]
        public void when_old_break_overlapped_by_new_break_should_report_error()
        {
            verify_for(

                new DurationRequest { hours = "1", minutes = "30" },
                new DurationRequest { hours = "1", minutes = "0" }

                );
        }

        [TestMethod]
        public void when_old_break_met_by_new_break_should_not_report_error()
        {

            verify_for(

              new DurationRequest { hours = "2", minutes = "0" },
              new DurationRequest { hours = "0", minutes = "30" }

               );
        }

        [TestMethod]
        public void when_old_break_preceded_by_new_break_should_not_report_error()
        {

            verify_for(

            new DurationRequest { hours = "2", minutes = "30" },
            new DurationRequest { hours = "0", minutes = "30" }

              );
        }

        //Following

        [TestMethod]
        public void when_old_break_precedes_new_break_should_not_report_error()
        {
            verify_for(

                new DurationRequest { hours = "0", minutes = "15" },
                new DurationRequest { hours = "0", minutes = "15" }

                );
        }

        [TestMethod]
        public void when_old_break_meets_by_new_break_should_not_report_error()
        {
            verify_for(

              new DurationRequest { hours = "0", minutes = "30" },
              new DurationRequest { hours = "0", minutes = "30" }

               );
        }

        [TestMethod]
        public void when_old_break_overlaps_by_new_break_should_report_error()
        {
            verify_for(

             new DurationRequest { hours = "0", minutes = "30" },
             new DurationRequest { hours = "1", minutes = "0" }

              );
        }

        // Adjacent

        [TestMethod]
        public void when_old_break_finished_by_new_break_should_report_error()
        {
            verify_for(

                new DurationRequest { hours = "0", minutes = "30" },
                new DurationRequest { hours = "1", minutes = "30" }

               );
        }

        [TestMethod]
        public void when_old_break_contains_new_break_should_report_error()
        {
            verify_for(

              new DurationRequest { hours = "0", minutes = "30" },
              new DurationRequest { hours = "2", minutes = "30" }

             );
        }

        [TestMethod]
        public void when_old_break_starts_new_break_should_report_error()
        {
            verify_for(

              new DurationRequest { hours = "1", minutes = "0" },
              new DurationRequest { hours = "0", minutes = "30" }

             );
        }

        [TestMethod]
        public void when_old_break_equals_new_break_should_report_error()
        {

            verify_for(

              new DurationRequest { hours = "1", minutes = "0" },
              new DurationRequest { hours = "1", minutes = "0" }

             );
        }

        [TestMethod]
        public void when_old_break_started_by_new_break_should_report_error()
        {
            verify_for(

             new DurationRequest { hours = "1", minutes = "0" },
             new DurationRequest { hours = "1", minutes = "30" }

            );
        }

        [TestMethod]
        public void when_old_break_during_new_break_should_report_error()
        {
            verify_for(

             new DurationRequest { hours = "1", minutes = "30" },
             new DurationRequest { hours = "0", minutes = "10" }

            );
        }

        [TestMethod]
        public void when_old_break_finishes_new_break_should_report_error()
        {
            verify_for(

             new DurationRequest { hours = "1", minutes = "30" },
             new DurationRequest { hours = "0", minutes = "30" }

            );
        }


        protected CheckClashingBreakBetweenPeersSpecification ( Action<P, DurationRequest, DurationRequest> set_field_by ) 
                                                              : this(set_field_by, null) { }

        private CheckClashingBreakBetweenPeersSpecification( Action<P, DurationRequest, DurationRequest> set_field_by
                                                           , string the_exoected_message)
        {
            set_field = set_field_by;
            expected_message = the_exoected_message;
        }
        private void verify_for ( DurationRequest off_set
                                , DurationRequest duration)
        {
            set_field(fixture.request, off_set, duration);
            fixture.execute_command();
            assert_response_has_errors(fixture.response);
        }

        private void assert_response_has_errors
                                        (Q response)
        {
            if (!response.has_errors) return;
            response.has_errors.Should().BeTrue();
            response.messages.Count().Should().Be(5);
            response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
            response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
            response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
        }

        private Action<P, DurationRequest, DurationRequest> set_field { get; set; }
        private string expected_message { get; set; }
    }
}