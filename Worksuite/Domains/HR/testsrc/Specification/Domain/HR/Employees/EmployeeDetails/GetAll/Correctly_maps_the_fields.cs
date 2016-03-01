using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDetails.GetAll
{
    [TestClass]
    public class Correctly_maps_the_fields : GetAllFixture
    {
        [TestMethod]
        public void maps_the_employees_forename()
        {
            var employee = add_employee()
                              .forename("Fred")
                              .entity
                              ;

            Assert.IsTrue(query.execute().result.First().forename == employee.forename);
        }

        [TestMethod]
        public void maps_the_employees_surname()
        {
            var employee = add_employee()
                              .surname("Fred")
                              .entity
                              ;

            Assert.IsTrue(query.execute().result.First().surname == employee.surname);
        }

        [TestMethod]
        public void maps_the_employees_gender_when_the_employee_has_one()
        {
            var gender = gender_helper
                            .add()
                            .description("A Gender")
                            .entity;

            var employee = add_employee()
                              .surname("Fred")
                              .gender(gender)
                              .entity
                              ;

            get_details().gender.Should().Be(gender.description);
        }

        [TestMethod]
        public void maps_the_employees_gender_when_the_employee_does_not_have_one()
        {
            var employee = add_employee()
                              .surname("Fred")
                              .entity
                              ;

            get_details().gender.Should().Be(string.Empty);
        }

        [TestMethod]
        public void maps_the_employees_job_title_when_the_employee_has_one()
        {
            var job_title = job_title_helper
                                .add()
                                .description("Business Analyst")
                                .entity;

            var employee = add_employee()
                              .surname("Fred")
                              .employee_job_title(job_title)
                              .entity
                              ;

            get_details().job_title.Should().Be(job_title.description);
        }

        [TestMethod]
        public void maps_the_employees_job_title_when_the_employee_does_not_have_one()
        {
            var employee = add_employee()
                              .surname("Fred")
                              .entity
                              ;

            get_details().job_title.Should().Be(string.Empty);
        }

        [TestMethod]
        public void maps_the_employees_location_when_the_employee_has_one()
        {
            var location = location_helper
                                .add()
                                .description("Bolton")
                                .entity;

            var employee = add_employee()
                              .surname("Fred")
                              .employee_location(location)
                              .entity
                              ;

            get_details().location.Should().Be(location.description);
        }

        [TestMethod]
        public void maps_the_employees_location_when_the_employee_does_not_have_one()
        {
            var employee = add_employee()
                              .surname("Fred")
                              .entity
                              ;

            get_details().location.Should().Be(string.Empty);
        }

        [TestMethod]
        public void correctly_maps_the_date_of_birth_when_the_employee_has_one()
        {
            var employee = add_employee()
                                .dateofbirth(DateTime.Now.AddYears(-10))
                                .entity;

            get_details().date_of_birth.Should().Be(employee.dateofbirth.FormatForReport());
        }

        [TestMethod]
        public void correctly_determines_the_age_when_the_employee_has_a_date_of_birth()
        {
            var employee = add_employee()
                                .dateofbirth(DateTime.Now.AddYears(-10))
                                .entity;

            get_details().age.Should().Be(employee.dateofbirth.ToAge());
        }

        [TestMethod]
        public void correctly_determines_the_age_when_the_employee_has_no_date_of_birth()
        {
            var employee = add_employee().entity;

            get_details().age.Should().Be(null);
        }

        [TestMethod]
        public void correctly_determines_the_addres_when_the_employee_has_an_address()
        {
            var address = address_builder
                .number_or_name("some house name")
                .postcode("some post code")
                .entity;

            var employee = add_employee()
                .address(address)
                .surname("Fred")
                .entity;

            get_details().first_address_details.First().Should().Be(address.number_or_name);
        }

        [TestMethod]
        public void correctly_determines_the_addres_when_the_employee_has_no_address()
        {
            var employee = add_employee()
                .surname("Fred")
                .entity;

            get_details().first_address_details.Should().BeEmpty();
        }

        private EmployeeDetail get_details()
        {
            return query.execute().result.First();
        }
    }
}