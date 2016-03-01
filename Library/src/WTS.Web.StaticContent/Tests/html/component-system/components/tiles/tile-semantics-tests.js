// Tests to ensure that the semantic markup is applied to the Tile's html 

require([ 'application_boot'], function () {

    require(['jquery','dom_test_helpers', 'tile_constants'], function ($, dom_helpers, tile_constants) {

        var element_exists = dom_helpers.element_exists;

        var tile_class = '.'+ tile_constants.tile_class;
        var tile_title_class = '.'+ tile_constants.tile_title_class;

        test("Sanity - viewmodel has been set up", function () {

            ok(view_model != null);
        });

        test("tile has been marked with semantic tag", function () {

            ok( element_exists( tile_class ));
        });

        test("tile title has been maked with semantic tag", function () {

            ok( element_exists( tile_title_class ));
        });

        test("tile tile is set from the view model", function () {

            ok($(tile_title_class).text() === view_model.title);

        });
    });
});