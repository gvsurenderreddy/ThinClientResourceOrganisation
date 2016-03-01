using System.Reflection;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Metadata.Static;

namespace WorkSuite.Confgiuration.Web.ThinClient {

    public static class BuildViewModelMetadata {

        /// <summary>
        ///     Uses the library <see cref="BuildViewModelMatadataDefinedInAssembly"/> (which is the static)
        /// configuration to create all the view model metadata defined in the executing assembly.        
        /// </summary>
        /// <remarks>
        ///     The depencency configuration needs to have been set up before calling this method as the
        /// metadata builders need the Metadata repositories to have been configured as dependencies.
        /// </remarks>
        public static void build() {

            var metadata_builder = new BuildViewModelMatadataDefinedInAssembly(DependencyResolver.Current);
            metadata_builder.build(Assembly.GetExecutingAssembly());
        }
    }



}