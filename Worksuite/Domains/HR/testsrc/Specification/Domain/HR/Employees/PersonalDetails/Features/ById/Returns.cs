using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.ById {

    [TestClass]
    public class Returns : ByIdFixture  {

        // return a personal details of the employee
        [TestMethod]
        public void return_a_personal_details_of_the_employee ( ) {
            var employee = add_employee(  ).entity;
            var response = execute_query( employee );

            Assert.AreEqual( employee.id, response.result.employee_id );
        }

        // to do: if the employee does not exist
        // to do: if we have an internal error what do we do

        // to do: pain all the set up, fun the two test that implemented business logic

    }

}