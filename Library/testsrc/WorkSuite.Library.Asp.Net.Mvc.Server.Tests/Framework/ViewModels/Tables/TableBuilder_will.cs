//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using FluentAssertions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Rhino.Mocks;
//using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
//using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields;
//using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields.DisplayPolicy;
//using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;
//using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteBuilder;

//namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tables
//{
//    [TestClass]
//    public class TableBuilder_will {

//        // NOTE - These test do not capture the full story. The fields that are 
//        //        included are dependent on display policy begin used in this 
//        //        test set up we just use a default policy that says all fields 
//        //        are displayed.


//        [TestMethod]
//        public void return_a_table_view_element() {

//            build_table().Should().BeOfType<Table>();
//        }

//        [TestMethod]
//        public void set_the_table_id_from_the_model_metadata() {
//            model_metadata.id = "100";
            
//            build_table().id.Should().Be( model_metadata.id );
//        }

//        [TestMethod]
//        public void rows_is_an_enumerations_of_table_rows ()
//        {
//            build_table().rows.Should().BeAssignableTo<IEnumerable<ATableRow>>();
//        }


//        [TestMethod]
//        public void set_each_row_id_from_the_models_metadata_field_id_extension () {
//            // The mock route builder just returns the proper as a string
//            model_metadata.field_id_extension = source => source.Property1;

//            var table = build_table();

//            table.rows.Should(  ).Contain( r => r.id == row1.Property1 );
//            table.rows.Should(  ).Contain( r => r.id == row2.Property1 );
//            table.rows.Should(  ).Contain( r => r.id == row3.Property1 );
//        }


//        [TestMethod]
//        public void set_each_row_url_from_the_models_metadata_row_route () {
//            // The mock route builder just returns the proper as a string
//            model_metadata.row_details_route_id = "row";
//            model_metadata.row_details_route_pramameter_factory = ( source => source.Property1 );

//            var table = build_table();
           
//            table.rows.Should(  ).Contain( r => r.url == row1.Property1 );
//            table.rows.Should(  ).Contain( r => r.url == row2.Property1 );
//            table.rows.Should(  ).Contain( r => r.url == row3.Property1 );
//        }


//        [TestMethod]
//        public void map_a_field_title_to_it_property_metatadata_lable_value ()
//        {
//            build_table().rows.Should().Contain( r => r.fields.Any( f => f.title == AStringPropertyMetadata.lable ));
//            build_table().rows.Should().Contain( r => r.fields.Any( f => f.title == ASecondStringPropertyMetadata.lable ));
//            build_table().rows.Should().Contain( r => r.fields.Any( f => f.title == AThirdStringPropertyMetadata.lable ));
//        }

//        [TestMethod]
//        public void include_a_field_for_each_property_of_the_model()
//        {
//            var table = build_table();

//            table.rows.Should().HaveCount(3);
//            table.rows.Should().Contain(r => r.fields.Any( f=> f.id == AStringPropertyMetadata.id));
//            table.rows.Should().Contain(r => r.fields.Any( f => f.id == ASecondStringPropertyMetadata.id));
//            table.rows.Should().Contain(r => r.fields.Any( f => f.id == AThirdStringPropertyMetadata.id));
//        }

//        [TestMethod]
//        public void include_a_column_for_each_property_of_the_model ( ) {
            
//            var table = build_table();

//            table.columns.Should(  ).HaveCount(3);
//            table.columns.Should(  ).Contain( c => fields.Values.Any( m => m.lable == c ));
//        }

//        protected Table build_table()
//        {
//            return builder.build( new List<ATableModel> { row1, row2, row3 }).As<Table>();
//        }


//        [TestInitialize]
//        public void before_each_test() {

//            model_metadata = new TableModelMetadata<ATableModel> ();

//            AStringPropertyMetadata = new TableFieldMetadata<ATableModel>
//            {
//                id = m => "AStringProeprtyMetadata",
//                lable = "AStringPropertyMetadata",
//                is_included = true,
//            };

