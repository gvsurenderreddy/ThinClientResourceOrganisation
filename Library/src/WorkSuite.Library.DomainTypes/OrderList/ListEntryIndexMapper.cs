using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.OrderList {

    /// <summary>
    ///     Maps a generic type to an <see cref="IListEntryIndex"/>
    /// </summary>
    /// <typeparam name="T">
    ///     the type to be mapped to an <see cref="IListEntryIndex"/> entry
    /// </typeparam>
    public class ListEntryIndexMapper<T> {


        /// <summary>
        ///     maps an element to an <see cref="IListEntryIndex"/>
        /// </summary>
        /// <param name="element">
        ///     the element that is to be mapped.
        /// </param>
        /// <returns>
        ///     returns the elements current position.
        /// </returns>
        public IListEntryIndex map
                                ( T element ) {
            
            return new ListEntryIndexMap<T>
                        ( element
                        , get_position
                        , set_position );
        }

        /// <summary>
        ///     Constructs an instance of the mapper which expects mapping 
        /// functions that will get and set the position if the element that is
        /// to be mapped.
        /// </summary>
        /// <param name="the_get_position">
        ///     method used to get an elements position in the list
        /// </param>
        /// <param name="the_set_position">
        ///     method used to set an element position in the list.
        /// </param>
        public ListEntryIndexMapper 
                ( GetPositionMap<T> the_get_position 
                , SetPositionMap<T> the_set_position ) {
            
            get_position = Guard.IsNotNull( the_get_position, "the_get_position" );
            set_position = Guard.IsNotNull( the_set_position, "the_set_position" );
        }

        private readonly GetPositionMap<T> get_position;
        private readonly SetPositionMap<T> set_position;
    }

}