

using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder
{
    public interface IWorkflowMetadataBuilder
    {
        IWorkflowMetadataBuilder for_page(string page_id);

        IWorkflowMetadataBuilder for_editor<Ts>();

        IWorkflowMetadataBuilder for_action<Ta>() where Ta : CommonActionDefinition, new();

        IWorkflowMetadataBuilder add_destination(string page_id, string title);

        IWorkflowMetadataBuilder add_post_existing_destination(string page_id, string title);

        IWorkflowMetadataBuilder error_destination(string page_id, string title);
    }
}
