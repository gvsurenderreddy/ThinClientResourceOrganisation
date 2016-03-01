namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model {

    public interface IDetailsListMetadataBuilder<S> {
        
        IDetailsListMetadataBuilder<S> title ( string value );
        IDetailsListMetadataBuilder<S> description(string value);
        IDetailsListMetadataBuilder<S> id ( string value );
        IDetailsListMetadataBuilder<S> presenter_id ( string value );
        IDetailsListMetadataBuilder<S> is_sortable();

    }

}