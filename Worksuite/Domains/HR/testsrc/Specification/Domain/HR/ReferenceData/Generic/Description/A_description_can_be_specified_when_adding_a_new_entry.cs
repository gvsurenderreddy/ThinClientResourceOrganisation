using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {


    public abstract class A_description_can_be_specified_when_adding_a_new_entry<E,P,Q,C,F> 
                            : FieldIsMappedCorrectlySpecification<P,Q,F,E> 
                    where E : ReferenceDataModel
                    where P : CreateReferenceDataRequest 
                    where Q : CreateReferenceDataResponse  
                    where C : ICreateReferenceData<P, Q>
                    where F : NewReferenceDataFixture<E,P,Q,C> {

        protected override bool validate ( P request, E entity ) {
            return request.description == entity.description;
        }

    }
}