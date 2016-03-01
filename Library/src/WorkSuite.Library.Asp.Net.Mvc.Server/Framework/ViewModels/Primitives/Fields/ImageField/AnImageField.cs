namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ImageField {

    // Improve: This does not need to inherit the generic version of Field<> as that only supplies a generic value parameter (WPM).
    //          We are not using that in this case as we have supplied a url property
    public class AnImageField : Field<string>
    {
        public string url { get; set; }
    }
}
