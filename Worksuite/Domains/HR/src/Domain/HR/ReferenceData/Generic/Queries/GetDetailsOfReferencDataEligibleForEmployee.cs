using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries {

    public abstract class GetDetailsOfReferencDataEligibleForEmployee<E,D> 
                            : IGetDetailsOfReferencDataEligibleForEmployee<D>  
                    where E : ReferenceDataModel
                    where D : ReferenceDataDetails, new( ) {

        public Response<IEnumerable<D>> execute 
                                            ( EmployeeIdentity request ) {
            
            return set_request( request )
                       .include_assign_to_employee_in_result_set()
                       .inlcude_not_specified_in_result_set()  
                       .include_not_hidden_in_result_set()
                       .response()
                       ;
        }


        protected GetDetailsOfReferencDataEligibleForEmployee 
                    ( IQueryRepository<Employee> the_employee_repository 
                    , IQueryRepository<E> the_entity_repository 
                    ) {

            employee_repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            title_repository = Guard.IsNotNull( the_entity_repository, "the_title_repository" );
        }

        /// <summary>
        ///     Returns the entities that are assigned to the employee
        /// </summary>
        /// <param name="employee">
        ///     The employee to get the entities from.
        /// </param>
        /// <returns>
        ///     All the entities assigned to the specified employee.
        /// </returns>
        protected abstract IEnumerable<E> get_entry_assigned_to_employee( IEnumerable<Employee> employee );


        private GetDetailsOfReferencDataEligibleForEmployee<E,D> set_request 
                                                                    ( EmployeeIdentity request ) {
            Guard.IsNotNull( request, "request" );

            employees = employee_repository
                            .Entities
                            .Where( e => e.id == request.employee_id );

            result_set = new List<D>();

            return this;
        }

        private GetDetailsOfReferencDataEligibleForEmployee<E,D> include_assign_to_employee_in_result_set () {
            if ( employees == null) return this;
            
            assigned = get_entry_assigned_to_employee( employees )
                            .Where(  e => e != null )
                            .ToList();

            result_set = result_set
                            .Union( assigned.Select( map.Compile() ));

            return this;
        }

        private GetDetailsOfReferencDataEligibleForEmployee<E,D> inlcude_not_specified_in_result_set () {
            if (employees == null) return this;

            result_set = result_set
                            .Union( not_specified() );

            return this;
        }

        private IEnumerable<D> not_specified () {
            
            // Improve: change use a null title factory and then pass it through the mapper
            yield return new D {
                id = NotSpecified.Id,
                description = NotSpecified.Description,
            };
        }

        private GetDetailsOfReferencDataEligibleForEmployee<E,D> include_not_hidden_in_result_set () {
            if (employees == null) return this;

            Guard.IsNotNull( assigned, "assigned" );

            // Note this does not work if you put the statement directly inside the 
            //      the LINQ expression.
            var excluded = assigned.Select( a => a.id );

            var not_hidden = title_repository
                                .Entities
                                .Where( t => !t.is_hidden )
                                .Where( t => !excluded.Any( a => a == t.id  ))
                                .OrderBy( t => t.description )
                                .Select( map )
                                .ToList(  )
                                ;

            result_set = result_set
                            .Union( not_hidden );

            return this;
        }

        private Response<IEnumerable<D>> response () {

            return new Response<IEnumerable<D>> {

                result = get_result_set_to_present_to_client()
            };            
        }


        private IEnumerable<D> get_result_set_to_present_to_client () {

            // if there are no entries then return an empty result set
            return only_contains_the_not_specified_element( result_set ) ? new D[]{} : result_set;
        }

        private bool only_contains_the_not_specified_element 
                        ( IEnumerable<D> elements_to_check ) {

            if ( elements_to_check != null) {
                return result_set.Count() == 1 && result_set.Any( t => t.id == NotSpecified.Id );
            }
            return false;
        }

        private readonly Expression<Func<E,D>> map = title => 
                                                     // to do: change this use a mapper that is passed in
                                                     new D {
                                                         id = title.id,
                                                         description = title.description,
                                                         is_hidden = title.is_hidden,
                                                     };

        // result set that is returned in the response
        private IEnumerable<D> result_set;

        // the employee to get eligible entities for        
        private IEnumerable<Employee> employees;

        // the entities that have been assigned to the employee
        private IEnumerable<E> assigned;

        private readonly IQueryRepository<Employee> employee_repository;
        private readonly IQueryRepository<E> title_repository;

    }
}