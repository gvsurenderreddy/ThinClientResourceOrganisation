using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public interface IReportFieldMetadataBuilder<S> {

        IReportFieldMetadataBuilder<S> id(string value);
        IReportFieldMetadataBuilder<S> id(Func<S, string> generator);
        IReportFieldMetadataBuilder<S> label ( string value );
        IReportFieldMetadataBuilder<S> is_required ( bool value );
        IReportFieldMetadataBuilder<S> is_hidden();
        IReportFieldMetadataBuilder<S> is_rich_text(bool value);
        IReportFieldMetadataBuilder<S> is_included( Func<S, bool> value );
        IReportFieldMetadataBuilder<S> icon(string value);
        IReportFieldMetadataBuilder<S> icon(Func<S, string> generator);
        IReportFieldMetadataBuilder<S> humanize ();
        IReportFieldMetadataBuilder<S> is_simple_image();
    }
}