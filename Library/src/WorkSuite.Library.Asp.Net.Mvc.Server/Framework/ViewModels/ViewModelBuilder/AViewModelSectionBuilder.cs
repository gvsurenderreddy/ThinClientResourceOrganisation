using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Sections;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder
{
    public class AViewModelSectionBuilder : AReportSectionBuilder<AViewModelSectionBuilder>
    {

        public AViewModelSectionBuilder
            (AReportBuilderFactory the_report_builder_factory
              , AViewModelBuilder the_view_model_builder)
            : base(the_report_builder_factory)
        {

            view_model_builder = the_view_model_builder;
        }

        public AViewModelBuilder end_section()
        {
            return view_model_builder.add_section(build());
        }

        private readonly AViewModelBuilder view_model_builder;
    }
}