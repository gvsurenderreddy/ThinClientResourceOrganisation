using System.Reflection;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Metadata.Static;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration;

namespace WTS.WorkSuite.Web.ThinClient {

    /// <summary>
    ///     Create all the view models metadata and adds it to the view model repositories e.g. pages
    /// </summary>
    public static class BuildViewModelMetadata {

        /// <summary>
        ///     Uses the library <see cref="BuildViewModelMatadataDefinedInAssembly"/> (which is the static)
        /// configuration to create all the view model metadata defined in the executing assembly.        
        /// </summary>
        /// <remarks>
        ///     The depencency configuration needs to have been set up before calling this method as the
        /// metadata builders need the Metadata repositories to have been configured as dependencies.
        /// </remarks>
        public static void build ( ) {

            // Improve: change this to not need the dependency resolver but have them as constructor dependencies (WPM).
            var metadata_builder = new BuildViewModelMatadataDefinedInAssembly( DependencyResolver.Current );
            metadata_builder.build( Assembly.GetExecutingAssembly() );



            //build white-space-palette
            build_white_space_time_allocation_palette_metadata(Assembly.GetExecutingAssembly(), DependencyResolver.Current);

            //build shift-palette
            build_shift_time_allocation_palette_metadata(Assembly.GetExecutingAssembly(), DependencyResolver.Current);

            //field set response policy
            build_field_set_validation_response_policy_metadata(Assembly.GetExecutingAssembly(), DependencyResolver.Current);
        }


        private static void build_white_space_time_allocation_palette_metadata(Assembly from_assembly, IDependencyResolver dependency_resolver)
        {
            Guard.IsNotNull(dependency_resolver, "the_dependency_resolver");

            var configuration = new BuildAllWhiteSpaceTimeAllocationPaletteDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private static void build_shift_time_allocation_palette_metadata(Assembly from_assembly, IDependencyResolver dependency_resolver)
        {
            Guard.IsNotNull(dependency_resolver, "the_dependency_resolver");

            var configuration = new BuildAllShiftTimeAllocationPaletteDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private static void build_field_set_validation_response_policy_metadata(Assembly from_assembly, IDependencyResolver dependency_resolver)
        {
            Guard.IsNotNull(dependency_resolver, "the_dependency_resolver");

            var configuration = new BuildFieldSetValidationResponsePolicyDefinitionsInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }
    }
}