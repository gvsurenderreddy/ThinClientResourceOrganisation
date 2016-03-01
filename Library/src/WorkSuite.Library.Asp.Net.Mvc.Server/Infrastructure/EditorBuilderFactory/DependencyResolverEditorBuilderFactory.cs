using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.EditorBuilderFactory
{
    public class DependencyResolverEditorBuilderFactory : AnEditorBuilderFactory
    {
        public EditorBuilder<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<EditorBuilder<S>>();
        }
    }
}