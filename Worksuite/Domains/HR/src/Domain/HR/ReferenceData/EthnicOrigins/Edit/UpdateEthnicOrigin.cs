using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Events;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit
{
    public class UpdateEthnicOrigin
                        :   UpdateReferenceData< EthnicOrigin, UpdateEthnicOriginRequest, UpdateEthnicOriginResponse, EthnicOriginUpdatedEvent >,
                            IUpdateEthnicOrigin
    {
        public UpdateEthnicOrigin(  IUnitOfWork the_unit_of_work,
                                    IEntityRepository< EthnicOrigin > the_repository,
                                    IEventPublisher<EthnicOriginUpdatedEvent> the_update_reference_data_event_publisher,
                                    Validator the_validator
                                 )
                        :   base(   the_unit_of_work,
                                    the_repository,
                                    the_update_reference_data_event_publisher,
                                    the_validator
                                ) {}
    }
}