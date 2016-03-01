using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses
{
    public class FieldSetValidationResponseDefinitionBuilder<T> where T : ServiceStatusResponse
    {
        private Type key;

        public FieldSetValidationResponseDefinitionBuilder<T> for_service_status<S>() where S : IServiceStatus
        {
            key = typeof(S);

            return this;
        }

        public FieldSetValidationResponseDefinitionBuilder<T> add_field_validation_status_message(string field_name, string message)
        {
            Guard.IsNotNull(key, "key");

            Guard.IsNotNull(field_name, "field_name");
            Guard.IsNotNull(message, "message");

            var field_status_message_to_add = message.ToResponseMessage(field_name);


            if (repository.criteria.ContainsKey(key))
            {
                repository.criteria[key].Add(field_status_message_to_add);
            }
            else
            {
                repository.criteria.Add(key, new List<ResponseMessage>()
                {
                    field_status_message_to_add,
                });
            }

            return this;
        }

        public void add_page_level_success_message(string message)
        {
            Guard.IsNotNull(message, "message");

            repository.page_level_success_message = new ResponseMessage { message = message };
        }

        public void add_page_level_error_message(string message)
        {
            Guard.IsNotNull(message, "message");

            repository.page_level_error_message = new ResponseMessage { message = message };
        }

        public FieldSetValidationResponseDefinitionBuilder(FieldSetValidationResponseDefinitionRepository<T> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }


        private readonly FieldSetValidationResponseDefinitionRepository<T> repository;
    }
}
