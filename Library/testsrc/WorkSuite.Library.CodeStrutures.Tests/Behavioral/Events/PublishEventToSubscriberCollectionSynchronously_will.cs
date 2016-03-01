using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral.Events {

    [TestClass]
    public class PublishEventToSubscriberSynchronously_will {
        
        // done: Implement IEventPublisher interface
        // done: publish the event to all subscribers

        [TestMethod]
        public void Implement_IEventPublisher_interface () {

            publisher.Should().BeAssignableTo<IEventPublisher<AnEvent>>();
        }

        [TestMethod]
        public void pusblish_the_event_to_all_subscribers () {
            var the_event = new AnEvent();

            publisher.publish( the_event );

            subscribers.All( s => s.handled_event == the_event ).Should().BeTrue();
        }

        [TestInitialize]
        public void before_each_test () {
            subscribers = new[] {
                new AnEventSubscriber(),
                new AnEventSubscriber(),
            };
            publisher = new PublishEventToSubscriberSynchronously<AnEvent>( subscribers );
        }

        private PublishEventToSubscriberSynchronously<AnEvent> publisher;
        private IEnumerable<AnEventSubscriber> subscribers;


        private class AnEvent {}

        private class AnEventSubscriber
                        : IEventSubscriber<AnEvent> {

            public void handle ( AnEvent the_event_to_handle ) {
                handled_event = the_event_to_handle;
            }

            public AnEvent handled_event;
        }
    }
}