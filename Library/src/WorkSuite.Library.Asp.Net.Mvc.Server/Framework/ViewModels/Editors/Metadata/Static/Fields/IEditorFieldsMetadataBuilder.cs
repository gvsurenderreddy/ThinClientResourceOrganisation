using System;
using System.Linq.Expressions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    public interface IEditorFieldsMetadataBuilder<S> {

        IEditorFieldMetadataBuilder<S> for_field<P> ( Expression<Func<S, P>> property );
    }
}