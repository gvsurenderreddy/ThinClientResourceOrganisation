using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit
{


    /// <summary>
    ///     Base test fixture for all concrete update reference data commands that
    /// have been created from the generic templates.
    /// </summary>
    /// <typeparam name="E">
    ///     The concrete reference data template type, must be inherited from 
    ///     <see cref="ReferenceDataModel"/>
    /// </typeparam>
    /// <typeparam name="P">
    ///     The concrete create reference data request type, must be inherited from
    ///     <see cref="UpdateReferenceDataRequest"/>
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The concrete create reference data response type, must be inherited from
    ///     <see cref="UpdateReferenceDataResponse"/>
    /// </typeparam>
    /// <typeparam name="C">
    ///     The concrete create reference data command type, must be inherited from
    ///     <see cref=IUpdateReferenceData'2{P,Q}"/>
    /// </typeparam>
    public abstract class UpdateRefereceDataFixture<E, P, Q, C>
                            : ResponseCommandVerifiedByAnEntitiesStateFixture<P, Q, C, E>
        where E : ReferenceDataModel
        where P : UpdateReferenceDataRequest
        where Q : UpdateReferenceDataResponse
        where C : IUpdateReferenceData<P, Q>
    {


        public override E entity
        {
            get
            {
                return repository
                        .Entities
                        .SingleOrDefault(t => t.id == request.id);
            }
        }


        protected UpdateRefereceDataFixture
                           (C the_command
                           , IRequestHelper<P> the_request_builder
                           , IEntityRepository<E> the_repository)
            : base(the_command
                   , the_request_builder)
        {

            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IEntityRepository<E> repository;
    }

}