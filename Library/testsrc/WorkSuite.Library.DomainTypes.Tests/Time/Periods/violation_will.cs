using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.OneViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Time.Periods
{
    [TestClass]
    public class violation_will
                             : violationSpecification
    {
        // (done) previous time period does not run into next period . 
        // (done) period is not envelope by previous time period.
        // (done) current period is not envelope by previouse period .

        [TestMethod]
        public void previous_period_can_not_run_into_next_period()
        {
            var request = fixture.request();

            request = fixture.when_first_period_run_into_the_next_period(request);

            fixture.validator.execute(request)
                   .Match(
                      is_valid:
                          Violation => Assert.Fail("Invalid time period was identified as valid"),
                      is_not_valid:
                          errors => new ViolationCheckResult.BlockClashError());
        }

        [TestMethod]
        public void firact_period_can_not_envelope_second_period()
        {
            var request = fixture.request();
            request = fixture.create_block_that_envelopes_by_previous_block(request);
            var response = fixture.validator.execute(request);

            response.Match(
                is_valid:
                    mid_block_time_period => Assert.Fail("Invalid time period was identified as valid"),

                is_not_valid:
                    errors => new ViolationCheckResult.BlockClashError());
        }

        [TestMethod]
        public void first_period_and_second_period_can_not_have_same_start_and_end_time ()
        {
            var request = fixture.request();

            var violation_request = fixture.create_two_period_which_have_same_start_and_end_time(request);

            fixture.validator.execute(violation_request)
                .Match(
                is_valid:
                    mid_block_time_period => Assert.Fail("Invalid time period was identified as valid"),

                is_not_valid:
                    errors => new ViolationCheckResult.BlockClashError());
        }
    }

    [TestClass]
    public class previous_and_middle_block_should_be_valid
                                            : violationSpecification
    {

        [TestMethod]
        public void valid_previouse_middle_and_next_block_should_not_show_error()
        {
            var request = fixture.request();

            fixture.validator.execute(request)
                .Match(

                     is_valid:
                        violation => new ViolationCheckResult.Valid(),
                      is_not_valid:
                          errors => new ViolationCheckResult.BlockClashError());
        }
    }

    public class violationSpecification
    {
        public violationFixture fixture { get; private set; }

        [TestInitialize]
        public void befor_each_test()
        {
            fixture = new violationFixture();
        }
    }

    public class violationFixture
    {
        public CheckOneViolation validator { get; set; }

        public violationRequest request()
        {
            return new violationRequest
            {
                first = new TimePeriod (new UtcTime(2014, 08, 03, 18, 0, 0, 0), 43200),
                second = new TimePeriod(new UtcTime(2014, 08, 04, 6, 0, 0, 0), 21600)
               
            };
        }

        public violationRequest when_first_period_run_into_the_next_period(violationRequest request)
        {
            request.first=new TimePeriod(new UtcTime(2014, 08, 03, 18, 0, 0, 0),50400);
            return new  violationRequest  {first = request.first, second = request.second, };
        }

        public violationRequest create_block_that_envelopes_by_previous_block(violationRequest request)
        {
            request.second=new TimePeriod(new UtcTime(2014, 08, 04, 0, 0, 0, 0),14400);
            return new violationRequest{first = request.first,second = request.second};
        }

        public violationRequest create_two_period_which_have_same_start_and_end_time(violationRequest request)
        {
            request.second=new TimePeriod(new UtcTime(2014, 08, 04, 0, 0, 0, 0),28800);

            request.first= new TimePeriod(new UtcTime(2014, 08, 04, 0, 0, 0, 0),21600);
            return new violationRequest {first = request.first,second = request.second,};
        }

        public violationFixture()
        {
            validator = new CheckOneViolation();
        }
    }
}