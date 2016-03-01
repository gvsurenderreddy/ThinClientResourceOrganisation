﻿using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.GetAll;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.GetAll
{
    public class GetAllFixture : HRSpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAllEmergencyContacts>();
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
        protected IGetAllEmergencyContacts query;
        protected IEntityRepository<Employee> repository;
    }
}
