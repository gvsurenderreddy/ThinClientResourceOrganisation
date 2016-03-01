using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration {

    /// <summary>
    ///     Builder that allows you to define 
    /// </summary>
    public interface IEditorActionMetadataBuilder<S> {

        IEditorActionMetadataBuilder<S> id ( string value );
        IEditorActionMetadataBuilder<S> type ( string value );
        IEditorActionMetadataBuilder<S> title ( string value );
        IEditorActionMetadataBuilder<S> route_parameter_factory( Func<S, object> value );
    }
}