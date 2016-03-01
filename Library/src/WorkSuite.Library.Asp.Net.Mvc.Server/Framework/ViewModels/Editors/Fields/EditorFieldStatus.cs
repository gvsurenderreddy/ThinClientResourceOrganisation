namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields {
    public enum EditorFieldStatus {
        excluded,  // is no included in the editor
        hidden,    // is included as a hidden field in the editor
        // readonly
        editable,  // can be edited
    }
}