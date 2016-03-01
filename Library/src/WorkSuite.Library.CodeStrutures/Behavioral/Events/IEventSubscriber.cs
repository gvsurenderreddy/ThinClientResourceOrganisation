namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events {

    /// <summary>
    ///     Interface that subscribers that are interested in a particular event should
    /// implement.
    /// </summary>
    /// <typeparam name="S">
    ///     The event type that is being subscribed to.
    /// </typeparam>
    public interface IEventSubscriber<S> {

        /// <summary>
        ///     Will be executed by a publisher whenever it has an event it wants
        /// to published. 
        /// </summary>
        /// <param name="the_event_to_handle">
        ///     the event that is being published.
        /// </param>
        void handle
                ( S the_event_to_handle );

    }
}