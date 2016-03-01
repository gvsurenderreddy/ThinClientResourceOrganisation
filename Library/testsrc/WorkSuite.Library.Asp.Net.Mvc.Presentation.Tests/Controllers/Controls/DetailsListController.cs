using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls
{
    public class DetailsListController
                    : Controller
    {
        public ActionResult Index()
        {
            var details_list = new DetailsList
            {
                id = "details list id",
                header = new DetailsListHeader
                {
                    title = "Details list header title",
                    actions = new List<RoutedAction> {
                        new RoutedAction {
                            id = "Details list header action 1",
                            title = "Details list header action 1 title",
                            url = "Details list header action 1 url",
                            name = "Details list header action 1 type",
                        }
                    }
                },
                elements = new List<IsAViewElement> {
                    ReportHelper.create_a_report(),
                    ReportHelper.create_a_report(),
                },
                report_presenter_url = "report presenter url",
                is_sortable = true,
            };

            return View(details_list);
        }
    }
}