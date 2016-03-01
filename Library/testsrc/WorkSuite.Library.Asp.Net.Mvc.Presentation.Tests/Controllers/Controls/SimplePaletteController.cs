using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls
{
    public class SimplePaletteController : Controller
    {
        public ActionResult Index()
        {
            var palette = new SimplePalette
            {
                title = "A simple palette Title",
                description = "A simple palette description",
                classes = new[] { "a_class", "another_class" },
                actions = new[] {
                    new SimplePaletteAction{
                        title = "First action title",
                        name = "edit-content-header",
                        classes = new [] { "a_class", "another_class" },
                        url = "example url"
                    },
                    new SimplePaletteAction
                    {
                        title = "Second action title",
                        name = "remove-content-header",
                        classes = new [] { "a_class", "another_class" },
                        url = "another example url"
                    },
                }
            };

            return View(palette);
        }
    }
}