using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.PageIdentity;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Repository;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Utilities
{
    /// <summary>
    /// This Workflow helper allows us to check the workflow repository that gets populated in the Page Metadata Configuration.
    /// It helps us get the destinations that have been ascribed to a given action.
    /// </summary>
    public class WorkflowHelper
    {
        public static WorkflowHelper Current
        {
            get { return DependencyResolver.Current.GetService<WorkflowHelper>(); }
        }

        public List<Destination> get_destinations(string editor_data_type, string action_name)
        {
            //IMPROVE: I'm not sure what the best action to take is here.
            //The problem is that there are still very many Presenters that do not implement PageIdentityPresenter
            //and I don't know how to tell which ones. I will try/catch here.

            try
            {
                var destination_set = workflow_metadata_repository.entries[page_id][editor_data_type][action_name];

                return destination_set.success_destinations;
            }
            catch (KeyNotFoundException)
            {
                return new List<Destination>();
            }
            catch (ArgumentNullException)
            {
                return new List<Destination>();
            }

        }

        public string page_id
        {
            get
            {
                return repository.page_model != null ? repository.page_model.page_id : null;
            }

        }

        public WorkflowHelper(IWorkflowMetadataRepository the_workflow_repository, ICurrentPageIdentityRepository the_repository)
        {
            workflow_metadata_repository = Guard.IsNotNull(the_workflow_repository, "the_workflow_repository");
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IWorkflowMetadataRepository workflow_metadata_repository;
        private readonly ICurrentPageIdentityRepository repository;
    }
}