//            ASecondStringPropertyMetadata = new TableFieldMetadata<ATableModel>
//            {
//                id = m => "ASecondStringPropertyMetadata",
//                lable = "ASecondStringPropertyMetadata",
//                is_required = true,
//                is_included = true,
//            };

//            AThirdStringPropertyMetadata = new TableFieldMetadata<ATableModel>
//            {
//                id = m => "AThirdStringPropertyMetadata",
//                lable = "AThirdStringPropertyMetadata",
//                is_required = true,
//                is_included = true,
//            };


//            fields["Property1"] = AStringPropertyMetadata;
//            fields["Property2"] = ASecondStringPropertyMetadata;
//            fields["Property3"] = AThirdStringPropertyMetadata;

//            row1 = new ATableModel { Property1 = "row1" };
//            row2 = new ATableModel { Property1 = "row2" };
//            row3 = new ATableModel { Property1 = "row3" };
            
            
//            display_policy = MockRepository.GenerateStub<IShouldBeDisplayedOnTable<ATableModel>>();
//            display_policy
//                .Stub(r => r.decide_for(null))
//                .IgnoreArguments()
//                .Return(true);

//            model_metadata_repository = MockRepository.GenerateStub<ITableModelMetadataRepository<ATableModel>>();
//            model_metadata_repository
//                .Stub(r => r.metadata_for())
//                .Return(model_metadata)
//                ;

//            field_metadata_repository = MockRepository.GenerateStub<ITableFieldMetadataRepository<ATableModel>>();
//            field_metadata_repository
//                        .Stub( fr => fr.metadata_for( null ))
//                        .IgnoreArguments()
//                        .Repeat.Any()
//                        .Do((Func<PropertyInfo, TableFieldMetadata<ATableModel>>)(
//                            pi => fields[ pi.Name ]
//                        ) );

//            field_metadata_repository
//                        .Stub( fr => fr.fields )
//                        .Repeat.Any()
//                        .Do((Func<IEnumerable<TableFieldMetadata<ATableModel>>>)(
//                            () => fields.Values
//                        ) );



//            table_field_factory = new TableFieldFactory<ATableModel>(  model_metadata_repository, field_metadata_repository);
//            the_table_fields_builder = new TableFieldsBuilder<ATableModel>(display_policy, table_field_factory);


//            route_builder = MockRepository.GenerateStub<IRouteBuilder>(  );
//            route_builder
//                .Stub( b => b.build( null ) )
//                .IgnoreArguments(  )
//                .Do( (Func<RouteBuildDefinition,string>)( d => d.route_parameters_factory().ToString(  ) ));

//            builder = new TableBuilder<ATableModel>(model_metadata_repository, the_table_fields_builder, route_builder, field_metadata_repository  );           
//        }


//        protected ITableModelMetadataRepository<ATableModel> model_metadata_repository;
        
//        protected TableBuilder<ATableModel> builder;
        
//        protected IRouteBuilder route_builder;

//        protected TableFieldsBuilder<ATableModel> the_table_fields_builder;
//        protected IShouldBeDisplayedOnTable<ATableModel> display_policy;
//        protected TableFieldFactory<ATableModel> table_field_factory;
//        protected ITableFieldMetadataRepository<ATableModel> field_metadata_repository;
//        protected IDictionary<string, TableFieldMetadata<ATableModel>> fields = new Dictionary<string, TableFieldMetadata<ATableModel>>();


//        protected TableModelMetadata<ATableModel> model_metadata;
//        protected ATableModel row1;
//        protected ATableModel row2;
//        protected ATableModel row3;
//        private TableFieldMetadata<ATableModel> AStringPropertyMetadata;
//        private TableFieldMetadata<ATableModel> ASecondStringPropertyMetadata;
//        private TableFieldMetadata<ATableModel> AThirdStringPropertyMetadata;
//    }

//    public class ATableModel
//    {
//        public string Property1 { get; set; }
//        public string Property2 { get; set; }
//        public string Property3 { get; set; }
//    }
//}