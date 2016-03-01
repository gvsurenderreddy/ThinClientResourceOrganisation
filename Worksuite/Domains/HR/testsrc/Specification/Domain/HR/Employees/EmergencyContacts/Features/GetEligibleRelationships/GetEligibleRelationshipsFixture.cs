using WTS.WorkSuite.Persistence.Domain.HR;
using WTS.WorkSuite.Persistence.Infrastructure;
using WTS.WorkSuite.Service.HR.ReferenceData.Relationships.Queries;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.ReferenceTemplate.Relationships;
using WTS.WorkSuite.Service.Specification.Helpers.Framework.Specification;
using WTS.WorkSuite.Service.Specification.Infrastructure;

namespace WTS.WorkSuite.Service.Specification.Domain.HR.Employees.EmergencyContacts.Features.GetEligibleRelationships
{
    public class GetEligibleRelationshipsFixture : IsASpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetDetailsOfRelationshipsEligibleForEmergencyContact>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
            emergency_contact_builder = new EmergencyContactBuilder(new EmergencyContact());
            relationship_helper = DependencyResolver.resolve<RelationshipHelper>();

        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected RelationshipHelper relationship_helper;
        protected EmergencyContactBuilder emergency_contact_builder;
        protected IGetDetailsOfRelationshipsEligibleForEmergencyContact query;
        protected IEntityRepository<Employee> repository;
    }
}
