using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.OrderList {

    // Is a mapping class that will map a generic element to an IListEntryIndex 
    // this is an attempt to save having to write a lot of boiler plate code 
    // that would be the same for every type that wanted to use this.
    //
    //  NOTE - if this was F# this would be about five lines of code herrrmmm!
    //
    internal class ListEntryIndexMap<T>
                    : IListEntryIndex {

        /// <inheritdoc/>
        public int postion {

            get { return get_position( element ); }
            set { set_position( element, value );  }
        }

        /// <summary>
        ///     expects a the element in the list that it is mapping to
        /// an index entry and the set and get methods that allow it to 
        /// map position property of the element to the entity.
        /// </summary>
        /// <param name="the_element">
        ///     The element that is to be mapped to an index entry
        /// </param>
        /// <param name="the_get_position">
        ///     Delegate that get current position of the element.
        /// </param>
        /// <param name="the_set_position">
        ///     Delegate that sets the current position of the element.
        /// </param>
        public ListEntryIndexMap 
                ( T the_element 
                , GetPositionMap<T> the_get_position 
                , SetPositionMap<T> the_set_position ) {
            
            element = Guard.IsNotNull( the_element, "the_element" );
            get_position = Guard.IsNotNull( the_get_position, "the_get_position" );
            set_position = Guard.IsNotNull( the_set_position, "the_set_position" );
        }

        private readonly T element;
        private readonly GetPositionMap<T> get_position;
        private readonly SetPositionMap<T> set_position;
    }
}