using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static.Lookup;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors {

    public class EditorBuilder<S> {

        public IsAViewElement build ( S source ) {

            if (!report_should_be_displayed.decide_for( source )) return new ANullViewElement();

            var model_metadata = model_metadata_repository.metadata_for();
            var obj =  new Editor {
                id = model_metadata.id( source ),
                title = model_metadata.title( source ),
                description = model_metadata.description ,
                fields  = editor_fields_builder.build( source ),
                actions = create_editor_actions( source ),
                data_type = typeof(S).Name
            };

            return obj;
        }

        public EditorBuilder<S> set_lookup_values<P>
            ( Expression<Func<S,P>> member_identifier
            , IEnumerable<LookupValue> values ) {
            
            if ( member_identifier.Body.NodeType != ExpressionType.MemberAccess ) throw new Exception();
                
            var expression_body = (MemberExpression)member_identifier.Body;
            var property_name = expression_body.Member.Name;

            lookup_values_repository.set_vaules( property_name, values );

            return this;
        }

        public EditorBuilder
            ( IShouldBeDisplayed<S> report_should_be_displayed_policy
            , IEditorModelMetadataRepository<S> the_model_metadata_repository
            , EditorFieldsBuilder<S> the_editor_fields_builder 
            , LookupFieldValuesRepository<S> the_lookup_values_repository
            , EditorActionsBuilder<S> the_actions_builder ) {

            Guard.IsNotNull( report_should_be_displayed_policy, "report_should_be_displayed_policy" );
            Guard.IsNotNull( the_model_metadata_repository, "the_model_metadata_repository" );
            Guard.IsNotNull( the_editor_fields_builder, "the_editor_fields_builder" );
            Guard.IsNotNull( the_lookup_values_repository, "the_lookup_values_repository" );
            Guard.IsNotNull( the_actions_builder, "the_actions_builder" );

            report_should_be_displayed = report_should_be_displayed_policy;
            model_metadata_repository = the_model_metadata_repository;

            editor_fields_builder = the_editor_fields_builder;
            lookup_values_repository= the_lookup_values_repository;
            actions_builder = the_actions_builder;
        }


        // creates the collection of actions for the report
        private IEnumerable<RoutedAction> create_editor_actions ( S model ) {

            return actions_builder.build( model );
        }

        // used to decide whether to return a null element or build report.
        private readonly IShouldBeDisplayed<S> report_should_be_displayed;

        // used to get model metadata for the repository.
        private readonly IEditorModelMetadataRepository<S> model_metadata_repository;

        // used to build the fields from the model
        private readonly EditorFieldsBuilder<S> editor_fields_builder;

        private readonly EditorActionsBuilder<S> actions_builder;
        private readonly LookupFieldValuesRepository<S> lookup_values_repository;

    }
}