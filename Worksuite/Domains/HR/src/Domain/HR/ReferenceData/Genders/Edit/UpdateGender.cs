using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Events;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit {

    public class UpdateGender
                    : UpdateReferenceData<Gender,UpdateGenderRequest,UpdateGenderResponse, GenderUpdatedEvent>
                    , IUpdateGender {

        public UpdateGender 
                    ( IUnitOfWork the_unit_of_work
                    , IEntityRepository<Gender> the_repository
                    , IEventPublisher<GenderUpdatedEvent> the_event_publisher
                    , Validator the_validator ) 
             : base 
                    ( the_unit_of_work
                    , the_repository
                    , the_event_publisher
                    , the_validator ) {}
    }
}