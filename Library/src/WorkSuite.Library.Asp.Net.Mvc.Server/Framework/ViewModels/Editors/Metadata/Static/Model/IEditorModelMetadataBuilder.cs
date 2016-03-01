using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    public interface IEditorModelMetadataBuilder<S> {

        /// <summary>
        ///     Allows you to set the id of the editor.
        /// </summary>
        /// <param name="value">
        ///     The id that you want applied to the editor.
        /// </param>
        /// <returns>
        ///     The builder to allow the method to be used as part of
        /// the fluent interface.
        /// </returns>
        IEditorModelMetadataBuilder<S> id ( string value );

        /// <summary>
        ///     Allows you to set the id from the properties of the
        /// instnace that the editor is for.
        /// </summary>
        /// <param name="value">
        ///     Delegate that accepts an instance of the type that the
        /// editor builder is for and returns a string that will be used
        /// as the id of the editor.
        /// </param>
        /// <returns>
        ///     The builder to allow the method to be used as part of
        /// the fluent interface.
        /// </returns>
        IEditorModelMetadataBuilder<S> id ( Func<S,string> value );

        /// <summary>
        ///     Allows you to set the helptext or description of the editor.
        /// </summary>
        /// <param name="value">
        ///     The  helptext or description that you want applied to the editor.
        /// </param>
        /// <returns>
        ///     The builder to allow the method to be used as part of
        /// the fluent interface.
        /// </returns>
        IEditorModelMetadataBuilder<S> description ( string value );
        

        /// <summary>
        ///     Allows you to set the tile of the editor.
        /// </summary>
        /// <param name="value">
        ///     The title that you want applied to the editor.
        /// </param>
        /// <returns>
        ///     The builder to allow the method to be used as part of
        /// the fluent interface.
        /// </returns>
        IEditorModelMetadataBuilder<S> title(string value);

        /// <summary>
        ///     Allows you to set the tile from the properties of the
        /// instnace that the editor is for.
        /// </summary>
        /// <param name="value">
        ///     Delegate that accepts an instance of the type that the
        /// editor builder is for and returns a string that will be used
        /// as the title of the editor.
        /// </param>
        /// <returns>
        ///     The builder to allow the method to be used as part of
        /// the fluent interface.
        /// </returns>
        IEditorModelMetadataBuilder<S> title ( Func<S, string> value );

        /// <summary>
        ///     Allows you to set an extension that will be applied to
        /// the id of each field.  This is to deal with the situation where
        /// you have two editors open on a page at once, if there was no way
        /// of specialising the field ids for a specific instance then
        /// you would have not way of avoiding namespace clashed
        /// </summary>
        /// <param name="genrator">
        ///     Delegate that accepts an instance of the type that the
        /// editor builder is for and returns a string that will be used
        /// as an extension that is added to each fields id.
        /// </param>
        /// <returns>
        ///     The builder to allow the method to be used as part of
        /// the fluent interface.
        /// </returns>
        IEditorModelMetadataBuilder<S> field_id_extension( Func<S,string> genrator );

    }
}