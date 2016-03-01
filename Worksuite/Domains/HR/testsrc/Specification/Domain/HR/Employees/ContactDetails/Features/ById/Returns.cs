using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.ById 
{

    [TestClass]
    public class Returns : ByIdFixture
    {

        // return a contact details of the employee
        [TestMethod]
        public void return_a_contact_details_of_the_employee()
        {
            var employee = add_employee().entity;
            var response = execute_query(employee);

            Assert.AreEqual(employee.id, response.result.employee_id);
        }

    }

}