using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit
{
    public abstract class UpdateReferenceDataEventFixture<E, P, Q, C, V> : UpdateRefereceDataFixture<E, P, Q, C>
        where E : ReferenceDataModel
        where P : UpdateReferenceDataRequest
        where Q : UpdateReferenceDataResponse
        where V : ReferenceDataUpdatedEvent
        where C : IUpdateReferenceData<P, Q>
    {

        public FakeEventPublisher<V> events_publisher { get; private set; }

        public Maybe<V> get_updated_event()
        {

            var the_event = this
                                    .events_publisher
                                    .published_events
                                    .SingleOrDefault(e => e.id == entity.id)
                                    ;

            return the_event != null
                        ? new Just<V>(the_event) as Maybe<V>
                        : new Nothing<V>()
                        ;

        }


        protected UpdateReferenceDataEventFixture
                           (C the_command
                           , IRequestHelper<P> the_request_builder
                           , IEntityRepository<E> the_repository
                            , FakeEventPublisher<V> the_events_publisher)
            : base(the_command
                   , the_request_builder
                    , the_repository)
        {

            events_publisher = Guard.IsNotNull(the_events_publisher, "the_events_publisher");
        }
    }
}