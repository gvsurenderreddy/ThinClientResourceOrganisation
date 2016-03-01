using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description
{
    public abstract class Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<E, P, Q, C, F>
                                            : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<P, Q, F>
                                    where E : ReferenceDataModel
                                    where P : CreateReferenceDataRequest
                                    where Q : CreateReferenceDataResponse
                                    where C : ICreateReferenceData<P, Q>
                                    where F : NewReferenceDataFixture<E,P,Q,C>
    {

            protected Description_is_restricted_to_the_default_maximum_number_of_characters_on_create()
                : base((request, value) => request.description = value) { }
    }
}