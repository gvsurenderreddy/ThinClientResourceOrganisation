using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features
{
    public class ReorderEmergencyContactWorkSuiteSpecification
                    : HRSpecification
    {

        protected override void test_setup()
        {
            base.test_setup();

            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            reorder_emergency_contact = DependencyResolver.resolve<IReorderEmergencyContact>();

            emergency_contact_one = create_emergency_contact().priority(1).entity;
            emergency_contact_two = create_emergency_contact().priority(2).entity;
            emergency_contact_three = create_emergency_contact().priority(3).entity;
            emergency_contact_four = create_emergency_contact().priority(4).entity;
            emergency_contact_five = create_emergency_contact().priority(5).entity;
            emergency_contact_six = create_emergency_contact().priority(6).entity;

            employee = employee_helper
                        .add()
                        .emergency_contact(emergency_contact_one)
                        .emergency_contact(emergency_contact_two)
                        .emergency_contact(emergency_contact_three)
                        .emergency_contact(emergency_contact_four)
                        .emergency_contact(emergency_contact_five)
                        .emergency_contact(emergency_contact_six)
                        .entity
                        ;
        }

        protected EmergencyContactBuilder create_emergency_contact()
        {
            return new EmergencyContactBuilder(new EmergencyContact());
        }

        protected EmployeeHelper employee_helper;
        protected IReorderEmergencyContact reorder_emergency_contact;

        protected EmergencyContact emergency_contact_one;
        protected EmergencyContact emergency_contact_two;
        protected EmergencyContact emergency_contact_three;
        protected EmergencyContact emergency_contact_four;
        protected EmergencyContact emergency_contact_five;
        protected EmergencyContact emergency_contact_six;

        protected Employee employee;
    }
}