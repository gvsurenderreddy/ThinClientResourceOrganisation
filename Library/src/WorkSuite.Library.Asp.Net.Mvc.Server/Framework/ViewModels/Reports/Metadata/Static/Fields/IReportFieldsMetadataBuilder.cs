using System;
using System.Linq.Expressions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public interface IReportFieldsMetadataBuilder<S> {

        IReportFieldMetadataBuilder<S> for_field<P> ( Expression<Func<S, P>> property );
        
    }

}