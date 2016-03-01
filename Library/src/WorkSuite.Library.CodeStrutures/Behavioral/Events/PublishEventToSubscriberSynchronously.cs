using System.Collections.Generic;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events {

    public class PublishEventToSubscriberSynchronously<S>
                    : IEventPublisher<S> {

        public void publish ( S event_to_publish ) {

            subscribers.Do( s => {
                // Improve: when we get an logging system report errors to a log
                //          for now just swallow them as we do not want exceptions in
                //          one event stopping other events from being published
                try { s.handle( event_to_publish );  } catch { }

            } );            
        }

        public PublishEventToSubscriberSynchronously
                ( IEnumerable<IEventSubscriber<S>> the_subscribers ) {

            subscribers = Guard.IsNotNull( the_subscribers, "the_subscribers " );
        }

        // subscribers that will be notified when an event is published
        private readonly IEnumerable<IEventSubscriber<S>> subscribers;
    }
}