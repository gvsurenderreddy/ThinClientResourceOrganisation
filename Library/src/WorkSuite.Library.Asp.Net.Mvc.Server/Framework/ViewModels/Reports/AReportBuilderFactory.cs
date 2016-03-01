namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports
{
    public interface AReportBuilderFactory
    {
        ReportBuilder<S> create_builder<S>(); 
    }
}