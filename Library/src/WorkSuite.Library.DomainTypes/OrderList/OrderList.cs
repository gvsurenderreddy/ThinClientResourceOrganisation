using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.OrderList {

    /// <summary>
    ///     Contains extensions method that can be applied to 
    /// collections of <see cref="IListEntryIndex"/>
    /// </summary>
    public static class OrderList {

        /// <summary>
        ///   Inserts an element into the list and ensures that the ordering is sequential
        /// </summary>
        /// <param name="index">
        ///     The index that defines the order of the entries in the list.
        /// </param>
        /// <param name="insert_at">
        ///     The position in the index that you want the element to be inserted at.
        /// </param>
        /// <param name="insert_by">
        ///     The method that inserts the element into the list.
        /// </param>
        /// <returns></returns>
        public static IEnumerable<IListEntryIndex> Insert
                                                     ( this IEnumerable<IListEntryIndex> index
                                                     , IListEntryIndex insert_at
                                                     , InsertElementIntoList insert_by ) {
            Guard.IsNotNull( index, "index" );
            Guard.IsNotNull( insert_at ,"insert_at" );
            Guard.PremiseHolds( insert_at.postion >= 1,"insert_at.postion out of range. An index starts at 1." );
            Guard.PremiseHolds( insert_at.postion <= index.Count()+1 ,"insert_at.postion out of range. Can not insert an element which would result in the index not being contiguous." );
            
            // Note - insisting on the index being contiguous allow insert 
            //        to simply update the position of all elements that need 
            //        to be moved by one.  If we allowed gaps then we would 
            //        have to check if we are still in a contiguous group.  While
            //        that would not to painful to implement I have not identified a
            //        need for that at the moment so in order to keep the implementation 
            //        as simple as possible this has not been added.
            index
                .Where( e => e.postion >= insert_at.postion )
                .Do( e => e.postion++ )
                ;

            insert_by();
            return index;
        }

        /// <summary>
        ///   Inserts an element into the list and ensures that the ordering is sequential
        /// </summary>
        /// <param name="index">
        ///     The index that defines the order of the entries in the list.
        /// </param>
        /// <param name="remove_at">
        ///     The position in the index that you want the element to be inserted at.
        /// </param>
        /// <param name="remove_by">
        ///     The method that inserts the element into the list.
        /// </param>
        /// <returns>
        ///     The list index with the list removed.
        /// </returns>
        public static IEnumerable<IListEntryIndex> Remove
                                                     ( this IEnumerable<IListEntryIndex> index
                                                     , IListEntryIndex remove_at 
                                                     , RemoveElementFromList remove_by ) {
            Guard.IsNotNull( index, "index" );
            Guard.IsNotNull( remove_at ,"remove_at" );
            Guard.PremiseHolds( remove_at.postion >= 1,"remove_at.postion out of range. An index starts at 1." );
            Guard.PremiseHolds( remove_at.postion <= index.Count()+1 ,"remove_at.postion out of range. Can not insert an element which would result in the index not being contiguous." );
            
            // Note - insisting on the index being contiguous allow insert 
            //        to simply update the position of all elements that need 
            //        to be moved by one.  If we allowed gaps then we would 
            //        have to check if we are still in a contiguous group.  While
            //        that would not to painful to implement I have not identified a
            //        need for that at the moment so in order to keep the implementation 
            //        as simple as possible this has not been added.
            index
                .Where( e => e.postion > remove_at.postion )
                .Do( e => e.postion-- );

            remove_by();
            return index;
        }


        /// <summary>
        ///   Moves an element within the index.
        /// </summary>
        /// <param name="index">
        ///     The index that defines the order of the entries in the list.
        /// </param>
        /// <param name="from">
        ///     The element that is to be moved in the index.
        /// </param>
        /// <param name="to">
        ///     The position that element is to be moved to.
        /// </param>
        /// <returns>
        ///     The list index after the element has been moved.
        /// </returns>
        public static IEnumerable<IListEntryIndex> Move
                                                     ( this IEnumerable<IListEntryIndex> index
                                                     , MoveIndexEntryRequest request ) {

            Guard.IsNotNull( index, "index" );
            Guard.IsNotNull( request, "request" );
            Guard.PremiseHolds( request.from >= 1,"from out of range. An index starts at 1." );
            Guard.PremiseHolds( request.from <= index.Count()+1 ,"from out of range. Can not insert an element which would result in the index not being contiguous." );            
            Guard.PremiseHolds( request.to >= 1,"to out of range. An index starts at 1." );
            Guard.PremiseHolds( request.to <= index.Count()+1 ,"to out of range. Can not insert an element which would result in the index not being contiguous." );


            var element_to_move = index.Single( e => e.postion == request.from );
            
            // move all elements that ordered beneath the element to be moved up one
            index
                .Where( e => e.postion > request.from )
                .Do( e => e.postion-- );

            // move all elements that are ordered beneath where then element is to be moved to 
            // down one place including the element that is currently in the place where the 
            // element is to be moved to.
            index
                .Where( e => e.postion >= request.to )
                .Do( e => e.postion++ );

            // set the element to be moved to its new places in
            element_to_move.postion = request.to;
            return index;
        }
    }
}