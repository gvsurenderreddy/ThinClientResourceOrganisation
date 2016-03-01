using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Repository
{
    public class WorkflowMetadataRepository : IWorkflowMetadataRepository
    {
        public WorkflowMetadataRepository()
        {
            entries = new PageToEditorToActionToDestinationDictionary();
        }

        public PageToEditorToActionToDestinationDictionary entries { get; set; }

    }
}
