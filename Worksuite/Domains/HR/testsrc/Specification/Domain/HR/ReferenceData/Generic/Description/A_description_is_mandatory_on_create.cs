using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {

    public abstract class A_description_is_mandatory_on_create<E,P,Q,C,F>
                            : MandatoryTextFieldSpecification<P,Q,F>
                    where E : ReferenceDataModel
                    where P : CreateReferenceDataRequest
                    where Q : CreateReferenceDataResponse
                    where C : ICreateReferenceData<P, Q>
                    where F : NewReferenceDataFixture<E,P,Q,C> {

        protected A_description_is_mandatory_on_create ()
            : base((request, value) => request.description = value, ValidationMessages.error_01_0003) { }
    }                 
}