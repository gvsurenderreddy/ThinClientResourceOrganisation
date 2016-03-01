using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDetails.GetAll
{
    [TestClass]
    public class Returns : GetAllFixture
    {


        [TestMethod]
        public void return_all_employees () {
            add_employee();
            add_employee();
            add_employee();

            Assert.IsTrue( query.execute( ).result.Count() == 3 );
        }

        [TestMethod]
        public void return_an_empty_set_when_there_are_no_employees () {

            Assert.IsTrue( !query.execute(  ).result.Any() );
        }

    }

}