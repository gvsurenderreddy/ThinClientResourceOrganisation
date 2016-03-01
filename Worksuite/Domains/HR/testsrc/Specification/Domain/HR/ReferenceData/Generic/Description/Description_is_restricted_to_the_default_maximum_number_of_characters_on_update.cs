using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description
{
    public abstract class Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<E, P, Q, C, F>
                                            : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<P, Q, F>
                                    where E : ReferenceDataModel
                                    where P : UpdateReferenceDataRequest
                                    where Q : UpdateReferenceDataResponse
                                    where C : IUpdateReferenceData<P, Q>
                                    where F : UpdateRefereceDataFixture<E,P,Q,C>
    {

        protected Description_is_restricted_to_the_default_maximum_number_of_characters_on_update()
                : base((request, value) => request.description = value) { }
    }
}