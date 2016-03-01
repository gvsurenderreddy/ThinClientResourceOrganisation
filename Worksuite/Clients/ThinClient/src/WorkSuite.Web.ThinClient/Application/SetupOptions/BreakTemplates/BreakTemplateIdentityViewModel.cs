using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates
{
    public class BreakTemplateIdentityViewModel
    {
        public BreakTemplateIdentity identity { get; set; }
        public IEnumerable<IsAViewElement> view_elements { get; set; }
    }
}