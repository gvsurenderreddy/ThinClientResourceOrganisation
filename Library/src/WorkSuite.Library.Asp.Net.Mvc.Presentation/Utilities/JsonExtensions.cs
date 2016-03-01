// Contains JSON utilities that can be used in a razor page

using System.Web.Script.Serialization;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Utilities {


    public static class JsonExtensions {
        
        /// <summary>
        ///     Serializes an object to JSON.
        /// </summary>
        /// <param name="source">
        ///     Object that is to be serialized.
        /// </param>
        /// <returns>
        ///     Returns the object as a Json string.
        /// </returns>
        public static string ToJson
                                ( this object source ) {

            Guard.IsNotNull( source, "source" );

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize( source );
        }
    }
}