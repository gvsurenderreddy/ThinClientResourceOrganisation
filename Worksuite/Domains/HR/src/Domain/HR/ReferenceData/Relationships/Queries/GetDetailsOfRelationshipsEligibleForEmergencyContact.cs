using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries
{
    public class GetDetailsOfRelationshipsEligibleForEmergencyContact : IGetDetailsOfRelationshipsEligibleForEmergencyContact
    {

        public GetDetailsOfRelationshipsEligibleForEmergencyContact(IQueryRepository<Employee> the_employee_repository
                                                            , IQueryRepository<Relationship> the_relationship_repository)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            relationship_repository = Guard.IsNotNull(the_relationship_repository, "the_relationship_repository");
        }

        public Response<IEnumerable<RelationshipDetails>> execute(EmergencyContactIdentity request)
        {
            var employee = employee_repository.Entities.Single(e => e.id == request.employee_id);

            var emergency_contact = employee.EmergencyContacts.SingleOrDefault(a => a.id == request.emergency_contact_id);

            result_set = assigned_to_emergency_contact(emergency_contact == null ? null : emergency_contact.relationship);



            var relationship_id = emergency_contact == null || emergency_contact.relationship == null ? NotSpecified.Id : emergency_contact.relationship.id;

            var relationships =
                relationship_repository.Entities
                                        .Where(r => !r.is_hidden && r.id != relationship_id)
                                        .OrderBy(r => r.description)
                                        .Select(r => new RelationshipDetails()
                                        {
                                            id = r.id,
                                            description = r.description,
                                            is_hidden = r.is_hidden
                                        });

            if (relationships.Any() || result_set.Any())
            {
                //Prepend the not specified element
                result_set = result_set.Union(not_specified());
            }

            //then append the the queried relationships
            result_set = result_set.Union(relationships);

            return new Response<IEnumerable<RelationshipDetails>>
            {
                result = result_set
            };
        }

        private IEnumerable<RelationshipDetails> assigned_to_emergency_contact(ReferenceDataModel input)
        {
            if (input == null)
            {
                return Enumerable.Empty<RelationshipDetails>();
            }
            else
            {

                return new List<RelationshipDetails>()
                    {
                        new RelationshipDetails()
                        {
                            id = input.id,
                            description = input.description,
                            is_hidden = input.is_hidden
                        }
                    };
            }
        }

        private IEnumerable<RelationshipDetails> not_specified()
        {
            yield return new RelationshipDetails
            {
                id = NotSpecified.Id,
                description = NotSpecified.Description,
            };
        }

        private IEnumerable<RelationshipDetails> result_set;
        private readonly IQueryRepository<Employee> employee_repository;
        private readonly IQueryRepository<Relationship> relationship_repository;
    }
}