using System;
using System.Collections.Generic;
using System.Linq;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    public static class IEnumerableExtension {

        /// <summary>
        ///     Perform an action against
        /// </summary>
        public static void Do<S> 
            ( this IEnumerable<S> source, Action<S> action ) {
            
            foreach (var entry in source ) {
                action( entry );
            }
        }


        public static void has_entries<S>
                            ( this IEnumerable<S> source
                            , Action<IEnumerable<S>> yes
                            , Action no ) {

            if (source.Any()) {
                yes( source );

            } else {
                no();
            }
        }


        public static IEnumerable<P> ToEnumerable<P>
                                        ( this P member ) {

            return member != null
                ? new List<P> {member}
                : new List<P>()
                ;
        }
    }


    

}