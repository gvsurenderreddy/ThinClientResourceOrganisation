using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Repository;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder
{
    public class WorkflowMetadataBuilder : IWorkflowMetadataBuilder
    {
        public IWorkflowMetadataBuilder for_page(string page_id)
        {
            the_page = page_id;
            editor_to_action_to_destination = new EditorToActionToDestinationDictionary();
            return this;
        }

        public IWorkflowMetadataBuilder for_editor<Ts>()
        {
            var service_layer_type = typeof(Ts).Name;
            the_editor = service_layer_type;

            //reset the action_to_destination dictionary
            var action_to_destination = new ActionToDestinationDictionary();

            editor_to_action_to_destination.Add(the_editor, action_to_destination);

            return this;
        }

        public IWorkflowMetadataBuilder for_action<Ta>() where Ta : CommonActionDefinition, new()
        {
            var action_definition = new Ta();
            the_action = action_definition.action_name;

            //reset the destinations
            var the_destinations = new DestinationSet
            {
                success_destinations = new List<Destination>()
            };

            var action_to_destination = editor_to_action_to_destination[the_editor];
            action_to_destination.Add(the_action, the_destinations);

            return this;
        }

        public IWorkflowMetadataBuilder add_destination(string page_id, string title)
        {
            add_success_destination(new Destination() { route_name = page_id, title = title, is_post_existing = false });

            return this;
        }

        public IWorkflowMetadataBuilder add_post_existing_destination(string page_id, string title)
        {
            add_success_destination(new Destination() { route_name = page_id, title = title, is_post_existing = true });

            return this;
        }

        private void add_success_destination(Destination the_destination)
        {
            var the_destinations = editor_to_action_to_destination[the_editor][the_action];
            the_destinations.success_destinations.Add(the_destination);


            if (!repository.entries.ContainsKey(the_page))
            {
                var dictionary = editor_to_action_to_destination;
                repository.entries.Add(the_page, dictionary);
            }
        }

        public IWorkflowMetadataBuilder error_destination(string page_id, string title)
        {
            var the_destinations = editor_to_action_to_destination[the_editor][the_action];

            the_destinations.error_destination = new Destination() { route_name = page_id, title = title };


            if (!repository.entries.ContainsKey(the_page))
            {
                var dictionary = editor_to_action_to_destination;
                repository.entries.Add(the_page, dictionary);
            }

            return this;
        }

        public WorkflowMetadataBuilder(IWorkflowMetadataRepository the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }


        private string the_page;
        private string the_editor;
        private string the_action;


        private EditorToActionToDestinationDictionary editor_to_action_to_destination;


        private readonly IWorkflowMetadataRepository repository;

    }
}
