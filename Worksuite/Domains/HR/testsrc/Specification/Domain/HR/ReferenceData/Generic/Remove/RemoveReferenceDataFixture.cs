using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove {

    /// <summary>
    ///     Base test fixture for all concrete remove reference data commands that
    /// inherit from the generic templates.
    /// </summary>
    /// <typeparam name="A">
    ///     The concrete reference data template type, must be inherited from 
    ///     <see cref="ReferenceDataModel"/>
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The concrete create reference data response type, must be inherited from
    ///     <see cref="RemoveReferenceDataResponse"/>
    /// </typeparam>
    /// <typeparam name="C">
    ///     The concrete create reference data command type, must be inherited from
    ///     <see cref=IRemoveReferenceData'1{Q}"/>
    /// </typeparam>
    public abstract class RemoveRefereceDataFixture<P,Q,C>
                            : ResponseCommandFixture<P,Q,C>
                    where P : RemoveReferenceDataRequest
                    where Q : RemoveReferenceDataResponse
                    where C : IRemoveReferenceData<P,Q> {

        protected RemoveRefereceDataFixture 
                           ( C the_command
                           , IRequestHelper<P> the_request_builder ) 
                    : base ( the_command
                           , the_request_builder ) {}

    }

}