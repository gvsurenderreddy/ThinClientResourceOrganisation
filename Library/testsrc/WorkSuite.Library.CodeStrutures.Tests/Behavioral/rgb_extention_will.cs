using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral
{
    [TestClass]
    public class rgb_extention_will
    {
        [TestMethod]
        public void before_range()
        {
            const int befor_range = -1;
            const int start_range = 0;
            const int end_range = 100;
            befor_range.IsInRange(start_range, end_range).Should().BeFalse() ;
        }
       
        [TestMethod]
        public void start_range()
        {
            const int start_range = 0;
            const int end_range = 100;
            start_range.IsInRange(start_range, end_range).Should().BeTrue();
        }

        [TestMethod]
        public void some_number_in_the_range(int current_range)
        {
            const int some_number_in_the_range = 45;
            const int start_range = 0;
            const int end_range = 100;
            some_number_in_the_range.IsInRange(start_range, end_range).Should().BeTrue();
        }

        [TestMethod]
        public void end_range()
        {
            const int start_range = 0;
            const int end_range = 100;
            end_range.IsInRange(start_range, end_range).Should().BeTrue();
        }
        [TestMethod]
        public void after_range()
        {
            const int after_range = 101;
            const int start_range = 0;
            const int end_range = 100;
            after_range.IsInRange(start_range, end_range).Should().BeFalse();
        }
    }

}