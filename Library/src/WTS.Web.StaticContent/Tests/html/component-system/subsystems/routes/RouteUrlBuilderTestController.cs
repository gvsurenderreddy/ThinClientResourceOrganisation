using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTS.Web.StaticContent.Tests.html.component_system.subsystems.routes
{
    public class RouteUrlBuilderTestController 
                    : Controller {

        //
        // GET: /RouteUrlBuilderTest/
        public ActionResult Index() {

            return View(
                @"~\Tests\html\component-system\subsystems\routes\RouteUrlBuilderTestView.cshtml"
            );
        }
	}
}