using System.Reflection;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Metadata.Static
{
    // Improve: if you look at the different metadata types and how they are built there is a lot of duplication that could be removed (WPM).

    /// <summary>
    ///     Will register an assemblies view model metadata configuration builders in
    /// with a dependency resolver.
    /// </summary>
    public class BuildViewModelMatadataDefinedInAssembly
    {
        public void build
                        (Assembly from_assembly)
        {
            build_page_metadata(from_assembly);
            build_report_metadata(from_assembly);
            build_content_header_metadata(from_assembly);
            build_shift_calendars_lister_metadata(from_assembly);
            build_shift_calendar_metadata(from_assembly);
            build_editor_metadata(from_assembly);
            build_detail_lists_metadata(from_assembly);
            build_simple_palette_metadata(from_assembly);
            build_date_range_palette_metadata(from_assembly);
            build_date_range_bar_metadata(from_assembly);

        }

        // Improve: change this to not need the dependency resolver but have the items it resolves as constructor dependencies (WPM).
        public BuildViewModelMatadataDefinedInAssembly
                    (IDependencyResolver the_dependency_resolver)
        {
            dependency_resolver = Guard.IsNotNull(the_dependency_resolver, "the_dependency_resolver");
        }

        // Builds all the page metadata in the assembly
        private void build_page_metadata
                        (Assembly from_assembly)
        {
            var confgiguration = new BuildPageMetadataDefinedInAssembly(from_assembly);

            confgiguration.build(dependency_resolver);
        }

        private void build_report_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildReportMetadataDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_content_header_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildAllContentHeaderDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_simple_palette_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildAllSimplePaletteDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_date_range_palette_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildAllDateRangePaletteDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_date_range_bar_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildAllDateRangeBarDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_shift_calendars_lister_metadata(Assembly from_assembly)
        {
            var configuration = new BuildAllShiftCalendarsListerDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_shift_calendar_metadata(Assembly from_assembly)
        {
            var configuration = new BuildAllShiftCalendarDefinitionsDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_editor_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildEditorMetadataDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        private void build_detail_lists_metadata
                        (Assembly from_assembly)
        {
            var configuration = new BuildDetailsListMetadataDefinedInAssembly(from_assembly);

            configuration.build(dependency_resolver);
        }

        // dependency resolver that configurations are applied to
        private readonly IDependencyResolver dependency_resolver;
    }
}