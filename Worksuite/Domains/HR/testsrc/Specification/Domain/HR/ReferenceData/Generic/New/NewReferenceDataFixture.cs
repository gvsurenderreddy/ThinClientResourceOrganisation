using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Base test fixture for all concrete create reference data command that
    /// have been created from the generic templates.
    /// </summary>
    /// <typeparam name="E">
    ///     The concrete reference data template type, must be inherited from 
    ///     <see cref="ReferenceDataModel"/>
    /// </typeparam>
    /// <typeparam name="P">
    ///     The concrete create reference data request type, must be inherited from
    ///     <see cref="CreateReferenceDataRequest"/>
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The concrete create reference data response type, must be inherited from
    ///     <see cref="CreateReferenceDataResponse"/>
    /// </typeparam>
    /// <typeparam name="C">
    ///     The concrete create reference data command type, must be inherited from
    ///     <see cref=ICreateReferenceData'2{P,Q}"/>
    /// </typeparam>
    public abstract class NewReferenceDataFixture<E,P,Q,C>  
                            : ResponseCommandVerifiedByAnEntitiesStateFixture<P,Q,C,E> 
                    where E : ReferenceDataModel            
                    where P : CreateReferenceDataRequest
                    where Q : CreateReferenceDataResponse             
                    where C : ICreateReferenceData<P,Q> {

        public override E entity {
            get { return repository.Entities.SingleOrDefault( t => t.id == response.result.id  ); }
        }


        protected NewReferenceDataFixture 
                       ( C the_command
                       , IRequestHelper<P> the_request_builder
                       , IEntityRepository<E> the_repository ) 
                : base ( the_command
                       , the_request_builder ) {
            
            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        private readonly IEntityRepository<E> repository;
    }
}