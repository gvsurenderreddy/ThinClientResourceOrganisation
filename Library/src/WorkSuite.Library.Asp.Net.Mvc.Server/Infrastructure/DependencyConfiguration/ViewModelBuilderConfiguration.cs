using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ContentHeaderBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DateRangeBarBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DateRangePaletteBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.EditorBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ReportBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ShiftCalendarBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ShiftCalendarsListerBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.SimplePaletteBuilderFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class ViewModelBuilderConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<AReportBuilderFactory>().
                To<DependencyResolverReportBuilderFactory>();

            kernel.Bind<AnEditorBuilderFactory>().
                To<DependencyResolverEditorBuilderFactory>();

            kernel.Bind<ADetailsListBuilderFactory>().
               To<DependencyResolverDetailsListBuilderFactory>();

            kernel.Bind<AViewModelBuilder>().
                   To<AViewModelBuilder>();

            kernel.Bind<AContentHeaderBuilderFactory>().
                To<DependencyResolverContentHeaderBuilderFactory>();

            kernel.Bind<AShiftCalendarsListerBuilderFactory>()
                .To<DependencyResolverShiftCalendarsListerBuilderFactory>();

            kernel.Bind<AShiftCalendarBuilderFactory>()
                .To<DependencyResolverShiftCalendarBuilderFactory>();

            kernel.Bind<ASimplePaletteBuilderFactory>().
                To<DependencyResolverSimplePaletteBuilderFactory>();

            kernel.Bind<ADateRangePaletteBuilderFactory>().
                To<DependencyResolverDateRangePaletteBuilderFactory>();

            kernel.Bind<ADateRangeBarBuilderFactory>().
                To<DependencyResolverDateRangeBarBuilderFactory>();
        }
    }
}