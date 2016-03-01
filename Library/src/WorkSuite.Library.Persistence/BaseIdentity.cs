namespace WorkSuite.Library.Persistence {

    /// <summary>
    ///    Base Entity that all WorkSuite entities will inherit from
    /// </summary>
    /// <typeparam name="I">
    ///     The entities Identity type.
    /// </typeparam>
    public class BaseEntity<I> {
        
        /// <summary>
        ///     The unique identity of the the entity
        /// </summary>
        public virtual I id { get; set; }

    }

}