using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDetails.GetAll {

    [TestClass]
    public class Ordering : GetAllFixture {

        [TestMethod]
        public void order_the_employees_by_surname () {
            add_employee().surname( "Fred" );
            add_employee().surname( "Albert" );
            add_employee().surname( "Zeberdier" );

            var response = query.execute().result.ToList();

            response.Should().ContainInOrder( response.OrderBy( x => x.surname ));            
        }
         

    }

}