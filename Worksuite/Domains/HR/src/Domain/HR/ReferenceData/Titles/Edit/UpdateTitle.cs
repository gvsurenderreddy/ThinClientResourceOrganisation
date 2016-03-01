using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit
{

    public class UpdateTitle
                    : UpdateReferenceData<Title, UpdateTitleRequest, UpdateTitleResponse, TitleUpdatedEvent>
                    , IUpdateTitle
    {

        public UpdateTitle
                    (IUnitOfWork the_unit_of_work
                    , IEntityRepository<Title> the_repository
                    , IEventPublisher<TitleUpdatedEvent> the_event_publisher
                    , Validator the_validator)
            : base
                   (the_unit_of_work
                   , the_repository
                    , the_event_publisher
                   , the_validator) { }
    }
}