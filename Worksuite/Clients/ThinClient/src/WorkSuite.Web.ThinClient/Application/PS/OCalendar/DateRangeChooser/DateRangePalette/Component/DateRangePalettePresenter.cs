using System;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.DateRangePalette.Component
{
    public class DateRangePalettePresenter : Presenter
    {
        public ActionResult Page(DateRangePaletteRequest date_range_palette)
        {
            var view_model = date_range_palette_builder.build(date_range_palette);

            return View(@"~\Views\Shared\Views\DateRangePalette.cshtml", view_model);
        }

        public DateRangePalettePresenter(ADateRangePaletteBuilderFactory the_date_range_palette_builder_factory)
        {
            var date_range_palette_builder_factory = Guard.IsNotNull(the_date_range_palette_builder_factory, "the_date_range_palette_builder_factory");
            date_range_palette_builder = date_range_palette_builder_factory.create_builder<DateRangePaletteRequest>();
        }

        private readonly BuildDynamicDateRangePaletteFromStaticDefinition<DateRangePaletteRequest> date_range_palette_builder;
    }
}