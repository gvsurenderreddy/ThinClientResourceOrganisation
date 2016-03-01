using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WorkSuite.Library.Service.Specification.Helpers.Entity {

    public class FakeEventPublisher<T> 
                    : IEventPublisher<T> {

        public void publish 
                        ( T event_to_publish ) {
            
            published_events
                .Add( event_to_publish )
                ;

        }

        public readonly List<T> published_events = new List<T>();
    }
}