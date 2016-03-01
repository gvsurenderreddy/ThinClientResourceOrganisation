using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses
{
    public class FieldSetValidationResponseDefinitionRepository<T>
                                                            where T : ServiceStatusResponse
    {
        public Dictionary<Type, IList<ResponseMessage>> criteria { get; set; }

        public ResponseMessage page_level_success_message { get; set; }

        public ResponseMessage page_level_error_message { get; set; }


        public FieldSetValidationResponseDefinitionRepository()
        {
            criteria = new Dictionary<Type, IList<ResponseMessage>>();
            page_level_success_message = new ResponseMessage();
            page_level_error_message = new ResponseMessage();

        }
    }
}
