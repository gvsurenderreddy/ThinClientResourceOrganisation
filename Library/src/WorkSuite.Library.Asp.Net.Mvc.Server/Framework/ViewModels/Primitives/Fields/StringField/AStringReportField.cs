namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField {


    /* Note - 
     * 
     *   We specialize like this as we want give the semantic meaning via the class not 
     *   the type that we use to represent a value.
     *   
     *   This will allow us to have different semantics represented by the same primitive
     *   data type.
     */

    // Improve: This should be renamed to AStringField it is not just a report field (WPM).    
    public class AStringReportField
                    : Field<string> {

        public bool humanize { get; set; }
    }
}