using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.ById
{

    [TestClass]
    public class Correctly_maps_the_fields : ByIdFixture
    {

        [TestMethod]
        public void correctly_maps_the_employee_forename()
        {
            var employee = add_employee()
                                .forename("Fred")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.forename, response.result.forename);
        }

        [TestMethod]
        public void correctly_maps_the_employees_surname()
        {
            var employee = add_employee()
                                .surname("Smith")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.surname, response.result.surname);

        }

        // title if specified
        [TestMethod]
        public void correctly_maps_the_title_when_the_employee_has_one()
        {
            var title = title_helper
                            .add()
                            .description("A Description")
                            .entity;

            var employee = add_employee()
                                .surname("Smith")
                                .title(title)
                                .entity;

            var response = execute_query(employee);

            response.result.title.Should().Be(title.description);
        }

        // title if not specified
        [TestMethod]
        public void correctly_maps_the_title_when_the_employee_does_not_have_one()
        {

            var employee = add_employee()
                                .surname("Smith")
                                .entity;

            var response = execute_query(employee);

            response.result.title.Should().Be(string.Empty);
        }

        // maritalStatus if specified
        [TestMethod]
        public void correctly_maps_the_maritalStatus_when_the_employee_has_one()
        {
            var maritalStatus = maritalStatus_helper
                            .add()
                            .description("A MartialStatus")
                            .entity;

            var employee = add_employee()
                                .surname("Smith")
                                .maritalStatus(maritalStatus)
                                .entity;

            var response = execute_query(employee);

            response.result.maritalStatus.Should().Be(maritalStatus.description);
        }

        // maritalStatus if not specified
        [TestMethod]
        public void correctly_maps_the_maritalStatus_when_the_employee_does_not_have_one()
        {

            var employee = add_employee()
                                .surname("Smith")
                                .entity;

            var response = execute_query(employee);

            response.result.maritalStatus.Should().Be(string.Empty);
        }

        [TestMethod]
        public void correctly_maps_the_place_of_birth_when_the_employee_has_one()
        {
            var employee = add_employee()
                                .birthplace("Manchester")
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.birth_place, response.result.birth_place);
        }

        [TestMethod]
        public void correctly_maps_the_date_of_birth_when_the_employee_has_one()
        {
            var employee = add_employee()
                                .dateofbirth(DateTime.Now.AddYears(-10))
                                .entity;

            var response = execute_query(employee);

            Assert.AreEqual(employee.dateofbirth.FormatForReportIncludeAge(), response.result.date_of_birth);
        }

        // nationality if specified
        [TestMethod]
        public void correctly_maps_the_nationality_when_the_employee_has_one()
        {
            var nationality = nationality_helper
                            .add()
                            .description( "A Nationality" )
                            .entity;

            var employee = add_employee()
                                .surname( "Smith" )
                                .nationality( nationality )
                                .entity;

            var response = execute_query( employee );

            response.result.nationality.Should().Be( nationality.description );
        }

        // nationality if not specified
        [TestMethod]
        public void correctly_maps_the_nationality_when_the_employee_does_not_have_one()
        {

            var employee = add_employee()
                                .surname( "Smith" )
                                .entity;

            var response = execute_query( employee );

            response.result.nationality.Should().Be( string.Empty );
        }

        // ethnic origin if specified
        [TestMethod]
        public void correctly_maps_the_ethnic_origin_when_the_employee_has_one()
        {
            var ethnic_origin = ethnic_origin_helper
                            .add()
                            .description( "An Ethnic Origin" )
                            .entity;

            var employee = add_employee()
                                .surname( "Smith" )
                                .ethnic_origin( ethnic_origin )
                                .entity;

            var response = execute_query( employee );

            response.result.ethnic_origin.Should().Be( ethnic_origin.description );
        }

        // ethnic origin if not specified
        [TestMethod]
        public void correctly_maps_the_ethnic_origin_when_the_employee_does_not_have_one()
        {

            var employee = add_employee()
                                .surname( "Smith" )
                                .entity;

            var response = execute_query( employee );

            response.result.ethnic_origin.Should().Be( string.Empty );
        }

    }

}