using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.ById;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Fields.Email.GetById 
{

    [TestClass]
    public class Correctly_maps_the_fields : ByIdFixture
    {

        [TestMethod]
        public void correctly_maps_the_employee_contact_email()
        {
            var employee = add_employee()
                                .email("a@myemail.c")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.email, response.result.email);
        }

    }

}