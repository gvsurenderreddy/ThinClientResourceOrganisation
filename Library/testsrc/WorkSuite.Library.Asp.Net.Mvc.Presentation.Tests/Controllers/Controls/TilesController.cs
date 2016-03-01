using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class TilesController 
                    : Controller {

        public ActionResult Index() {

            var tile = new Tile {
                id = "tile id",
                url = "tile url",
                title = "Tile Title",
                classes = new string[] { "class_a", "class_b", "class_c" }
            };
            return View( tile );
        }
    }
}
