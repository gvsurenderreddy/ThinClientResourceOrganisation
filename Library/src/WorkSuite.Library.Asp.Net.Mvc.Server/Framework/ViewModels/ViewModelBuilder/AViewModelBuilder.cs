using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Sections;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder
{
    public class AViewModelBuilder
    {
        public AViewModelBuilder add_simple_palette<S>(S simple_palette)
        {
            var simple_palette_builder = simple_palette_builder_factory.create_builder<S>();
            elements.Add(simple_palette_builder.build(simple_palette));

            return this;
        }

        public AViewModelBuilder add_date_range_palette<S>(S date_range_palette)
        {
            var date_range_palette_builder = date_range_palette_builder_factory.create_builder<S>();
            elements.Add(date_range_palette_builder.build(date_range_palette));

            return this;
        }

        public AViewModelBuilder add_date_range_bar<S>(S date_range_bar)
        {
            var date_range_bar_builder = date_range_bar_builder_factory.create_builder<S>();
            elements.Add(date_range_bar_builder.build(date_range_bar));

            return this;
        }

        public AViewModelBuilder add_content_header<S>(S content_header)
        {
            var content_header_builder = content_header_builder_factory.create_builder<S>();
            elements.Add(content_header_builder.build(content_header));

            return this;
        }

        public AViewModelBuilder add_shift_calendars_lister<S>(S shift_calendars_lister)
        {
            var shift_calendars_lister_builder = shift_calendars_lister_builder_factory.create_builder<S>();
            elements.Add(shift_calendars_lister_builder.build(shift_calendars_lister));

            return this;
        }

        public AViewModelBuilder add_report<S>(S report)
        {
            var report_builder = report_builder_factory.create_builder<S>();

            elements.Add(report_builder.build(report));

            return this;
        }

        public AViewModelBuilder add_editor<S>(S editor)
        {
            var editor_builder = editor_builder_factory.create_builder<S>();

            elements.Add(editor_builder.build(editor));

            return this;
        }

        public AViewModelBuilder add_view_element(IsAViewElement view_element)
        {
            elements.Add(view_element);
            return this;
        }

        public AViewModelBuilder add_details_list<S>(IEnumerable<S> elements_to_add)
        {
            return add_details_list(elements_to_add, () => new { });
        }

        public AViewModelBuilder add_details_list<S>
            (IEnumerable<S> elements_to_add
            , Func<object> route_parameter_factory)
        {
            var details_list_builder = details_list_builder_factory.create_builder<S>();

            elements.Add(details_list_builder.build(elements_to_add, route_parameter_factory));

            return this;
        }

        public AViewModelBuilder add_collection<S>(IEnumerable<S> element_to_add)
        {
            var report_builder = report_builder_factory.create_builder<S>();

            foreach (var element in element_to_add)
            {
                elements.Add(report_builder.build(element));
            }
            return this;
        }

        public AViewModelBuilder add_section(AReportSection section_to_add)
        {
            elements.Add(section_to_add);

            return this;
        }

        public AViewModelSectionBuilder add_section()
        {
            return new AViewModelSectionBuilder
                            (report_builder_factory, this);
        }

        public IEnumerable<IsAViewElement> build()
        {
            return elements;
        }

        public AViewModelBuilder
                (AReportBuilderFactory the_report_builder_factory
                , AnEditorBuilderFactory the_editor_builder_factory
                , AContentHeaderBuilderFactory the_content_header_builder_factory
                , AShiftCalendarsListerBuilderFactory the_shift_calendars_lister_builder_factory
                , AShiftCalendarBuilderFactory the_shift_calendar_builder_factory
                , ADetailsListBuilderFactory the_details_list_builder_factory
                , ASimplePaletteBuilderFactory the_simple_palette_builder_factory
                , ADateRangePaletteBuilderFactory the_date_range_palette_builder_factory
                , ADateRangeBarBuilderFactory the_date_range_bar_builder_factory)
        {
            editor_builder_factory = Guard.IsNotNull(the_editor_builder_factory, "the_editor_builder_factory");
            report_builder_factory = Guard.IsNotNull(the_report_builder_factory, "the_report_builder_factory");
            details_list_builder_factory = Guard.IsNotNull(the_details_list_builder_factory, "the_details_list_builder_factory");
            content_header_builder_factory = Guard.IsNotNull(the_content_header_builder_factory, "the_content_header_builder_factory");
            shift_calendars_lister_builder_factory = Guard.IsNotNull(the_shift_calendars_lister_builder_factory, "the_shift_calendars_lister_builder_factory");
            shift_calendar_builder_factory = Guard.IsNotNull(the_shift_calendar_builder_factory, "the_shift_calendar_builder_factory");
            simple_palette_builder_factory = Guard.IsNotNull(the_simple_palette_builder_factory, "the_simple_palette_builder_factory");
            date_range_palette_builder_factory = Guard.IsNotNull(the_date_range_palette_builder_factory, "the_date_range_palette_builder_factory");
            date_range_bar_builder_factory = Guard.IsNotNull(the_date_range_bar_builder_factory, "the_date_range_bar_builder_factory");
        }

        private readonly List<IsAViewElement> elements = new List<IsAViewElement>();
        private readonly AReportBuilderFactory report_builder_factory;
        private readonly AnEditorBuilderFactory editor_builder_factory;
        private readonly ADetailsListBuilderFactory details_list_builder_factory;

        private readonly AContentHeaderBuilderFactory content_header_builder_factory;
        private readonly AShiftCalendarsListerBuilderFactory shift_calendars_lister_builder_factory;
        private readonly AShiftCalendarBuilderFactory shift_calendar_builder_factory;

        private readonly ASimplePaletteBuilderFactory simple_palette_builder_factory;

        private readonly ADateRangePaletteBuilderFactory date_range_palette_builder_factory;
        private readonly ADateRangeBarBuilderFactory date_range_bar_builder_factory;
    }
}