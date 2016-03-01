using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public interface IReportModelMetadataBuilder<S> {

        IReportModelMetadataBuilder<S> presenter_id ( string value);

        IReportModelMetadataBuilder<S> id(Func<S, string> generator);

        IReportModelMetadataBuilder<S> title ( string value );
        
        IReportModelMetadataBuilder<S> title( Func<S,string> generator );

        IReportModelMetadataBuilder<S> description(string value);

        IReportModelMetadataBuilder<S> description(Func<S, string> generator);

        IReportModelMetadataBuilder<S> field_id_extension( Func<S,string> genrator );

        IReportModelMetadataBuilder<S> is_marked_as_hidden ( Func<S, bool> generator );

        IReportModelMetadataBuilder<S> should_display_discription(Func<S, bool> func);
    }
}