namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events {


    /// <summary>
    ///     Interface that an event publisher should implement. 
    /// </summary>
    /// <remarks>
    ///     Different implementations of these will be different ways
    /// of publishing an event.
    /// </remarks>
    /// <typeparam name="S">
    ///     The event type that is being subscribed to.
    /// </typeparam>
    public interface IEventPublisher<S> {


        /// <summary>
        ///     Will be executed by an author whenever they want to publish an event. 
        /// </summary>
        /// <param name="event_to_publish">
        ///     the event that is being published.
        /// </param>
        void publish
                ( S event_to_publish );
    }
}