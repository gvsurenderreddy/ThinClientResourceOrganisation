using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.DisplayPolicy;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields.DisplayPolicy;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Reports
{
    public class ReportBuilder_will
    {
        [TestClass]
        public class build_the_report_properties : ReportBuilderFixture
        {
            // done: return an a report view element
            // done: return a null view element if not allowed to view the element
            // done: set the report's id from the model field_metadata
            // done: set the report's title from the model field_metadata
            // done: set the report's presenter url from the field_metadata and model
            // done: guard against the report presenter id not being specified

            [TestMethod]
            public void return_an_a_report_view_element()
            {
                builder.build(model).Should().BeOfType<Report>();
            }

            [TestMethod]
            public void set_the_report_id_from_the_model_metadata()
            {
                buid_report().id.Should().Be(metadata.id(model));
            }

            [TestMethod]
            public void set_the_report_title_from_the_model_metadata()
            {
                buid_report().title.Should().Be(metadata.title(model));
            }

            [TestMethod]
            public void default_theset_the_reports_is_marked_as_hidden_from_the_metdata_and_model()
            {
                metadata.is_marked_as_hidden = m => true;

                buid_report().is_marked_as_hidden.Should().BeTrue();
            }

            [TestMethod]
            public void set_the_reports_is_marked_as_hidden_from_the_metdata_and_model()
            {
                metadata.is_marked_as_hidden = m => true;

                buid_report().is_marked_as_hidden.Should().BeTrue();
            }
        }

        [TestClass]
        public class add_the_report_fields : ReportBuilderFixture
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
                buid_report().fields.Should().Contain(f => f.id == AStringProeprtyMetadata.id(model));
            }

            [TestMethod]
            public void set_the_field_title_from_the_property_metadata()
            {
                buid_report().fields.Should().Contain(f => f.title == AStringProeprtyMetadata.lable);
            }

            [TestMethod]
            public void set_the_field_required_status_from_the_property_metadata()
            {
                buid_report().fields.Should().Contain(f => f.is_required == AStringProeprtyMetadata.is_required);
            }

            [TestMethod]
            public void not_include_the_field_if_should_not_display_property_on_report()
            {
                should_display_property = false;

                buid_report().fields.Should().NotContain(f => f.id == AStringProeprtyMetadata.id(model));
            }

            [TestMethod]
            public void includes_a_field_for_each_property_of_the_model()
            {
                var report = buid_report();

                report.fields.Should().HaveCount(3);
                report.fields.Should().Contain(f => f.id == AStringProeprtyMetadata.id(model));
                report.fields.Should().Contain(f => f.id == ASecondStringProeprtyMetadata.id(model));
                report.fields.Should().Contain(f => f.id == AThirdStringProeprtyMetadata.id(model));
            }

            protected override void before_each_test()
            {
                AStringProeprtyMetadata = new ReportFieldMetadata<AReportModel>
                {
                    id = m => "AStringProeprtyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                };

                ASecondStringProeprtyMetadata = new ReportFieldMetadata<AReportModel>
                {
                    id = m => "AStringProeprtyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                };

                AThirdStringProeprtyMetadata = new ReportFieldMetadata<AReportModel>
                {
                    id = m => "AStringProeprtyMetadata",
                    lable = "label",
                    is_required = true,
                    is_included = m => true,
                };

                fields["AStringProeprty"] = AStringProeprtyMetadata;
                fields["ASecondStringProeprty"] = ASecondStringProeprtyMetadata;
                fields["AThirdStringProeprty"] = AThirdStringProeprtyMetadata;
            }

            private ReportFieldMetadata<AReportModel> AStringProeprtyMetadata;
            private ReportFieldMetadata<AReportModel> ASecondStringProeprtyMetadata;
            private ReportFieldMetadata<AReportModel> AThirdStringProeprtyMetadata;
        }

        [TestClass]
        public class add_the_actions_to_the_report : ReportBuilderFixture
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
                buid_report().actions.Should().Contain(a => a.id == report_action_metadata.id);
            }

            [TestMethod]
            public void set_the_url_from_the_report_action_metadata()
            {
                set_url_for(report_action_metadata.id, "action url");

                buid_report().actions.Should().Contain(a => a.url == "action url");
            }

            [TestMethod]
            public void set_the_title_from_the_report_action_metadata()
            {
                buid_report().actions.Should().Contain(a => a.title == report_action_metadata.title);
            }

            [TestMethod]
            public void set_the_action_type_from_the_report_action_metadata()
            {
                buid_report().actions.Should().Contain(a => a.name == report_action_metadata.name);
            }

            [TestMethod]
            public void add_an_action_for_each_report_action_in_the_model_metadata()
            {
                var second_action_metadata = add_action_metadata("2", "A title", "type");
                var third_action_metadata = add_action_metadata("3", "A title", "type");

                buid_report().actions.Should().HaveCount(3);
                buid_report().actions.Should().Contain(a => a.id == report_action_metadata.id);
                buid_report().actions.Should().Contain(a => a.id == second_action_metadata.id);
                buid_report().actions.Should().Contain(a => a.id == third_action_metadata.id);
            }

            [TestMethod]
            public void uses_the_action_metadata_factory_to_create_the_route_parameters()
            {
                // force the generation of the action
                buid_report().actions.Should().HaveCount(1);

                parameter_factory_called.Should().BeTrue();
            }

            protected override void before_each_test()
            {
                parameter_factory_called = false;
                report_action_metadata = add_action_metadata("action id", "action title", "Fred");
            }

            private ReportActionMetadata<AReportModel> add_action_metadata(string id, string title, string type)
            {
                var result = new ReportActionMetadata<AReportModel>
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

            private ReportActionMetadata<AReportModel> report_action_metadata;
            private bool parameter_factory_called;
        }

        public abstract class ReportBuilderFixture
        {
            protected Report buid_report()
            {
                return builder.build(model).As<Report>();
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

                model = new AReportModel();

                // create builder
                visibility_policy = create_visibility_policy();
                model_metadata_repository = create_model_metadata_repository();
                fields_metadata_repository = create_field_metadata_repository();
                actions_metadata_repository = create_action_metadata_repository();

                route_builder = create_route_builder();
                action_builder = new ActionsBuilder<AReportModel>(actions_metadata_repository, route_builder);

                fields_builder = create_report_fields_builder(fields_metadata_repository);

                builder = new ReportBuilder<AReportModel>(model_metadata_repository, route_builder, fields_builder, action_builder);

                before_each_test();
            }

            private IShouldBeDisplayed<AReportModel> create_visibility_policy()
            {
                var result = MockRepository.GenerateStub<IShouldBeDisplayed<AReportModel>>();
                result
                    .Stub(p => p.decide_for(model))
                    .Do((Func<AReportModel, bool>)(m => is_allowed_to_view_model));

                return result;
            }

            private IReportModelMetadataRepository<AReportModel> create_model_metadata_repository()
            {
                metadata = new ReportModelMetadata<AReportModel>
                {
                    title = m => "The title",
                    id = m => "new id",
                    report_presenter_id = "The report presenter id",
                    is_marked_as_hidden = m => false,
                };

                var result = MockRepository.GenerateStub<IReportModelMetadataRepository<AReportModel>>();
                result
                    .Stub(r => r.metadata_for())
                    .Return(metadata)
                    .Repeat.Any()
                    ;

                return result;
            }

            private ReportFieldsBuilder<AReportModel> create_report_fields_builder(IReportFieldMetadataRepository<AReportModel> fieldsMetadataRepository)
            {
                var display_property = MockRepository.GenerateStub<IShouldBeDisplayedOnReport<AReportModel>>();
                display_property
                    .Stub(dp => dp.decide_for(null))
                    .IgnoreArguments()
                    .Repeat.Any()
                    .Do((Func<PropertyInfo, bool>)(dp => should_display_property))
                    ;

                var field_factory = new ReportFieldFactory<AReportModel>(model_metadata_repository, fields_metadata_repository);

                return new ReportFieldsBuilder<AReportModel>(display_property, field_factory, fieldsMetadataRepository);
            }

            private IReportFieldMetadataRepository<AReportModel> create_field_metadata_repository()
            {
                var result = MockRepository.GenerateStub<IReportFieldMetadataRepository<AReportModel>>();
                result
                    .Stub(fr => fr.metadata_for(null))
                    .IgnoreArguments()
                    .Repeat.Any()
                    .Do((Func<PropertyInfo, ReportFieldMetadata<AReportModel>>)(
                        pi => fields[pi.Name]
                    ));

                return result;
            }

            private IReportActionMetadataRepository<AReportModel> create_action_metadata_repository()
            {
                var result = MockRepository.GenerateStub<IReportActionMetadataRepository<AReportModel>>();
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

            protected ReportBuilder<AReportModel> builder;
            protected AReportModel model;
            protected ReportModelMetadata<AReportModel> metadata;

            protected bool is_allowed_to_view_model;
            protected bool should_display_property;
            private IShouldBeDisplayed<AReportModel> visibility_policy;
            private IReportModelMetadataRepository<AReportModel> model_metadata_repository;
            private IReportFieldMetadataRepository<AReportModel> fields_metadata_repository;
            private IReportActionMetadataRepository<AReportModel> actions_metadata_repository;

            protected IDictionary<string, string> urls = new Dictionary<string, string>();
            protected IDictionary<string, ReportFieldMetadata<AReportModel>> fields = new Dictionary<string, ReportFieldMetadata<AReportModel>>();
            protected List<ReportActionMetadata<AReportModel>> actions = new List<ReportActionMetadata<AReportModel>>();

            private INamedRouteUrlBuilder route_builder;
            private ReportFieldsBuilder<AReportModel> fields_builder;
            private ActionsBuilder<AReportModel> action_builder;
        }
    }

    public class AReportModel
    {
        public string AStringProeprty { get; set; }

        public string ASecondStringProeprty { get; set; }

        public string AThirdStringProeprty { get; set; }
    }
}