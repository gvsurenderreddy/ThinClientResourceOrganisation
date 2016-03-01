using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static.Lookup;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Editors
{
    public class EditorBuilder_will
    {
        [TestClass]
        public class build_the_editor_properties : EditorBuilderFixture
        {
            // done: return an a report view element
            // done: return a null view element if not allowed to view the element
            // done: set the report's id from the model field_metadata
            // done: set the report's title from the model field_metadata
            // done: guard against the report presenter id not being specified

            [TestMethod]
            public void return_an_editor_view_element()
            {
                builder.build(model).Should().BeOfType<Editor>();
            }

            [TestMethod]
            public void the_id_of_the_editor_is_set_from_the_model_metadata()
            {
                build_editor().id.Should().Be(metadata.id(model));
            }

            [TestMethod]
            public void the_title_of_the_editor_is_set_from_the_model_metadata()
            {
                build_editor().title.Should().Be(metadata.title(model));
            }
        }

        [TestClass]
        public class add_the_editor_fields : EditorFieldsBuilderFixture
        {
            // done: set the field id from the property metadata
            // done: set the field title from the property metadata
            // done: set the field required status from the property metadata
            // done: not include the field if should not display property on report.
            // done: includes a field for each property of the model

            // to do: house keeping what do we do when we have not set up metadata for a field

            [TestMethod]
            public void set_the_field_id_from_the_property_metadata()
            {
                build_editor().fields.Should().Contain(f => f.id == AStringProeprtyMetadata.id(model));
            }

            [TestMethod]
            public void set_the_field_title_from_the_property_metadata()
            {
                build_editor().fields.Should().Contain(f => f.title == AStringProeprtyMetadata.lable);
            }

            [TestMethod]
            public void set_the_field_required_status_from_the_property_metadata()
            {
                build_editor().fields.Should().Contain(f => f.is_required == AStringProeprtyMetadata.is_required);
            }

            [TestMethod]
            public void not_include_the_field_if_should_not_display_property_on_report()
            {
                should_display_property = false;

                build_editor().fields.Should().NotContain(f => f.id == AStringProeprtyMetadata.id(model));
            }

            [TestMethod]
            public void includes_a_field_for_each_property_of_the_model()
            {
                var editor = build_editor();

                editor.fields.Should().HaveCount(5);
                editor.fields.Should().Contain(f => f.id == Proeprty1Metadata.id(model));
                editor.fields.Should().Contain(f => f.id == AStringProeprtyMetadata.id(model));
                editor.fields.Should().Contain(f => f.id == ASecondStringProeprtyMetadata.id(model));
                editor.fields.Should().Contain(f => f.id == AThirdStringProeprtyMetadata.id(model));
                editor.fields.Should().Contain(f => f.id == AnIntPropertyMetadata.id(model));
            }

            [TestMethod]
            public void set_the_field_help_from_the_property_metadata()
            {
                build_editor().fields.Should().Contain(f => f.help == AStringProeprtyMetadata.help);
            }
        }

        [TestClass]
        public class lookup_field : EditorFieldsBuilderFixture
        {
            [TestMethod]
            public void create_lookup_if_field_identified_as_a_lookup_in_the_metadata()
            {
                build_editor().fields.Single(f => f.id == LoookupFieldMetadata.id(model)).Should().BeOfType<ALookupField>();
            }

            // set the field value from the property's value
            [TestMethod]
            public void set_the_field_value_from_the_proerties_value()
            {
                model_property = 10;

                editor_field.value.Should().Be(model_property);
            }

            // set the fields lookup data from the lookup repository
            [TestMethod]
            public void set_the_fields_lookup_data_from_the_lookup_repository()
            {
                lookup_repository.set_vaules
                    (model_property_name
                    , new[] {
                        new LookupValue {},
                        new LookupValue {},
                        new LookupValue {}}
                    );

                editor_field.lookup_values.Should().Contain(lookup_repository.values_for(model_property_name));
            }

            [TestMethod]
            public void the_lookup_data_for_a_field_can_be_set_in_the_editor_builder()
            {
                var values = new[] {
                    new LookupValue {},
                    new LookupValue {},
                    new LookupValue {},
                };

                builder.set_lookup_values(m => m.AnIntProperty, values);

                editor_field.lookup_values.Should().Contain(values);
            }

            protected override void before_each_test()
            {
                base.before_each_test();

                LoookupFieldMetadata.field_type = FieldTypes.Lookup;
            }

            private ALookupField editor_field
            {
                get
                {
                    return build_editor().fields.Single(f => f.id == LoookupFieldMetadata.id(model)).As<ALookupField>();
                }
            }

            private EditorFieldMetadata<AnEditorModel> LoookupFieldMetadata
            {
                get
                {
                    return AnIntPropertyMetadata;
                }
            }

            private int model_property
            {
                get
                {
                    return model.AnIntProperty;
                }
                set
                {
                    model.AnIntProperty = value;
                }
            }

            private string model_property_name = "AnIntProperty";
        }

        [TestClass]
        public class add_the_actions_to_the_report : EditorBuilderFixture
        {
            // done: set the action id from the report action field_metadata
            // done: set the url from the report action field_metadata
            // done: set the title from the report action field_metadata
            // done: set the action type from the report action field_metadata
            // done: add an action for each report action in the model field_metadata

            // to do: only adds actions the visibility policy says are valid.
            // to do: route factory, (not sure how to test this)

            [TestMethod]
            public void set_the_id_from_the_report_action_metadata()
            {
                build_editor().actions.Should().Contain(a => a.id == editor_action_metadata.id);
            }

            [TestMethod]
            public void set_the_url_from_the_report_action_metadata()
            {
                set_url_for(editor_action_metadata.id, "action url");

                build_editor().actions.Should().Contain(a => a.url == "action url");
            }

            [TestMethod]
            public void set_the_title_from_the_report_action_metadata()
            {
                build_editor().actions.Should().Contain(a => a.title == editor_action_metadata.title);
            }

            [TestMethod]
            public void set_the_action_type_from_the_report_action_metadata()
            {
                build_editor().actions.Should().Contain(a => a.name == editor_action_metadata.name);
            }

            [TestMethod]
            public void add_an_action_for_each_report_action_in_the_model_metadata()
            {
                var second_action_metadata = add_action_metadata("2", "A title", "type");
                var third_action_metadata = add_action_metadata("3", "A title", "type");

                build_editor().actions.Should().HaveCount(3);
                build_editor().actions.Should().Contain(a => a.id == editor_action_metadata.id);
                build_editor().actions.Should().Contain(a => a.id == second_action_metadata.id);
                build_editor().actions.Should().Contain(a => a.id == third_action_metadata.id);
            }

            [TestMethod]
            public void uses_the_action_metadata_factory_to_create_the_route_parameters()
            {
                // force the generation of the action
                build_editor().actions.Should().HaveCount(1);

                parameter_factory_called.Should().BeTrue();
            }

            protected override void before_each_test()
            {
                parameter_factory_called = false;
                editor_action_metadata = add_action_metadata("action id", "action title", "Fred");
            }

            private EditorActionMetadata<AnEditorModel> add_action_metadata(string id, string title, string type)
            {
                var result = new EditorActionMetadata<AnEditorModel>
                {
                    id = id,
                    title = title,
                    name = type,
                    route_parameter_factory = action_model =>
                    {
                        parameter_factory_called = true;
                        return new { };
                    },
                };

                actions.Add(result);

                urls[result.id] = result.id;

                return result;
            }

            private EditorActionMetadata<AnEditorModel> editor_action_metadata;
            private bool parameter_factory_called;
        }

        public abstract class EditorBuilderFixture
        {
            protected Editor build_editor()
            {
                return builder.build(model).As<Editor>();
            }

            protected void set_url_for(string route_name, string url)
            {
                urls[route_name] = url;
            }

            [TestInitialize]
            public void test_setup()
            {
                // set default states
                is_allowed_to_view_model = true;
                should_display_property = true;

                model = new AnEditorModel();

                // create builder
                visibility_policy = create_visibility_policy();
                model_metadata_repository = create_model_metadata_repository();
                fields_metadata_repository = create_field_metadata_repository();
                actions_metadata_repository = create_action_metadata_repository();

                route_builder = create_route_builder();
                action_builder = new EditorActionsBuilder<AnEditorModel>(actions_metadata_repository, route_builder);

                lookup_repository = new LookupFieldValuesRepository<AnEditorModel>();
                fields_builder = create_fields_builder(lookup_repository);

                builder = new EditorBuilder<AnEditorModel>(visibility_policy, model_metadata_repository, fields_builder, lookup_repository, action_builder);

                before_each_test();
            }

            private IShouldBeDisplayed<AnEditorModel> create_visibility_policy()
            {
                var result = MockRepository.GenerateStub<IShouldBeDisplayed<AnEditorModel>>();
                result
                    .Stub(p => p.decide_for(model))
                    .Do((Func<AnEditorModel, bool>)(m => is_allowed_to_view_model));

                return result;
            }

            private IEditorModelMetadataRepository<AnEditorModel> create_model_metadata_repository()
            {
                metadata = new EditorModelMetadata<AnEditorModel>
                {
                    title = (m) => "The title",
                    id = m => "new id",
                    description =  "The help text",
                };

                var result = MockRepository.GenerateStub<IEditorModelMetadataRepository<AnEditorModel>>();
                result
                    .Stub(r => r.metadata_for())
                    .Return(metadata)
                    .Repeat.Any()
                    ;

                return result;
            }

            private EditorFieldsBuilder<AnEditorModel> create_fields_builder(ILookupFieldValuesRepository<AnEditorModel> lookup_field_repository)
            {
                var display_policy = MockRepository.GenerateStub<IShouldBeDisplayedOnEditor>();
                display_policy
                    .Stub(dp => dp.decide_for(null))
                    .IgnoreArguments()
                    .Repeat.Any()
                    .Do((Func<PropertyInfo, bool>)(dp => should_display_property))
                    ;

                var field_factory = new EditorFieldFactory<AnEditorModel>(model_metadata_repository, fields_metadata_repository, lookup_field_repository);

                return new EditorFieldsBuilder<AnEditorModel>(display_policy, field_factory, fields_metadata_repository);
            }

            private IEditorFieldMetadataRepository<AnEditorModel> create_field_metadata_repository()
            {
                var result = MockRepository.GenerateStub<IEditorFieldMetadataRepository<AnEditorModel>>();
                result
                    .Stub(fr => fr.metadata_for(null))
                    .IgnoreArguments()
                    .Repeat.Any()
                    .Do((Func<PropertyInfo, EditorFieldMetadata<AnEditorModel>>)(
                        pi => fields[pi.Name]
                    ));

                return result;
            }

            private IEditorActionMetadataRepository<AnEditorModel> create_action_metadata_repository()
            {
                var result = MockRepository.GenerateStub<IEditorActionMetadataRepository<AnEditorModel>>();
                result
                    .Stub(ar => ar.metadata())
                    .Return(actions)
                    ;

                return result;
            }

            private INamedRouteUrlBuilder create_route_builder()
            {
                var result = MockRepository.GenerateStub<INamedRouteUrlBuilder>();
                result
                    .Stub(rb => rb.build((NamedRouteUrlObjectBuildDefinition)null))
                    .IgnoreArguments()
                    .Repeat.Any()
                    .Do((Func<NamedRouteUrlObjectBuildDefinition, string>)(bd =>
                    {
                        if (bd.route_name == null || !urls.ContainsKey(bd.route_name))
                        {
                            return string.Empty;
                        }
                        bd.route_parameters_factory();
                        return urls[bd.route_name];
                    }));

                return result;
            }

            protected virtual void before_each_test()
            {
            }

            protected EditorBuilder<AnEditorModel> builder;
            protected AnEditorModel model;
            protected EditorModelMetadata<AnEditorModel> metadata;

            protected bool is_allowed_to_view_model;
            protected bool should_display_property;
            private IShouldBeDisplayed<AnEditorModel> visibility_policy;
            private IEditorModelMetadataRepository<AnEditorModel> model_metadata_repository;
            private IEditorFieldMetadataRepository<AnEditorModel> fields_metadata_repository;
            private IEditorActionMetadataRepository<AnEditorModel> actions_metadata_repository;

            protected IDictionary<string, string> urls = new Dictionary<string, string>();
            protected IDictionary<string, EditorFieldMetadata<AnEditorModel>> fields = new Dictionary<string, EditorFieldMetadata<AnEditorModel>>();
            protected List<EditorActionMetadata<AnEditorModel>> actions = new List<EditorActionMetadata<AnEditorModel>>();

            private INamedRouteUrlBuilder route_builder;
            private EditorFieldsBuilder<AnEditorModel> fields_builder;
            private EditorActionsBuilder<AnEditorModel> action_builder;

            protected LookupFieldValuesRepository<AnEditorModel> lookup_repository;
        }

        public abstract class EditorFieldsBuilderFixture : EditorBuilderFixture
        {
            protected override void before_each_test()
            {
                base.before_each_test();

                Proeprty1Metadata = new EditorFieldMetadata<AnEditorModel>
                {
                    id = m => "Proeprty1Metadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                    
                };

                AStringProeprtyMetadata = new EditorFieldMetadata<AnEditorModel>
                {
                    id = m => "AStringProeprtyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                    help = "AStringProeprty Help",
                };

                ASecondStringProeprtyMetadata = new EditorFieldMetadata<AnEditorModel>
                {
                    id = m => "AStringProeprtyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                };

                AThirdStringProeprtyMetadata = new EditorFieldMetadata<AnEditorModel>
                {
                    id = m => "AStringProeprtyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                };

                AnIntPropertyMetadata = new EditorFieldMetadata<AnEditorModel>
                {
                    id = m => "AnIntPropertyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                };

                fields["Property1"] = Proeprty1Metadata;
                fields["AStringProeprty"] = AStringProeprtyMetadata;
                fields["ASecondStringProeprty"] = ASecondStringProeprtyMetadata;
                fields["AThirdStringProeprty"] = AThirdStringProeprtyMetadata;
                fields["AnIntProperty"] = AnIntPropertyMetadata;
            }

            protected EditorFieldMetadata<AnEditorModel> Proeprty1Metadata;
            protected EditorFieldMetadata<AnEditorModel> AStringProeprtyMetadata;
            protected EditorFieldMetadata<AnEditorModel> ASecondStringProeprtyMetadata;
            protected EditorFieldMetadata<AnEditorModel> AThirdStringProeprtyMetadata;
            protected EditorFieldMetadata<AnEditorModel> AnIntPropertyMetadata;
        }
    }
}