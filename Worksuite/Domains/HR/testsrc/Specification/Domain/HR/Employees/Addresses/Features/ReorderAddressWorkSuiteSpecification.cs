using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features
{
    public class ReorderAddressWorkSuiteSpecification
                    : HRSpecification
    {

        protected override void test_setup()
        {
            base.test_setup();

            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            reorder_address = DependencyResolver.resolve<IReorderAddress>();

            address_one = create_address().priority(1).entity;
            address_two = create_address().priority(2).entity;
            address_three = create_address().priority(3).entity;
            address_four = create_address().priority(4).entity;
            address_five = create_address().priority(5).entity;
            address_six = create_address().priority(6).entity;

            employee = employee_helper
                        .add()
                        .address(address_one)
                        .address(address_two)
                        .address(address_three)
                        .address(address_four)
                        .address(address_five)
                        .address(address_six)
                        .entity
                        ;
        }

        protected AddressBuilder create_address()
        {
            return new AddressBuilder(new Address());
        }

        protected EmployeeHelper employee_helper;
        protected IReorderAddress reorder_address;

        protected Address address_one;
        protected Address address_two;
        protected Address address_three;
        protected Address address_four;
        protected Address address_five;
        protected Address address_six;

        protected Employee employee;
    }
}