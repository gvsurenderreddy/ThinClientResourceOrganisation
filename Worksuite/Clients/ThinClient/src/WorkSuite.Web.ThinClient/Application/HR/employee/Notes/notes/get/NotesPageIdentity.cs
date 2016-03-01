using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Notes.notes.page;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Notes.notes.get
{
   public partial class NotesPageIdentity : IPageIdentity
    {
        public string page_id
        {
            get { return Resources.page_id; }
        }
    }
}
