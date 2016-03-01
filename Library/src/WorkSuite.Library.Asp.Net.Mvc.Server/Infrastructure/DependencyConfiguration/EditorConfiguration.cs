using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static.Lookup;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration {

    public class EditorConfiguration : ADependencyConfiguration {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {
            kernel
                .Bind( typeof( IEditorModelMetadataRepository<>) 
                     , typeof( EditorModelMetadataRepository<>))
                .To( typeof( EditorModelMetadataRepository<>) )
                .InSingletonScope()
                ;

            // to do: use explicit configuration for the EditorFieldsBuilder, FeildsFactory
            kernel
                .Bind( typeof( ILookupFieldValuesRepository<>) 
                     , typeof( LookupFieldValuesRepository<> ))
                .To( typeof( LookupFieldValuesRepository<>) )
                .InScope( scope )
                ;


            kernel
                .Bind( typeof(IEditorModelMetadataBuilder<>) )
                .To( typeof(EditorModelMetadataBuilder<>) )                
                ;

            kernel
                .Bind( typeof ( Framework.ViewModels.Editors.Metadata.IEditorFieldMetadataRepository<> )
                     , typeof ( EditorFieldMetadataRepository<> ))
                .To( typeof ( EditorFieldMetadataRepository<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof ( IEditorFieldsMetadataBuilder<> ))
                .To( typeof ( EditorFieldsMetadataBuilder<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof ( IEditorActionMetadataRepository<> )
                     , typeof ( EditorActionMetadataRepository<> ))
                .To( typeof ( EditorActionMetadataRepository<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof ( IEditorActionsMetadataBuilder<>  ) )
                .To( typeof ( EditorActionsMetadataBuilder<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind( typeof ( Framework.ViewModels.Editors.IShouldBeDisplayed<> ))
                .To( typeof ( Framework.ViewModels.Editors.DefaultAlwaySayYesPolicy<> ))
                .InSingletonScope()
                ;

            kernel
                .Bind<Framework.ViewModels.Editors.Fields.IShouldBeDisplayedOnEditor>()
                .To<Framework.ViewModels.Editors.Fields.DefaultAlwaysSayYesPolicy>()
                ;
            
            kernel
                .Bind( typeof(EditorActionsBuilder<>)  )
                .To( typeof(EditorActionsBuilder<>) )
                ;

        }
    }

}