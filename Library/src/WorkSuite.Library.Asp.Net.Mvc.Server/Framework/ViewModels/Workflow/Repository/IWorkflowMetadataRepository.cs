
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Repository
{
    public interface IWorkflowMetadataRepository
    {
        PageToEditorToActionToDestinationDictionary entries { get; set; }
    }
}
