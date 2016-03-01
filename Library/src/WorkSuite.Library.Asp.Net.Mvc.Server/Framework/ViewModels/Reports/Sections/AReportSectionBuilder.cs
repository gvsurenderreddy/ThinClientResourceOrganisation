using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Sections
{
    public class AReportSectionBuilder: AReportSectionBuilder<AReportSectionBuilder> {

        public AReportSectionBuilder 
            ( AReportBuilderFactory the_report_builder_factory ) 
            : base( the_report_builder_factory ) {
        }
    }

    public class AReportSectionBuilder<R> where R : AReportSectionBuilder<R>
    {

        public R add<S>(S report)
        {
            var report_builder = report_builder_factory.create_builder<S>();

            elements.Add(report_builder.build(report));

            return (R)this;
        }

        public R add_collection<S>(IEnumerable<S> element_to_add)
        {

            var report_builder = report_builder_factory.create_builder<S>();

            foreach (var element in element_to_add)
            {
                elements.Add(report_builder.build(element));
            }
            return (R)this;
        }

        public AReportSection build()
        {

            return new AReportSection
            {
                elements = elements,
            };
        }

        public AReportSectionBuilder
            (AReportBuilderFactory the_report_builder_factory)
        {

            // to do: introduce guard statement

            report_builder_factory = the_report_builder_factory;
        }

        private readonly List<IsAViewElement> elements = new List<IsAViewElement>();
        private readonly AReportBuilderFactory report_builder_factory;
    }


}