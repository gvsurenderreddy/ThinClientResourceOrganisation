using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.addSickness.editor
{
    public class RouteConfiguration : ARouteConfiguration<AddSicknessEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/sickness/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}