using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.New
{
    public class GetNewBreakTemplateRequest
                    : IGetNewBreakTemplateRequest
    {
        public NewBreakTemplateRequest execute()
        {
            return new NewBreakTemplateRequest
            {
                template_name = string.Empty,
                is_hidden = false
            };
        }
    }
}