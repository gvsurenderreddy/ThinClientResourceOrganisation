require([ 'application_boot' ], function () {

    require( ['jquery', 'dom_test_helpers', 'tile_grid_constants'], function ( $, dom_helpers, tile_grid_constants ) { 

        // to do: there should be a section for each section in the view model
        var should_have_n_instances_of = dom_helpers.should_have_n_instances_of;
        var tile_grid_section_class = '.' + tile_grid_constants.tile_gird_section_class;
        var expected_number_of_sections = view_model.sections.length;


        test( 'there should be a section for each section in the view model', function () {

            ok( expected_number_of_sections > 1 );
            ok( should_have_n_instances_of( expected_number_of_sections, tile_grid_section_class ));
        });

    });
});