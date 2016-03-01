using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Reports;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.DetailsLists
{

    public class DetailsListBuilder_will
    {

        // to do: list
        // to do: list title
        // to do: list entries

        [TestClass]
        public class create_a_list : DetailsListFixture
        {

            // done: create a DetailsList view element
            // done: return a ViewElement
            // done: create a title 

            [TestMethod]
            public void create_a_DetailsList_view_element()
            {

                build_list().Should().BeOfType<DetailsList>();
            }

            [TestMethod]
            public void should_return_a_ViewElement()
            {

                build_list().Should().BeAssignableTo<IsAViewElement>();
            }

            [TestMethod]
            public void create_the_header()
            {

                build_list().As<DetailsList>().header.Should().BeOfType<DetailsListHeader>();
            }

            [TestMethod]
            public void set_the_models_report_presenter_url_from_the_metadata_and_model()
            {
                list_metadata.presenter_id = "A route id";
                set_url_for(list_metadata.presenter_id, "A presenter url");

                build_list().report_presenter_url.Should().Be("A presenter url");
            }

            [TestMethod]
            public void set_the_models_id_from_the_metadata_id()
            {
                list_metadata.id = "A list id";

                build_list().id.Should().Be(list_metadata.id);
            }
        }

        public class create_the_list_header
        {

            [TestClass]
            public class header_properties : DetailsListFixture
            {


                [TestMethod]
                public void set_the_title_from_the_list_metadata()
                {

                    list_metadata.title = "A Title";

                    build_list().As<DetailsList>().header.title.Should().Be(list_metadata.title);
                }

            }

            [TestClass]
            public class actions
            {

                // done: set the action id from the report action field_metadata
                // done: set the url from the report action field_metadata
                // done: set the title from the report action field_metadata
                // done: set the action type from the report action field_metadata
                // done: add an action for each report action in the model field_metadata

                // to do: only adds actions the visibility policy says are valid.
                // to do: route factory, (not sure how to test this)

            }
        }

        public class create_the_list_entries { }


        public abstract class DetailsListFixture
        {

            [TestInitialize]
            public void test_setup()
            {
                list_metadata = new DetailsListMetadata();

                var list_metadata_repository = MockRepository.GenerateStub<IDetailsListMetadataRepository<DetailsListModel>>();
                list_metadata_repository
                    .Stub(r => r.metadata_for())
                    .Return(list_metadata)
                    .Repeat.Any();

                var list_actions_metadata_repository = MockRepository.GenerateStub<IDetailsListActionMetadataRepository<DetailsListModel>>();
                list_actions_metadata_repository
                    .Stub(r => r.metadata())
                    .Return(new List<DetailsListActionMetadata<DetailsListModel>>())
                    .Repeat.Any();


                var route_builder = MockRepository.GenerateStub<INamedRouteUrlBuilder>();
                route_builder
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



                var action_builder = new ActionsBuilder<DetailsListModel>(list_actions_metadata_repository, route_builder);

                builder = new DetailsListBuilder<DetailsListModel>(list_metadata_repository, action_builder, route_builder, report_builder);
                entries = new List<DetailsListModel>();
            }

            protected DetailsList build_list()
            {
                return builder.build(entries).As<DetailsList>();
            }

            protected void set_url_for(string route_name, string url)
            {

                urls[route_name] = url;
            }

            protected DetailsListBuilder<DetailsListModel> builder;
            protected DetailsListMetadata list_metadata;
            private List<DetailsListModel> entries;
            protected IDictionary<string, string> urls = new Dictionary<string, string>();
            protected ReportBuilder<DetailsListModel> report_builder;
            protected AReportModel model;
        }

    }

}