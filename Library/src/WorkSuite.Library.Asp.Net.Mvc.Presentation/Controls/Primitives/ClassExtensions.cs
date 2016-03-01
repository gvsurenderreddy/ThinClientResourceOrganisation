using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Controls.Primitives {


    public static class ClassExtensions {

        /// <summary>
        ///     Converts an collections of strings to a class string that can be 
        /// added the to class property of a Html element.
        /// </summary>
        /// <param name="classes">
        ///     the collection that holds the string
        /// </param>
        /// <returns>
        ///     the all the classes in the collection reduced to a string
        /// </returns>
        public static string AsHtmlClassString
                                ( this IEnumerable<string> classes ) {

            if (classes == null) return string.Empty;
            
            return classes.Aggregate
                            ( String.Empty
                            , ( accumulator, projection) => accumulator + " " + projection );
        }

    }
}
