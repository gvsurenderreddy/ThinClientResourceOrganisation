using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Formating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Formatting
{
    [TestClass]
    public class ReportFormatStringTest
    {
        [TestMethod]
        public void When_hour_is_zero()
        {
            const string hour = "0";
            const string minutes = "20";

            var expected_formating = ReportFormatStringExtension.to_domain_format_string(hour, minutes);
            const string actual_format = "20m";

            Assert.AreEqual(expected_formating,actual_format);
        }

        [TestMethod]
        public void When_minutes_is_zero()
        {
            const string hour = "20";
            const string minutes = "0";

            var expected_formating = ReportFormatStringExtension.to_domain_format_string(hour, minutes);
            const string actual_format = "20h";

            Assert.AreEqual(expected_formating, actual_format);
        }

        [TestMethod]
        public void When_hour_and_minutes_is_zero()
        {
            const string hour = "0";
            const string minutes = "0";

            var expected_formating = ReportFormatStringExtension.to_domain_format_string(hour, minutes);
            const string actual_format = "0m";

            Assert.AreEqual(expected_formating, actual_format);
        }

        [TestMethod]
        public void When_hour_and_minutes_is_not_zero()
        {
            const string hour = "20";
            const string minutes = "20";

            var expected_formating = ReportFormatStringExtension.to_domain_format_string(hour, minutes);
            const string actual_format = "20h 20m";

            Assert.AreEqual(expected_formating, actual_format);
        }
    }

   
}