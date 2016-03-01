using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.GetUpdateRequestCommand {

    [TestClass]
    public class Correctly_maps_the_fields : IsAGetUpdateRequestWorkSuiteSpecification {

        // emploayee id
        // forename
        // surename
        // title
        // email
        // nationality

        [TestMethod]
        public void map_the_employee_id_correctly () {

            update_request.result.employee_id.Should().Be( employee.entity.id );
        }


        [TestMethod]
        public void map_the_forename_correctly () {
            employee
                .forename( "Fred" )
                ;

            update_request.result.forename.Should().Be( employee.entity.forename );
        }

        [TestMethod]
        public void map_the_surname_correctly () {
            employee
                .surname( "Smith" )
                ;

            update_request.result.surname.Should().Be( employee.entity.surname );
        }

        [TestMethod]
        public void map_the_place_of_birth_correctly()
        {
            employee
                .birthplace("Manchester")
                ;

            update_request.result.birth_place.Should().Be(employee.entity.birth_place);
        }

        [TestMethod]
        public void map_a_null_title_to_not_specified () {

            update_request.result.title_id.Should().Be( NotSpecified.Id ); 
        }


        [TestMethod]
        public void map_title_to_the_the_title_id () {
            employee
                .title( titles.add().entity );

            update_request.result.title_id.Should().Be( employee.entity.title.id ); 
        }
        [TestMethod]
        public void map_maritalStatus_to_the_maritalStatus_id()
        {
            employee
                .maritalStatus(maritalStatus_helper.add().description("A MaritalStatus").entity);

            update_request.result.marital_status_id.Should().Be(employee.entity.maritalStatus.id);
        }
        [TestMethod]
        public void map_nationality_to_the_nationality_id()
        {
            employee
                .nationality( nationality_helper.add().description("A Nationality").entity );

            update_request.result.nationality_id.Should().Be( employee.entity.nationality.id );
        }

        [TestMethod]
        public void map_ethnic_origin_to_the_ethnic_origin_id()
        {
            employee
                .ethnic_origin(ethnic_origin_helper.add().description("An Ethnic Origin").entity);

            update_request.result.ethnic_origin_id.Should().Be(employee.entity.ethnicOrigin.id);
        }

        [TestMethod]
        public void map_dateofbirth_correctly()
        {
            employee.dateofbirth( DateTime.Now.AddYears(-20) );
            
            var date_of_birth = update_request.result.date_of_birth;

            date_of_birth.day.Should().Be( employee.entity.dateofbirth.Value.Day.ToString() );
            date_of_birth.month.Should().Be( employee.entity.dateofbirth.Value.Month.ToString() );
            date_of_birth.year.Should().Be( employee.entity.dateofbirth.Value.Year.ToString() );
        }

        [TestMethod]
        public void map_dateofbirth_when_not_specified_correctly()
        {
            employee.dateofbirth( null );
            
            var date_of_birth = update_request.result.date_of_birth;

            date_of_birth.day.Should().Be( string.Empty );
            date_of_birth.month.Should().Be( string.Empty );
            date_of_birth.year.Should().Be( string.Empty );
        }


        protected override void test_setup()
        {
            base.test_setup();

            titles = DependencyResolver.resolve< TitleHelper > ();
            maritalStatus_helper = DependencyResolver.resolve<MaritalStatusHelper>();
            nationality_helper = DependencyResolver.resolve< NationalityHelper > ();
            ethnic_origin_helper = DependencyResolver.resolve< EthnicOriginHelper > ();
        }

        private TitleHelper titles;
        private MaritalStatusHelper maritalStatus_helper;
        private NationalityHelper nationality_helper;
        private EthnicOriginHelper ethnic_origin_helper;

    }
}