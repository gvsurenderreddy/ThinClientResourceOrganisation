using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class TileGridsController 
                    : Controller {

        public ActionResult Index () {

            var view_model = new TileGridViewModel {

                tiles = new Collection<Tile> {
                    new Tile {
                        id = "first-tile",
                        url = "tile url",
                        title = "First Tile",
                        classes = new [] {"class_a", "class_b", "class_c"}
                    },
                    new Tile {
                        id = "second-tile",
                        url = "tile url",
                        title = "Second Tile",
                        classes = new [] {"class_a", "class_b", "class_c"}
                    }
                },

                tile_grid = new TileGrid {
                    title = string.Empty,
                    classes = new string [] { "class_a", "class_b" },
                    tiles = new Collection<Tile> {
                        new Tile {
                            id = "tile-grid-first-tile",
                            url = "tile url",
                            title = "Tile Grid - First Tile",
                            classes = new [] {"class_a", "class_b", "class_c"}
                        },
                        new Tile {
                            id = "tile-grid-second-tile",
                            url = "tile url",
                            title = "Tile Grid - Second Tile",
                            classes = new [] {"class_a", "class_b", "class_c"}
                        }
                    },
                },

                tile_grid_section = new TileGrid
                {
                    title = "Tile Grid Section",
                    classes = new [] { "class_a", "class_b" },
                    tiles = new Collection<Tile> {
                        new Tile {
                            id = "tile-grid-section-first-tile",
                            url = "tile url",
                            title = "Tile Grid Section - First Tile",
                            classes = new [] {"class_a", "class_b", "class_c"}
                        },
                        new Tile {
                            id = "tile-grid-section-second-tile",
                            url = "tile url",
                            title = "Tile Grid Section - Second Tile",
                            classes = new [] {"class_a", "class_b", "class_c"}
                        }
                    },
                },

                sectioned_tile_grid = new SectionedTileGrid
                {
                    classes = new [] { "class_a","class_b","class_c" },
                    sections = new Collection<TileGrid> { 
                        new TileGrid {
                            title = "First Section",
                            classes = new [] { "class_a", "class_b" },
                            tiles = new Collection<Tile> {
                                new Tile {
                                    id = "sectioned-tile-grid-first-section-first-tile",
                                    url = "tile url",
                                    title = "Sectioned Tile Grid - First Section - First Tile",
                                    classes = new [] {"class_a", "class_b", "class_c"}
                                },

                                new Tile {
                                    id = "sectioned-tile-grid-first-section-second-tile",
                                    url = "tile url",
                                    title = "Sectioned Tile Grid - First Section - Second Tile",
                                    classes = new [] {"class_a", "class_b", "class_c"}
                                },
                            }
                        },
                        
                        new TileGrid {
                            title = "Second Section",
                            classes = new [] { "class_a", "class_b" },
                            tiles = new Collection<Tile> {
                                new Tile {
                                    id = "sectioned-tile-grid-second-section-first-tile",
                                    url = "tile url",
                                    title = "Sectioned Tile Grid - Second Section - First Tile",
                                    classes = new [] {"class_a", "class_b", "class_c"}
                                },

                                new Tile {
                                    id = "sectioned-tile-grid-second-section-second-tile",
                                    url = "tile url",
                                    title = "Sectioned Tile Grid - Second Section - Second Tile",
                                    classes = new [] {"class_a", "class_b", "class_c"}
                                },                                
                            }
                        }
                    },
                },
            };

            return View( view_model );
        }
    }

    public class TileGridViewModel {
        public IEnumerable<Tile> tiles { get; set; }
        public TileGrid tile_grid { get; set; }
        public TileGrid tile_grid_section { get; set; }
        public SectionedTileGrid sectioned_tile_grid { get; set; }
    }

}