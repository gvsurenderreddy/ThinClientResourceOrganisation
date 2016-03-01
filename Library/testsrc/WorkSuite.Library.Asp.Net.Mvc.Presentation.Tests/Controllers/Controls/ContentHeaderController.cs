using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls
{
    public class ContentHeaderController
                    : Controller
    {
        public ActionResult Index()
        {
            var content_header = new ContentHeader
            {
                title = "A Content Header Title",
                classes = new[] { "a_class", "another_class" },
                actions = new[] {
                    new ContentHeaderAction{
                        title = "First action title",
                        name = "edit-content-header",
                        classes = new [] { "a_class", "another_class" },
                        url = "example url"
                    },
                    new ContentHeaderAction
                    {
                        title = "Second action title",
                        name = "remove-content-header",
                        classes = new [] { "a_class", "another_class" },
                        url = "another example url"
                    },
                },
            };

            return View(content_header);
        }
    }
}