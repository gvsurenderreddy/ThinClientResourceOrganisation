using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.BatchOfViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Time.Periods
{
    [TestClass]
    public class ClashingListOfTimePeriod
                            : BatchOfViolationSpecification
    {

        [TestMethod]
        public void report_one_error_if_first_period_overlapped_second_period()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 18, 0, 0, 0), 46800)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 6, 0, 0, 0), 14400)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void report_one_error_if_second_period_overlapped_third_period()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 6, 0, 0, 0), 14400)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 18, 0, 0, 0),46800)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };
          
            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void report_one_error_if_first_period_enveloped_second_period()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 23, 0, 0, 0),43200)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void report_one_error_if_second_period_enveloped_third_period()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 23, 0, 0, 0),43200)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void report_tow_error_if_first_second_third_period_overlapped()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 18, 0, 0, 0),93600)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 18, 0, 0, 0),46800)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(2);
        }

        [TestMethod]
        public void report_valid_if_first_second_third_block_does_not_overlapped()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };
           var response = fixture.validator.validate(list_of_time_period);
           response.OfType<ViolationCheckResult.Valid>().Count().ShouldBeEquivalentTo(3);
        }

        [TestMethod]
        public void report_error_if_first_block_enveloped_second_and_they_are_have_same_start_and_end()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 02, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void report_error_if_first_block_enveloped_second_and_third_block()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 18, 0, 0, 0),172800)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 6, 0, 0, 0),14400)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(2);

        }

        [TestMethod]
        public void check_list_of_time_period_and_if_it_has_error_return_number_of_error()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 01, 18, 0, 0, 0),172800)
               ,new TimePeriod(new UtcTime(2014, 08, 02, 18, 0, 0, 0), 50400)
               ,new TimePeriod(new UtcTime(2014, 08, 03, 6, 0, 0, 0), 14400)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.OfType<ViolationCheckResult.BlockClashError>().Count().ShouldBeEquivalentTo(3);
        }

        [TestMethod]
        public void return_empty_if_collection_is_empty()
        {
            var request = new List<TimePeriod>();
            var response = fixture.validator.validate(request);
            response.Contains(new ViolationCheckResult());

        }

        [TestMethod]
        public void return_empty_if_blocks_in_collection_is_empty()
        {
            var list_of_time_period = new List<TimePeriod> {
                new TimePeriod(new UtcTime(2014, 08, 1, 0, 0, 0, 0) ,0)
               ,new TimePeriod(new UtcTime(2014, 08, 2, 0, 0, 0, 0) ,0)
               ,new TimePeriod(new UtcTime(2014, 08, 3, 0, 0, 0, 0) ,0)
            };

            var response = fixture.validator.validate(list_of_time_period);
            response.Contains(new ViolationCheckResult());
        }
    }
}

public class BatchOfViolationSpecification
{
    public BatchOfViolationFixture fixture { get; private set; }

    [TestInitialize]
    public void befor_each_test()
    {
        fixture = new BatchOfViolationFixture();
    }
}

public class BatchOfViolationFixture
{

    public BatchOfViolationFixture()
    {
        validator = new CheckBatchOfViolation();
    }

    public CheckBatchOfViolation validator { get; set; }
}
