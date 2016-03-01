
namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors
{
    public interface AnEditorBuilderFactory
    {
        EditorBuilder<S> create_builder<S>(); 
    }
}
