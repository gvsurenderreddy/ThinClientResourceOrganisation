using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New
{
    public class NewBreakTemplateRequestHelper
                    : IRequestHelper<NewBreakTemplateRequest>
    {
        public NewBreakTemplateRequest given_a_valid_request()
        {
            return new NewBreakTemplateRequest
            {
                template_name = "Three breakks - 20, 10, 30 - template",
                is_hidden = false
            };
        }
    }
}