using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.ById 
{

    [TestClass]
    public class Correctly_maps_the_fields : ByIdFixture
    {

        [TestMethod]
        public void correctly_maps_the_employee_phone()
        {
            var employee = add_employee()
                                .forename("Fred")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.phone_number, response.result.phone);
        }


        [TestMethod]
        public void correctly_maps_the_email_when_employee_contact_has_one()
        {
            var employee = add_employee().email("a@his.c")
                                         .entity;

            var response = execute_query(employee);


            Assert.AreEqual(employee.email, response.result.email);
        }

        [TestMethod]
        public void correctly_maps_the_employee_mobile()
        {
            var employee = add_employee()
                                .forename("Fred")
                                .mobile("077 88 99")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.mobile, response.result.mobile);
        }

        [TestMethod]
        public void correctly_maps_the_employee_contact_other()
        {
            var employee = add_employee()
                                .forename("Fred")
                                .other("something to note down here ...")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.mobile, response.result.mobile);
        }
    }

}