namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.HiddenField {


    /* Note - 
     * 
     *   We specialize like this as we want give the semantic meaning via the class not 
     *   the type that we use to represent a value.
     *   
     *   This will allow us to have different semantics represented by the same primitive
     *   data type.
     */   
    public class AHiddenField 
                    : Field<string> { }
}