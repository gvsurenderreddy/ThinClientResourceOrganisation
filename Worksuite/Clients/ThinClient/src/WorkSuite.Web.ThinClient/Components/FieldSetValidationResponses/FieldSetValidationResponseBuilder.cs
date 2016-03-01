using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses
{
    public class FieldSetValidationResponseBuilder<T> where T : ServiceStatusResponse
    {
        public Response build(T service_response)
        {
            var messages = service_response
                              .service_statuses
                              .Select(m => lookup(m.GetType()))
                              .select_where_maybe_has_value()
                              .SelectMany(c => c)
                              .ToList();

            messages.Add(service_response.has_errors()
                ? repository.page_level_error_message
                : repository.page_level_success_message);


            return new Response()
            {
                has_errors = service_response.has_errors(),
                messages = messages
            };
        }

        private Maybe<IList<ResponseMessage>> lookup(Type key)
        {
            return repository.criteria.ContainsKey(key)
                ? repository.criteria[key].to_maybe()
                : default(IList<ResponseMessage>).to_maybe();
        }

        public FieldSetValidationResponseBuilder(FieldSetValidationResponseDefinitionRepository<T> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly FieldSetValidationResponseDefinitionRepository<T> repository;
    }

    public class FieldSetValidationResponseBuilder<T, Q> : FieldSetValidationResponseBuilder<T> 
                                                where T : ServiceStatusResponse<Q>
    {

        public new Response<Q> build(T service_response)
        {
            var result = base.build(service_response);

            return new Response<Q>()
            {
                has_errors = result.has_errors,
                messages = result.messages,
                result = service_response.result
            };
        }

        public FieldSetValidationResponseBuilder(FieldSetValidationResponseDefinitionRepository<T> the_repository)
                                        : base(the_repository)
        {
        }
    }
}
