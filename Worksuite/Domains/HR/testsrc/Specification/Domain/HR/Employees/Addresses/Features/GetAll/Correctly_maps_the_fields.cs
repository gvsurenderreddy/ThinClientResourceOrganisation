using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetAll;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.GetAll {

    [TestClass]
    public class Correctly_maps_the_fields : HRSpecification
    {
        [TestMethod]
        public void maps_the_address_fields()
        {
            var address = address_builder.number_or_name("A description").postcode("M33").entity;
            var employee = add_employee()
                              .forename("Fred")
                              .address(address)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();
            List<string> items = new List<string>();
            items.Add("A description");
            Assert.AreEqual(response.lines.Count(), items.Count);
            Assert.AreEqual(response.lines.ElementAt(0), items.ElementAt(0));
        }

        [TestMethod]
        public void maps_the_address_line_fields()
        {
            var address = address_builder.number_or_name("A description").postcode("M33").line1("test").entity;
            var employee = add_employee()
                              .forename("Fred")
                              .address(address)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();
            List<string> items = new List<string>();
            items.Add("A description");
            items.Add("test");
            Assert.AreEqual(response.lines.Count(), items.Count);
            Assert.AreEqual(response.lines.ElementAt(1), items.ElementAt(1));
        }

        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAllAddresses>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
            address_builder = new AddressBuilder(new Address());

        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        private AddressBuilder address_builder;
        protected IGetAllAddresses query;
        protected IEntityRepository<Employee> repository;
    }
 }