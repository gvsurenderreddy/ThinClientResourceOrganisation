using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTS.Web.StaticContent.Tests.html.component_system.subsystems.actions.standard_behaviours
{
    public class NavigationActionStandardBehaviourTestController : Controller
    {
        //
        // GET: /NavigationActionStandardBehaviourTest/
        public ActionResult Index()
        {
            return View( 
                @"~\Tests\html\component-system\subsystems\actions\standard-behaviours\NavigationActionStandardBehaviourTestView.cshtml"
            );
        }
	}
}