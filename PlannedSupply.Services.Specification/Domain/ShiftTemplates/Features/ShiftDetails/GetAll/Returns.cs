using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.ShiftDetails.GetAll
{
    [TestClass]
    public class Returns
                 : GetAllFixture
    {
        [TestMethod]
        public void should_return_empty_if_there_is_no_shift_template()
        {
            Assert .IsTrue(!query.execute( ).result.Any());
        }

        [TestMethod]
        public void return_all_shift_template()
        {
            add_shift_template();
            add_shift_template();

            Assert.IsTrue(query.execute( ).result.Count() == 2);
        }
    }
}